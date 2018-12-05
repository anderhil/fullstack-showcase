using System;

namespace SavingsDeposits.Helpers
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
            
        }
    }
}