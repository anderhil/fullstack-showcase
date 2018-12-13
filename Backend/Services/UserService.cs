using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByUserName(string userName);
        Task<User> GetByPrincipal(ClaimsPrincipal principal);
        Task<string> GetByNameAsync(string userName);
        Task<IdentityResult> CreateAsync(User user, string password, AppUserRole role = AppUserRole.User);
        Task UpdateAsync(User user);
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

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> GetByUserName(string userName)
        {
            User foundUser = await _userManager.Users.Where(x => x.UserName == userName).SingleOrDefaultAsync();

            if (foundUser == null)
            {
                throw new NotFoundException("User not found");
            }

            return foundUser;
        }

        public async Task<User> GetByPrincipal(ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal);
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetByNameAsync(string userName)
        {
            var foundUser = await _userManager.FindByNameAsync(userName);
            if (foundUser == null) throw new NotFoundException("User not found");

            return foundUser.Id;
        }

        public async Task<IdentityResult> CreateAsync(User user, string password, AppUserRole role = AppUserRole.User)
        {
            var foundUser = await _userManager.FindByNameAsync(user.UserName);
            
            if (foundUser != null) throw new NotFoundException("User already registered");
            
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
            throw new NotFoundException("User already registered");                    

        }

        public async Task UpdateAsync(User user)
        {
            bool result = Enum.TryParse(user.Role, true, out AppUserRole val);
            if (!result)
            {
                throw new NotFoundException("Provided role is not valid");
            }
            
            User foundUser = await _userManager.Users.Where(x => x.UserName == user.UserName)
                                                     .SingleOrDefaultAsync();
            if (foundUser == null)
            {
                throw new NotFoundException("User does not exist");
            }

            var roles = await _userManager.GetRolesAsync(foundUser);
            
            string oldRole = roles.SingleOrDefault();
            
            if (string.IsNullOrEmpty(oldRole))
            {
                //throw new AppException("User has to have role attached");
            }
            
            foundUser.Email = user.Email;
            foundUser.UserName = user.UserName;
            foundUser.FullName = user.FullName;

            string newRole = user.Role;
            //change user role
            if (oldRole != newRole)
            {
                if(oldRole != null)
                    await _userManager.RemoveFromRoleAsync(foundUser, oldRole.ToUpperInvariant());
                await _userManager.AddToRoleAsync(foundUser, newRole.ToUpperInvariant());

                foundUser.Role = newRole;
            }
            
            await _userManager.UpdateAsync(foundUser);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}