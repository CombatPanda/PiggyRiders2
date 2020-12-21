using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using SmartSaver.Service.AchievementService;

namespace SmartSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAchievementController : ControllerBase
    {
        private readonly IAchievementService _achievementService;

        public UserAchievementController(IAchievementService savingService)
        {
            _achievementService = savingService;
        }

        // GET: api/UserAchievement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAchievement>>> Get()
        {
            await _achievementService.UpdateAchievement();
            return Ok(await _achievementService.GetAllAchievements());
        }

        // GET: api/UserAchievement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAchievement>> GetSingle(int id)
        {
            return Ok(await _achievementService.GetAchievmenetsById(id));
        }

        // PUT: api/UserAchievement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> UpdateAchievement()
        {
            ServiceResponse<UserAchievement> response = await _achievementService.UpdateAchievement();
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }

}

