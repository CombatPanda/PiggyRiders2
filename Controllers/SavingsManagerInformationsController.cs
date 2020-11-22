using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using Smart_Saver_WEB.Models;

namespace SmartSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsManagerInformationsController : ControllerBase
    {
        private readonly UserContext _context;

        public SavingsManagerInformationsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/SavingsManagerInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavingsManagerInformation>>> GetSMInfo()
        {
            return await _context.SMInfo.ToListAsync();
        }

        // GET: api/SavingsManagerInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SavingsManagerInformation>> GetSavingsManagerInformation(int id)
        {
            var savingsManagerInformation = await _context.SMInfo.FindAsync(id);

            if (savingsManagerInformation == null)
            {
                return NotFound();
            }

            return savingsManagerInformation;
        }

        // PUT: api/SavingsManagerInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavingsManagerInformation(int id, SavingsManagerInformation savingsManagerInformation)
        {
            if (id != savingsManagerInformation.ID)
            {
                return BadRequest();
            }

            _context.Entry(savingsManagerInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavingsManagerInformationExists(id))
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

        // POST: api/SavingsManagerInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SavingsManagerInformation>> PostSavingsManagerInformation(SavingsManagerInformation savingsManagerInformation)
        {
            _context.SMInfo.Add(savingsManagerInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSavingsManagerInformation", new { id = savingsManagerInformation.ID }, savingsManagerInformation);
        }

        // DELETE: api/SavingsManagerInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavingsManagerInformation(int id)
        {
            var savingsManagerInformation = await _context.SMInfo.FindAsync(id);
            if (savingsManagerInformation == null)
            {
                return NotFound();
            }

            _context.SMInfo.Remove(savingsManagerInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SavingsManagerInformationExists(int id)
        {
            return _context.SMInfo.Any(e => e.ID == id);
        }
    }
}
