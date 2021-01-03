using Microsoft.AspNetCore.Mvc;
using SmartSaver.Models;
using SmartSaver.Service;
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
        private readonly IJWTService _jWTService;

        public UserBalanceController(IBalanceService balanceService, IJWTService jWTService)
        {
            _balanceService = balanceService;
            _jWTService = jWTService;

        }
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<UserBalance>>> Get()
        {
            return Ok(await _balanceService.GetAllBalances());
        }*/
        [HttpGet]
        public async Task<ActionResult<UserBalance>> GetSingle()
        {
            ServiceResponse<UserBalance> response = await _balanceService.GetBalanceByUserId(_jWTService.GetID());
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBalance(UserBalance updatedBalance)
        {
            ServiceResponse<UserBalance> response = await _balanceService.UpdateBalance(updatedBalance, _jWTService.GetID());
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
