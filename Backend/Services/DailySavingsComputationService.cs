using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
                    var logger = scope.ServiceProvider.GetService<ILogger<DailySavingsComputationService>>();
                    AppDataContext appDataContext = scope.ServiceProvider.GetRequiredService<AppDataContext>();
                    
                    SavingsComputationService computationService = new SavingsComputationService(appDataContext);
                    
                    logger.LogInformation("Started computation of deposits");
                    
                    await computationService.RunCalculationForAllUsersAsync(DateTime.Now);   
                    
                    logger.LogInformation("Finished computation");

                }
                await Task.Delay(CalculateNextRun(), cancellationToken);
            }
        }
    }
}