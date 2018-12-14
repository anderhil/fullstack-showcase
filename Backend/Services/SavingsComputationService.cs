using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavingsDeposits.Data;
using SavingsDeposits.Entities;

namespace SavingsDeposits.Services
{

    public interface ISavingsComputationService
    {
        DepositHistory PerformDepositCalculation(SavingsDeposit savingsDeposit);
        Task RunCalculationForAllUsersAsync(DateTime calculationDate);
    }

    public class SavingsComputationService : ISavingsComputationService
    {
        private readonly DateTime calculationDate;
        private readonly AppDataContext _context;
        private const int DaysInYear = 360;

        public SavingsComputationService(AppDataContext context)
        {
            _context = context;
        }

        public DepositHistory PerformDepositCalculation(SavingsDeposit savingsDeposit)
        {
            DepositHistory depositHistory = new DepositHistory();
            
            decimal dailyCalculatedAmount = savingsDeposit.AccountBalance * savingsDeposit.YearlyInterestPercentage /
                                            DaysInYear / 100m;
            decimal profitTax = 0;
            if (dailyCalculatedAmount > 0)
            {
                profitTax = dailyCalculatedAmount * savingsDeposit.TaxPercentage / 100m;
            }

            depositHistory.SavingsDepositId = savingsDeposit.Id;

            depositHistory.ProfitBeforeTax = Math.Round(dailyCalculatedAmount, 2);
            depositHistory.ProfitTax = Math.Round(profitTax, 2);
            depositHistory.ProfitAfterTax = depositHistory.ProfitBeforeTax - depositHistory.ProfitTax;

            depositHistory.TotalProfitAfterTax = savingsDeposit.CurrentProfitAfterTax + depositHistory.ProfitAfterTax;

            return depositHistory;
        }

        public async Task RunCalculationForAllUsersAsync(DateTime calculationDate)
        {
            List<string> users =
                await _context.Users.Select(x => x.Id).ToListAsync();

            foreach (string userId in users)
            {
                DateTime now = calculationDate.Date;
                IEnumerable<SavingsDeposit> savingsDeposits = await _context.SavingsDeposits
                    .Where(x => x.Owner == userId && now >= x.StartDate && now <= x.EndDate.AddDays(1))
                    .ToListAsync();

                foreach (SavingsDeposit savingsDeposit in savingsDeposits)
                {
                    if (savingsDeposit.LastCalculation.Date < now)
                    {
                        DepositHistory depositHistory = PerformDepositCalculation(savingsDeposit);
                        
                        depositHistory.CalculationDate = calculationDate;
                        
                        savingsDeposit.LastCalculation = calculationDate;
                        
                        savingsDeposit.CurrentProfitAfterTax = depositHistory.TotalProfitAfterTax;
                        
                        _context.DepositsHistory.Add(depositHistory);
                    }

                    _context.Entry(savingsDeposit).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
            }

        }
    }
}