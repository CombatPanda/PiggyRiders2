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
    public class ExpensesManagerInformationsController : ControllerBase
    {
        private readonly UserContext _context;

        public ExpensesManagerInformationsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/ExpensesManagerInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpensesManagerInformation>>> GetEMInfo()
        {
            return await _context.EMInfo.ToListAsync();
        }

        // GET: api/ExpensesManagerInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpensesManagerInformation>> GetExpensesManagerInformation(int id)
        {
            var expensesManagerInformation = await _context.EMInfo.FindAsync(id);

            if (expensesManagerInformation == null)
            {
                return NotFound();
            }

            return expensesManagerInformation;
        }

        // PUT: api/ExpensesManagerInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpensesManagerInformation(int id, ExpensesManagerInformation expensesManagerInformation)
        {
            if (id != expensesManagerInformation.ID)
            {
                return BadRequest();
            }

            _context.Entry(expensesManagerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesManagerInformationExists(id))
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

        // POST: api/ExpensesManagerInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpensesManagerInformation>> PostExpensesManagerInformation(ExpensesManagerInformation expensesManagerInformation)
        {
            _context.EMInfo.Add(expensesManagerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpensesManagerInformation", new { id = expensesManagerInformation.ID }, expensesManagerInformation);
        }

        // DELETE: api/ExpensesManagerInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpensesManagerInformation(int id)
        {
            var expensesManagerInformation = await _context.EMInfo.FindAsync(id);
            if (expensesManagerInformation == null)
            {
                return NotFound();
            }

            _context.EMInfo.Remove(expensesManagerInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpensesManagerInformationExists(int id)
        {
            return _context.EMInfo.Any(e => e.ID == id);
        }
    }
}
