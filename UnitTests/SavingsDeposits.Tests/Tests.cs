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
        [Fact]
        public void TestSavingsDepositsCalculation()
        {
            var calculationService = new SavingsComputationService(null);


            SavingsDeposit deposit = new SavingsDeposit
            {    
                InitialAmount = 100_000,
                TaxPercentage = 15,
                YearlyInterestPercentage = 5
            };

            var result = calculationService.PerformDepositCalculation(deposit);
            Assert.Equal(13.89m,result.ProfitBeforeTax);
            Assert.Equal(2.08m,result.ProfitTax);
            Assert.Equal(11.81m,result.ProfitAfterTax);   
            Assert.Equal(11.81m,result.TotalProfitAfterTax);   
            Assert.Equal(DateTime.Today, result.CalculationDate);   
            Assert.Equal(deposit.CurrentProfitAfterTax,result.TotalProfitAfterTax);   
            
            result = calculationService.PerformDepositCalculation(deposit);
            Assert.Equal(13.89m,result.ProfitBeforeTax);
            Assert.Equal(2.08m,result.ProfitTax);
            Assert.Equal(11.81m,result.ProfitAfterTax);   
            
            Assert.Equal(DateTime.Today, result.CalculationDate);   
            Assert.Equal(23.62m,result.TotalProfitAfterTax);
            Assert.Equal(deposit.CurrentProfitAfterTax,result.TotalProfitAfterTax);   

            
            SavingsDeposit credit = new SavingsDeposit
            {    
                InitialAmount = 100_000,
                TaxPercentage = 15,
                YearlyInterestPercentage = -20
            };
            
            result = calculationService.PerformDepositCalculation(credit);
            Assert.Equal(DateTime.Today, result.CalculationDate);   
            Assert.Equal(-55.56m,result.ProfitBeforeTax);
            Assert.Equal(result.ProfitBeforeTax,result.ProfitAfterTax);
            Assert.Equal(0m,result.ProfitTax);
        }

        [Fact]
        public void TestLastDateCalculation()
        {
            var options = new DbContextOptionsBuilder<AppDataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
              var context = new AppDataContext(options);

            var user = new User
            {
                Id = "myId"
            };
            
            SavingsDeposit deposit = new SavingsDeposit
            {    
                Owner = user.Id,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(2),
                InitialAmount = 100_000,
                TaxPercentage = 15,
                YearlyInterestPercentage = 5
            };
            
            context.SavingsDeposits.Add(deposit); 
            context.Users.Add(user);
            context.SaveChanges();

            var calculationService = new SavingsComputationService(context);

            //if entity is added today, then calculation will be at night next day, so its
            //needed to check if the calculation will be perfomed at night of end date + 1
            foreach (var date in new[] {DateTime.Today.AddDays(1), DateTime.Today.AddDays(2), DateTime.Today.AddDays(3), DateTime.Today.AddDays(3), DateTime.Today.AddDays(4)})
            {
                calculationService.RunCalculationForAllUsersAsync(date).Wait();
            }
            
            DepositHistory[] result = context.DepositsHistory.ToArray();
            
            Assert.Equal(3, result.Length);
            Assert.Equal(11.81m*3, result.Last().TotalProfitAfterTax);

        }
    }
}