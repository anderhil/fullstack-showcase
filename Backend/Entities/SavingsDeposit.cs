using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SavingsDeposits.Entities
{
    public class SavingsDeposit
    {
        public int Id { get; set; }

        [JsonIgnore]
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string BankName { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]        
        public decimal InitialAmount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int YearlyInterestPercentage { get; set; }
        [Required]
        public int TaxPercentage { get; set; }
        
         
        //A saving deposit is identified by a bank name,
        //account number, an initial amount saved (currency in USD), start date, end date,
        //interest percentage per year and taxes percentage.
    }
}