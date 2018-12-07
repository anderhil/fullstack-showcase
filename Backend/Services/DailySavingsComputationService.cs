using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SavingsDeposits.Data;
using SavingsDeposits.Entities;
using SavingsDeposits.Helpers;

namespace SavingsDeposits.Services
{
    public class DailySavingsComputationService : HostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DailySavingsComputationService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        private TimeSpan CalculateNextRun()
        {
            DateTime tomorrowNight = DateTime.Now.Date.AddDays(1);
            return tomorrowNight - DateTime.Now;
        }
        
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    AppDataContext appDataContext = scope.ServiceProvider.GetRequiredService<AppDataContext>();
                    
                    SavingsComputationService computationService = new SavingsComputationService(appDataContext);
                    
                    await computationService.RunCalculationForAllUsersAsync(DateTime.Now);                    
                }
                
                await Task.Delay(CalculateNextRun(), cancellationToken);
            }
        }
    }
}