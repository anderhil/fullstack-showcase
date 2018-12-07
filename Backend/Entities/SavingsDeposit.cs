using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SavingsDeposits.Entities
{
    public class SavingsDeposit
    {
        public int Id { get; set; }
        
        public string Owner { get; set; }
        
        public string BankName { get; set; }
        public int AccountNumber { get; set; }
        public decimal InitialAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int YearlyInterestPercentage { get; set; }
        public int TaxPercentage { get; set; }
        
        public decimal CurrentProfitAfterTax { get; set; }
        public DateTime LastCalculation { get; set; }
        
         
        //A saving deposit is identified by a bank name,
        //account number, an initial amount saved (currency in USD), start date, end date,
        //interest percentage per year and taxes percentage.
    }
}