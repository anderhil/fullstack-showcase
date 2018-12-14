using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SavingsDeposits.DTOs;
using SavingsDeposits.Entities;
using SavingsDeposits.Services;

namespace SavingsDeposits.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/report")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ReportController(IReportService service, IUserService userService, IMapper mapper)
        {
            _reportService = service;
            _userService = userService;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> GenerateReport([FromQuery]DateTime startDate,[FromQuery]DateTime endDate)
        {
            string userId = HttpContext.User.Identity.Name;

            var result = await _reportService.GenerateReport(userId, startDate, endDate);

            return new JsonResult(result.JsonObject);
        }        
    }
    
}