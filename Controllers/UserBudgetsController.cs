using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSaver.Models;
using SmartSaver.Service.ServicesBM;

namespace SmartSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBudgetsController : ControllerBase
    {
        private readonly IBudgetService service;
        public UserBudgetsController(IBudgetService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<UserBudget>> GetBMInfo()
        {
            var all = await service.GetAll();
            return all;
        }

        [HttpPost]
        public async Task<ActionResult<UserBudget>> PostUserIncome(UserBudget budget)
        {
            await service.Add(budget);
            return NoContent();
        }
    }
}
