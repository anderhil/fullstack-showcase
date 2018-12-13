using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Moq;
using SavingsDeposits.Data;
using SavingsDeposits.Entities;
using SavingsDeposits.Services;
using Xunit;

namespace SavingsDeposits.Tests
{
    public class ComputationTest
    {
        private SavingsComputationService _calculationService;
        private AppDataContext _context;
        private User _user;

        public ComputationTest()
        {
            var options = new DbContextOptionsBuilder<AppDataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            _context = new AppDataContext(options);

            _user = new User
            {
                Id = "myId"
            };
            


            _calculationService = new SavingsComputationService(_context);
        }
        
        [Fact]
        public void TestSavingsDepositsCalculation()
        {
            var calculationService = new SavingsComputationService(null);


            SavingsDeposit savingsDeposit = new SavingsDeposit
            {    
                InitialAmount = 100_000,
                TaxPercentage = 15,
                YearlyInterestPercentage = 5
            };

            DepositHistory depositHistory = calculationService.PerformDepositCalculation(savingsDeposit);
            savingsDeposit.CurrentProfitAfterTax = depositHistory.TotalProfitAfterTax;
            savingsDeposit.LastCalculation = DateTime.Today;
            depositHistory.CalculationDate = DateTime.Today;
            
            Assert.Equal(13.89m,depositHistory.ProfitBeforeTax);
            Assert.Equal(2.08m,depositHistory.ProfitTax);
            Assert.Equal(11.81m,depositHistory.ProfitAfterTax);   
            Assert.Equal(11.81m,depositHistory.TotalProfitAfterTax);   


            
            depositHistory = calculationService.PerformDepositCalculation(savingsDeposit);
            savingsDeposit.CurrentProfitAfterTax = depositHistory.TotalProfitAfterTax;
            savingsDeposit.LastCalculation = DateTime.Today;
            depositHistory.CalculationDate = DateTime.Today;
            
            Assert.Equal(13.89m,depositHistory.ProfitBeforeTax);
            Assert.Equal(2.08m,depositHistory.ProfitTax);
            Assert.Equal(11.81m,depositHistory.ProfitAfterTax);   
            
            Assert.Equal(23.62m,depositHistory.TotalProfitAfterTax);

            SavingsDeposit credit = new SavingsDeposit
            {    
                InitialAmount = 100_000,
                TaxPercentage = 15,
                YearlyInterestPercentage = -20
            };
            
            depositHistory = calculationService.PerformDepositCalculation(credit);
            Assert.Equal(-55.56m,depositHistory.ProfitBeforeTax);
            Assert.Equal(depositHistory.ProfitBeforeTax,depositHistory.ProfitAfterTax);
            Assert.Equal(0m,depositHistory.ProfitTax);
        }
        
        [Fact]
        public void TestLastDateCalculation()
        {
            SavingsDeposit deposit = new SavingsDeposit
            {    
                Owner = _user.Id,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(2),
                InitialAmount = 100_000,
                TaxPercentage = 15,
                YearlyInterestPercentage = 5
            };
            
            _context.SavingsDeposits.Add(deposit); 
            _context.Users.Add(_user);
            _context.SaveChanges();
            
            //if entity is added today, then calculation will be at night next day, so its
            //needed to check if the calculation will be perfomed at night of end date + 1
            foreach (var date in new[] {DateTime.Today.AddDays(1), DateTime.Today.AddDays(2), DateTime.Today.AddDays(3), DateTime.Today.AddDays(3), DateTime.Today.AddDays(4)})
            {
                _calculationService.RunCalculationForAllUsersAsync(date).Wait();
            }
            
            DepositHistory[] result = _context.DepositsHistory.ToArray();
            
            Assert.Equal(3, result.Length);
            Assert.Equal(11.81m*3, result.Last().TotalProfitAfterTax);

        }  
        
        [Fact]
        public void BalanceTest_5pYear_0Tax()
        {
            SavingsDeposit deposit = new SavingsDeposit
            {    
                Owner = _user.Id,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddYears(1),
                InitialAmount = 100_000_000,
                TaxPercentage = 0,
                YearlyInterestPercentage = 5
            };
            
            _context.SavingsDeposits.Add(deposit); 
            _context.Users.Add(_user);
            _context.SaveChanges();


            var today = DateTime.Today;
            for (int i = 0; i < 360; i++)
            {
                _calculationService.RunCalculationForAllUsersAsync(today.AddDays(i)).Wait();
            }
            
            Assert.Equal(105126744.65m, deposit.AccountBalance);

        }        
        
        [Fact]
        public void BalanceTest_5pYear_20Tax()
        {
            SavingsDeposit deposit = new SavingsDeposit
            {    
                Owner = _user.Id,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddYears(1),
                InitialAmount = 100_000_000,
                TaxPercentage = 20,
                YearlyInterestPercentage = 5
            };
            
            _context.SavingsDeposits.Add(deposit); 
            _context.Users.Add(_user);
            _context.SaveChanges();


            var today = DateTime.Today;
            for (int i = 0; i < 360; i++)
            {
                _calculationService.RunCalculationForAllUsersAsync(today.AddDays(i)).Wait();
            }
            
            Assert.Equal(104080846.19m, deposit.AccountBalance);

        }
    }
}