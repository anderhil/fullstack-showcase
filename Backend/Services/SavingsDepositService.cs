using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        Task<IEnumerable<SavingsDeposit>> GetSavingsDepositsByOwnerIdAsync(string id);
        Task<SavingsDeposit> GetSavingsDepositByOwnerIdAsync(string userId, int savingsDepositId);
        Task UpdateSavingsDepositAsync(string userId, SavingsDeposit entity);
        Task UpdateSavingsDepositAsync(SavingsDeposit entity);
        Task DeleteSavingsDepositAsync(string userId, int entityId);
        Task DeleteSavingsDepositAsync(int entityId);
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
            _context.SavingsDeposits.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SavingsDeposit>> GetSavingsDepositsByOwnerIdAsync(string id)
        {
            return await _context.SavingsDeposits.Where(x => x.Owner == id).ToListAsync();
        }

        public async Task<SavingsDeposit> GetSavingsDepositByOwnerIdAsync(string userId, int savingsDepositId)
        {
            var result = await _context.SavingsDeposits.Where(x => x.Owner == userId && x.Id == savingsDepositId).SingleOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException("No deposit found for current user");
            }

            return result;
        }

        public async Task UpdateSavingsDepositAsync(string userId, SavingsDeposit entity)
        {
            var result = await _context.SavingsDeposits.Where(x => x.Id == entity.Id).Select(x=>x.Owner).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException("Deposit not found for current user");
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

        public async Task UpdateSavingsDepositAsync(SavingsDeposit entity)
        {
            var owner = await _context.SavingsDeposits.Where(x => x.Id == entity.Id).Select(x => x.Owner).SingleOrDefaultAsync();
            entity.Owner = owner;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSavingsDepositAsync(string userId, int entityId)
        {
            var result = await _context.SavingsDeposits.Where(x => x.Id == entityId).FirstOrDefaultAsync();

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

        public async Task DeleteSavingsDepositAsync(int entityId)
        {
            var result = await _context.SavingsDeposits.Where(x => x.Id == entityId).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException("");
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}