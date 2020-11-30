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
    public class UserIncomesController : ControllerBase
    {
        private readonly UserContext _context;

        public UserIncomesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserIncomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserIncome>>> GetUserIncome()
        {
            return await _context.UserIncome.ToListAsync();
        }

        // GET: api/UserIncomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserIncome>> GetUserIncome(int id)
        {
            var userIncome = await _context.UserIncome.FindAsync(id);

            if (userIncome == null)
            {
                return NotFound();
            }

            return userIncome;
        }

        // PUT: api/UserIncomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserIncome(int id, UserIncome userIncome)
        {
            if (id != userIncome.ID)
            {
                return BadRequest();
            }

            _context.Entry(userIncome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserIncomeExists(id))
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

        // POST: api/UserIncomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserIncome>> PostUserIncome(UserIncome userIncome)
        {
            _context.UserIncome.Add(userIncome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserIncome", new { id = userIncome.ID }, userIncome);
        }

        // DELETE: api/UserIncomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserIncome(int id)
        {
            var userIncome = await _context.UserIncome.FindAsync(id);
            if (userIncome == null)
            {
                return NotFound();
            }

            _context.UserIncome.Remove(userIncome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserIncomeExists(int id)
        {
            return _context.UserIncome.Any(e => e.ID == id);
        }
    }
}
