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
    public class UserIncomesController : ControllerBase
    {
        private readonly IIncomeService service;
        public UserIncomesController(IIncomeService service)
        {
            this.service = service;
        }

        // GET: api/UserBalance
        [HttpGet]
        public async Task<List<UserIncome>> GetBMInfo()
        {
            var all = await service.GetAll();
            return all;
        }

        // GET: api/UserBalance/5
        [HttpGet("{id}")]
        public async Task<UserIncome> GetUserIncome(int ID)
        {
            var byID = await service.GetByID(ID);
            return byID;

        }

        // PUT: api/ExpensesManagerInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserIncome(int ID, UserIncome userIncome)
        {
            if (ID != userIncome.ID)
                return BadRequest();
            await service.Edit(userIncome, ID);
            return NoContent();
        }

        // POST: api/ExpensesManagerInformations
        [HttpPost]
        public async Task<ActionResult<UserIncome>> PostUserIncome(UserIncome userIncome)
        {
            await service.Add(userIncome);
            return NoContent();
        }
    }
}

