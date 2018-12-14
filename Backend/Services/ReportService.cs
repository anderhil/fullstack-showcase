using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SavingsDeposits.Data;
using SavingsDeposits.Entities;

namespace SavingsDeposits.Services
{
    public class DepositReport
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        
        public decimal TotalProfitBeforeTax { get; set; }
        public decimal TotalProfitAfterTax { get; set; }
        public decimal TotalProfitTax { get; set; }
    }

    public class DateRangeReport
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        private DepositReport[] _depositReports;
        
        public DepositReport[] DepositReports
        {
            get => _depositReports;
            set
            {
                if (value != null)
                {
                    foreach (DepositReport report in value)
                    {
                        DepositsSummaryProfitTax += report.TotalProfitTax;
                        DepositsSummaryProfitAfterTax += report.TotalProfitAfterTax;
                        DepositsSummaryProfitBeforeTax += report.TotalProfitBeforeTax;
                    }
                }

                _depositReports = value;
            }
        }

        public decimal DepositsSummaryProfitBeforeTax { get; set; }
        public decimal DepositsSummaryProfitAfterTax { get; set; }
        public decimal DepositsSummaryProfitTax { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PeriodInDays => (int)(EndDate - StartDate).TotalDays;
    }

    public interface IReportService
    {
        Task<ReportData> GenerateReport(string userId, DateTime startDate, DateTime endDate);
    }

    public class ReportService : IReportService
    {
        private readonly AppDataContext _context;

        public ReportService(AppDataContext context)
        {
            _context = context;
        }
        public async Task<ReportData> GenerateReport(string userId, DateTime startDate, DateTime endDate)
        {
            DateRangeReport rangeReport = new DateRangeReport
            {
                StartDate = startDate,
                EndDate = endDate
            };

            var foundUser = await _context.Users.SingleOrDefaultAsync(x=> x.Id == userId);

            rangeReport.Email = foundUser.Email;
            rangeReport.FullName = foundUser.FullName;
            rangeReport.UserName = foundUser.UserName;
            
            var depositMap = await _context.SavingsDeposits.Where(x => x.Owner == userId).Select(x => new{x.Id,x.BankName,x.AccountNumber})
                .ToDictionaryAsync(x=>x.Id);

            var userDeposits = depositMap.Keys;
           
            var result = await _context.DepositsHistory.Where(x =>
                    x.CalculationDate >= startDate && x.CalculationDate <= endDate &&
                    userDeposits.Contains(x.SavingsDepositId))
                .GroupBy(x => x.SavingsDepositId,
                    (i, h) => new{Id = i,TotalTax = h.Sum(x => x.ProfitTax), TotalBeforTax = h.Sum(x=>x.ProfitBeforeTax), TotalAfterTax = h.Sum(x=>x.ProfitAfterTax)})
                .ToListAsync();
            
            rangeReport.DepositReports = result.Select(x=> new DepositReport
            {
                AccountNumber = depositMap[x.Id].AccountNumber.ToString(),
                BankName = depositMap[x.Id].BankName,
                TotalProfitBeforeTax = x.TotalBeforTax,
                TotalProfitAfterTax = x.TotalAfterTax,
                TotalProfitTax = x.TotalTax,
            }).ToArray();

            string json = JsonConvert.SerializeObject(rangeReport);

            var reportData = new ReportData
            {
                UserId = userId, JsonObject = json, ReportDate = DateTime.Now
            };

            _context.Reports.Add(reportData);
            await _context.SaveChangesAsync();
            
            return reportData;
        }
    }
}