using Microsoft.AspNetCore.Mvc;
using SmartSaver.Models;
using SmartSaver.Service.BalanceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public UserBalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBalance>>> Get()
        {
            return Ok(await _balanceService.GetAllBalances());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBalance>> GetSingle(int id)
        {
            ServiceResponse<UserBalance> response = await _balanceService.GetBalanceByUserId(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBalance(UserBalance updatedBalance, int id)
        {
            ServiceResponse<UserBalance> response = await _balanceService.UpdateBalance(updatedBalance);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
