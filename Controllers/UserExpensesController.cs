using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using SmartSaver.Service.ServicesBM;
using SmartSaver.Services;

namespace SmartSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExpensesController : ControllerBase
    {
        private readonly IExpenseService service;
        public UserExpensesController(IExpenseService service)
        {
            this.service = service;
        }

        // GET: api/UserBalance
        [HttpGet]
        public async Task<List<UserExpense>> GetBMInfo()
        {
            var all = await service.GetAll();
            return all;
        }

        // GET: api/UserBalance/5
        [HttpGet("{id}")]
        public async Task<UserExpense> GetUserExpens(int ID)
        {
            var byID = await service.GetByID(ID);
            return byID;

        }

        // PUT: api/ExpensesManagerInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserExpense(int ID, UserExpense userExpense)
        {
            if (ID != userExpense.ID)
                return BadRequest();
            await service.Edit(userExpense, ID);
            return NoContent();
        }

        // POST: api/ExpensesManagerInformations
        [HttpPost]
        public async Task<ActionResult<UserBalance>> PostUserExpense(UserExpense userExpense)
        {
            await service.Add(userExpense);
            return NoContent();
        }
    }
}
