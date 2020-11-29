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
    public class UserInformationsController : ControllerBase
    {
        private readonly UserContext _context;

        public UserInformationsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInformation>>> GetUserInformation()
        {
            return await _context.UserInformation.ToListAsync();
        }

        // GET: api/UserInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInformation>> GetUser(int id)
        {
            var userInformation = await _context.UserInformation.FindAsync(id);

            if (userInformation == null)
            {
                return NotFound();
            }

            return userInformation;
        }

        // PUT: api/UserInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserInformation userInformation)
        {
            if (id != userInformation.ID)
            {
                return BadRequest();
            }

            _context.Entry(userInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/UserInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserInformation>> PostUser(UserInformation userInformation)
        {
            _context.UserInformation.Add(userInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInformation", new { id = userInformation.ID }, userInformation);
        }

        // DELETE: api/UserInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userInformation = await _context.UserInformation.FindAsync(id);
            if (userInformation == null)
            {
                return NotFound();
            }

            _context.UserInformation.Remove(userInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.UserInformation.Any(e => e.ID == id);
        }
    }
}
