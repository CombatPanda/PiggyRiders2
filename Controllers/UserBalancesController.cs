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
    public class UserBalanceController : ControllerBase
    {
        private readonly IBalanceServices service;
        public UserBalanceController(IBalanceServices service)
        {
            this.service = service;
        }

        // GET: api/UserBalance
        [HttpGet]
        public async Task<List<UserBalance>> GetBMInfo()
        {
            var all = await service.GetAll();
            return all;
        }

        // GET: api/UserBalance/5
        [HttpGet("{id}")]
        public async Task<UserBalance> GetUserBalance(int ID)
        {
            var byID = await service.GetByID(ID);
            return byID;

        }

        // PUT: api/ExpensesManagerInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBalance(int ID, UserBalance userBalance)
        {
            if (ID != userBalance.ID)
                return BadRequest();
            await service.Edit(userBalance, ID);
            return NoContent();
        }

        // POST: api/ExpensesManagerInformations
        [HttpPost]
        public async Task<ActionResult<UserBalance>> PostUserBalance (UserBalance userBalance)
        {
            await service.Add(userBalance);
            return NoContent();
        }
    }


}
