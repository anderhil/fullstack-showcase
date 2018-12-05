using System;

namespace SavingsDeposits.Helpers
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
            
        }
    }

    public class NotFoundException : AppException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }  
    
    public class NotAuthorizedException : AppException
    {
        public NotAuthorizedException(string message) : base(message)
        {
        }
    }
}