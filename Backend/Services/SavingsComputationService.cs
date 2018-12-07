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

            decimal dailyCalculatedAmount = savingsDeposit.InitialAmount * savingsDeposit.YearlyInterestPercentage /
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




//    User must be able to create an account and log in. (If a mobile application, this means that more users can use the app from the same phone).

//    When logged in, a user can see, edit and delete saving deposits he entered.

//    Implement at least three roles with different permission levels: a regular user would only be able to CRUD on their owned records, a user manager would be able to CRUD users, and an admin would be able to CRUD all records and users.
//    A saving deposit is identified by a bank name, account number, an initial amount saved (currency in USD), start date, end date, interest percentage per year and taxes percentage.
//    The interest could be positive or negative. The taxes are only applied over profit.

//    User can filter saving deposits by the amount (minimum and maximum), bank name and date.

//    User can generate a revenue report for a given period, that will show the gains and losses from interest and taxes for each deposit. The amount should be green or red if respectively it represents a gain or loss. The report should show the sum of profits and losses at the bottom for that period. 

//    The computation of profit/loss is done on a daily basis. Consider that a year is 360 days. 

//    REST API. Make it possible to perform all user actions via the API, including authentication (If a mobile application and you don’t know how to create your own backend you can use Firebase.com or similar services to create the API).
//    In any case, you should be able to explain how a REST API works and demonstrate that by creating functional tests that use the REST Layer directly. Please be prepared to use REST clients like Postman, cURL, etc. for this purpose.
//    If it’s a web application, it must be a single-page application. All actions need to be done client side using AJAX, refreshing the page is not acceptable. (If a mobile application, disregard this).
//    Functional UI/UX design is needed. You are not required to create a unique design, however, do follow best practices to make the project as functional as possible.
//    Bonus: unit and e2e tests.

        }
    }
}