using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using SmartSaver.Service;


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
        public async Task<ActionResult<IEnumerable<UserInformation>>> GetUserInfo()
        {
            return await _context.UserInfo.ToListAsync();
        }

        // GET: api/UserInformations/
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInformation>> GetUserInformation(int id, UserInformation userInformation)
        {
            UserServices userServices = new UserServices();
            await userServices.GetUser(userInformation);
            return userInformation;
            
            
/*            var userInformation = await _context.UserInfo.FindAsync(id);

            if (userInformation == null)
            {
                return NotFound();
            }

            return userInformation;*/
        }

        // PUT: api/UserInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInformation(int id, UserInformation userInformation)
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
                if (!UserInformationExists(id))
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
        public async Task<ActionResult<UserInformation>> PostUserInformation(UserInformation userInformation)
        {
            UserServices userServices = new UserServices();
            if(await userServices.SaveUser(userInformation))
            {
                return CreatedAtAction("GetUserInformation", new { id = userInformation.ID }, userInformation);
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE: api/UserInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInformation(int id)
        {
            var userInformation = await _context.UserInfo.FindAsync(id);
            if (userInformation == null)
            {
                return NotFound();
            }

            _context.UserInfo.Remove(userInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserInformationExists(int id)
        {
            return _context.UserInfo.Any(e => e.ID == id);
        }

    }
}
