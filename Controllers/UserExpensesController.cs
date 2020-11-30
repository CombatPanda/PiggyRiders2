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
    public class UserExpensesController : ControllerBase
    {
        private readonly UserContext _context;

        public UserExpensesController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserExpenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserExpense>>> GetUserExpense()
        {
            return await _context.UserExpense.ToListAsync();
        }

        // GET: api/UserExpenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserExpense>> GetUserExpense(int id)
        {
            var userExpense = await _context.UserExpense.FindAsync(id);

            if (userExpense == null)
            {
                return NotFound();
            }

            return userExpense;
        }

        // PUT: api/UserExpenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserExpense(int id, UserExpense userExpense)
        {
            if (id != userExpense.ID)
            {
                return BadRequest();
            }

            _context.Entry(userExpense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExpenseExists(id))
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

        // POST: api/UserExpenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserExpense>> PostUserExpense(UserExpense userExpense)
        {
            _context.UserExpense.Add(userExpense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserExpense", new { id = userExpense.ID }, userExpense);
        }

        // DELETE: api/UserExpenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserExpense(int id)
        {
            var userExpense = await _context.UserExpense.FindAsync(id);
            if (userExpense == null)
            {
                return NotFound();
            }

            _context.UserExpense.Remove(userExpense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExpenseExists(int id)
        {
            return _context.UserExpense.Any(e => e.ID == id);
        }
    }
}
