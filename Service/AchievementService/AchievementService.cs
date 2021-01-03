using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.AchievementService
{
    public class AchievementService : IAchievementService
    {
        private readonly UserContext _context;

        public AchievementService(UserContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<UserAchievement>>> GetAllAchievements(string id)
        {
            ServiceResponse<List<UserAchievement>> serviceResponse = new ServiceResponse<List<UserAchievement>>();
            serviceResponse.Data = await _context.UserAchievement.Where(s => s.userID.ToString() == id).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserAchievement>> GetAchievmenetsById(int id)
        {
            ServiceResponse<UserAchievement> serviceResponse = new ServiceResponse<UserAchievement>();
            serviceResponse.Data = await _context.UserAchievement.FindAsync(id);
            return serviceResponse;
        }
     
        public async Task<ServiceResponse<UserAchievement>> UpdateAchievement(string id)
        {
            int score = 0;
            ServiceResponse<UserAchievement> serviceResponse = new ServiceResponse<UserAchievement>();
            try
            {
                AchievementCompleter Completer = new AchievementCompleter();
                UserInformation userInformation = await _context.UserInfo.Where(s => s.ID.ToString() == id).FirstOrDefaultAsync();
                UserAchievement UserAchievement = await _context.UserAchievement.Where(s => s.userID.ToString() == id).FirstOrDefaultAsync();
                userInformation.Score = score;
                var allAchievements = await _context.UserAchievement.Where(s => s.userID.ToString() == id).ToListAsync(); // visi achievmentai
                foreach (UserAchievement ach in allAchievements)
                {
                    await Completer.completeAchievementAsync(_context, ach, id);
                   
                }
                await Completer.CalculateScore(_context, id);
                await _context.SaveChangesAsync();
                serviceResponse.Data = UserAchievement;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        private bool UserAchievementExists(int id)
        {
            return _context.UserAchievement.Any(e => e.ID == id);
        }
    }
}
