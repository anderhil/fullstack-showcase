using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavingsDeposits.Entities;
using SavingsDeposits.Data;
using SavingsDeposits.DTOs;
using SavingsDeposits.Services;

namespace SavingsDeposits.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/Savings")]
    public class SavingDepositController : Controller
    {
        private readonly ISavingsDepositService _savingsService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public SavingDepositController(ISavingsDepositService service, IUserService userService, IMapper mapper)
        {
            _savingsService = service;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public IEnumerable<SavingsDepositDTO> GetSavingDeposit()
        {
            return Enumerable.Empty<SavingsDepositDTO>(); //_context.SavingDeposit;
        }  
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavingDeposit([FromRoute]int id)
        {
            string userId = GetUserId(HttpContext.User);

            var result = await _savingsService.GetSavingsDepositByOwnerIdAsync(userId, id);

            return Ok(result);
        }        
        
        [HttpGet("{id}/{user}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> GetSavingDeposit([FromRoute]int id, [FromRoute]string user)
        {
            string userId = await this._userService.GetByNameAsync(user);

            var result = await _savingsService.GetSavingsDepositByOwnerIdAsync(userId, id);

            return Ok(result);
        }
        
        [HttpGet("all")]
        public async Task<IActionResult> GetSavingDepositByUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            string userId = GetUserId(HttpContext.User);

            var result = await _savingsService.GetSavingsDepositsByOwnerIdAsync(userId);
                        
            var savingsEntity = _mapper.Map<IEnumerable<SavingsDepositDTO>>(result);

            return Ok(savingsEntity);
        }  
        
        [HttpGet]
        [Route("all/{userName}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> GetSavingDepositByUser([FromRoute]string userName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = await _userService.GetByNameAsync(userName);
            
            var result = await _savingsService.GetSavingsDepositsByOwnerIdAsync(userId);
                        
            var savingsEntity = _mapper.Map<IEnumerable<SavingsDepositDTO>>(result);

            return Ok(savingsEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavingDeposit([FromRoute] int id, [FromBody] SavingsDepositDTO savingsDepositDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savingsDepositDTO.Id)
            {
                return BadRequest();
            }

            SavingsDeposit result = _mapper.Map<SavingsDeposit>(savingsDepositDTO);
            string requestUserId = GetUserId(HttpContext.User);
            await _savingsService.UpdateSavingsDepositAsync(requestUserId, result);
           
            
            return NoContent();
        }

        private string GetUserId(ClaimsPrincipal principal)
        {
            //we can substitute this with different approach later if needed
            return principal.Identity.Name;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostSavingDeposit([FromBody] SavingsDepositDTO savingsDeposit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = GetUserId(HttpContext.User);
            
            var savingsEntity = _mapper.Map<SavingsDeposit>(savingsDeposit);
            
            savingsEntity.Owner = userId;
            await _savingsService.CreateNewSavingsDepositAsync(savingsEntity);

            return Ok(new {savingsEntity.Id});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavingDeposit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = GetUserId(HttpContext.User);
            await _savingsService.DeleteSavingsDepositAsync(userId, id);

            return Ok();
        }
     
    }
    
}