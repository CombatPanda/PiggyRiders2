using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;

namespace SmartSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBalancesController : ControllerBase
    {
        private readonly UserContext _context;

        public UserBalancesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserBalances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBalance>>> GetUserBalance()
        {
            return await _context.UserBalance.ToListAsync();
        }

        // GET: api/UserBalances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBalance>> GetUserBalance(int id)
        {
            var userBalance = await _context.UserBalance.FindAsync(id);

            if (userBalance == null)
            {
                return NotFound();
            }

            return userBalance;
        }

        // PUT: api/UserBalances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBalance(int id, UserBalance userBalance)
        {
            if (id != userBalance.ID)
            {
                return BadRequest();
            }

            _context.Entry(userBalance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBalanceExists(id))
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

        // POST: api/UserBalances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserBalance>> PostUserBalance(UserBalance userBalance)
        {
            _context.UserBalance.Add(userBalance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBalance", new { id = userBalance.ID }, userBalance);
        }

        // DELETE: api/UserBalances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserBalance(int id)
        {
            var userBalance = await _context.UserBalance.FindAsync(id);
            if (userBalance == null)
            {
                return NotFound();
            }

            _context.UserBalance.Remove(userBalance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserBalanceExists(int id)
        {
            return _context.UserBalance.Any(e => e.ID == id);
        }
    }
}
