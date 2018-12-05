using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavingsDeposits.Entities;
using SavingsDeposits.Data;

namespace SavingsDeposits.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/Savings")]
    public class SavingDepositController : Controller
    {
        private readonly AppDataContext _context;

        public SavingDepositController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public IEnumerable<SavingsDeposit> GetSavingDeposit()
        {
            return _context.SavingDeposit;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavingDeposit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savingDeposit = await _context.SavingDeposit.SingleOrDefaultAsync(m => m.Id == id);

            if (savingDeposit == null)
            {
                return NotFound();
            }

            return Ok(savingDeposit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavingDeposit([FromRoute] int id, [FromBody] SavingsDeposit savingsDeposit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savingsDeposit.Id)
            {
                return BadRequest();
            }

            _context.Entry(savingsDeposit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavingDepoistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostSavingDeposit([FromBody] SavingsDeposit savingsDeposit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SavingDeposit.Add(savingsDeposit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSavingDeposit", new { id = savingsDeposit.Id }, savingsDeposit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavingDeposit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savingDeposit = await _context.SavingDeposit.SingleOrDefaultAsync(m => m.Id == id);
            if (savingDeposit == null)
            {
                return NotFound();
            }

            _context.SavingDeposit.Remove(savingDeposit);
            await _context.SaveChangesAsync();

            return Ok(savingDeposit);
        }

        private bool SavingDepoistExists(int id)
        {
            return _context.SavingDeposit.Any(e => e.Id == id);
        }
    }
    
}