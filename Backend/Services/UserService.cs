using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SavingsDeposits.Data;
using SavingsDeposits.Entities;
using SavingsDeposits.Helpers;

namespace SavingsDeposits.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string userName, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        Task<IdentityResult> Create(User user, string password, AppUserRole role = AppUserRole.User);
        void Update(User user, string password = null);
        void Delete(int id);
    }  
    
    
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<User> Authenticate(string userName, string password)
        {
            var foundUser =_userManager.Users.SingleOrDefault(r=>r.UserName == userName);
            if (foundUser != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(foundUser, password, false);
                if (result.Succeeded)
                {
                    return foundUser;    
                }
            }
            throw new AppException("Cannot login");
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IdentityResult> Create(User user, string password, AppUserRole role = AppUserRole.User)
        {
            var foundUser = await _userManager.FindByNameAsync(user.UserName);
            if (foundUser == null)
            {                    
                user.Id = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    try
                    {
                        return await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(AppUserRole), role));                
                    }
                    catch(Exception e)
                    {
                        var res = await _userManager.DeleteAsync(user);                        
                    }
                }
                else
                {
                    throw new AppException($"Something went wrong: {result.Errors.First().Description}");                    
                }
            }
            throw new NotFoundException("User already registered");                    

        }

        public void Update(User user, string password = null)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}