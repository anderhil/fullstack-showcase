using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavingsDeposits.Data;
using SavingsDeposits.Entities;
using SavingsDeposits.Helpers;

namespace SavingsDeposits.Services
{
    public interface ISavingsDepositService
    {
        Task CreateNewSavingsDepositAsync(SavingsDeposit entity);
        Task<IEnumerable<SavingsDeposit>> GetSavingsDepositsByOwnerId(string id);
        Task UpdateSavingsDeposit(string userId, SavingsDeposit entity);
        Task DeleteSavingsDeposit(string userId, int entityId);
    }
    public class SavingsDepositService : ISavingsDepositService 
    {
        private readonly AppDataContext _context;

        public SavingsDepositService(AppDataContext context)
        {
            _context = context;
        }
        
        public async Task CreateNewSavingsDepositAsync(SavingsDeposit entity)
        {
            _context.SavingDeposit.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SavingsDeposit>> GetSavingsDepositsByOwnerId(string id)
        {
            return await _context.SavingDeposit.Where(x => x.Owner == id).ToListAsync();
        }

        public async Task UpdateSavingsDeposit(string userId, SavingsDeposit entity)
        {
            var result = await _context.SavingDeposit.Where(x => x.Id == entity.Id).Select(x=>x.Owner).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException("");
            }

            if(result == userId)            
            {
                entity.Owner = userId;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotAuthorizedException("User cannot edit this record");
            }
        }

        public async Task DeleteSavingsDeposit(string userId, int entityId)
        {
            var result = await _context.SavingDeposit.Where(x => x.Id == entityId).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException("");
            }

            if (result.Owner == userId)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotAuthorizedException("User cannot remove this record");
            }
        }
    }
}