using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using SmartSaver.Services;

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
        public async Task<List<ExpensesManagerInformation>> GetEMInfo()
        {
            ExpensesServices service = new ExpensesServices();
            var all = await service.GetAll(_context);
            return all;
        }

        // GET: api/ExpensesManagerInformations/5
        [HttpGet("{id}")]
        public async Task<ExpensesManagerInformation> GetExpensesManagerInformation(int id)
        {
            ExpensesServices service = new ExpensesServices();
            var byId = await service.GetById(_context, id);
            return byId;

        }

        // PUT: api/ExpensesManagerInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpensesManagerInformation(int id, ExpensesManagerInformation expensesManagerInformation)
        {
            if (id != expensesManagerInformation.ID)
                return BadRequest();

            ExpensesServices service = new ExpensesServices();
            await service.Edit(_context, expensesManagerInformation, id);
            return NoContent();
        }

        // POST: api/ExpensesManagerInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpensesManagerInformation>> PostExpensesManagerInformation(ExpensesManagerInformation expensesManagerInformation)
        {
            ExpensesServices service = new ExpensesServices();
            await service.Add(_context, expensesManagerInformation);
            return NoContent();
        }

            // DELETE: api/ExpensesManagerInformations/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteExpensesManagerInformation(int id)
            {
                if (await _context.EMInfo.FindAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    ExpensesServices service = new ExpensesServices();
                    await service.Delete(_context, id);
                    return NoContent();
                }
            }
        }


    }
