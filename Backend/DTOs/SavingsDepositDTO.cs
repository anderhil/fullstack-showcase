using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SavingsDeposits.DTOs
{
    public class SavingsDepositDTO
    {
        public int Id { get; set; }
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
    }
}