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

        public async Task<ServiceResponse<List<UserAchievement>>> GetAllAchievements()
        {
            ServiceResponse<List<UserAchievement>> serviceResponse = new ServiceResponse<List<UserAchievement>>();
            serviceResponse.Data = await _context.UserAchievement.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserAchievement>> GetAchievmenetsById(int id)
        {
            ServiceResponse<UserAchievement> serviceResponse = new ServiceResponse<UserAchievement>();
            serviceResponse.Data = await _context.UserAchievement.FindAsync(id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserAchievement>> UpdateAchievement(UserAchievement updatedAchievement)
        {
            ServiceResponse<UserAchievement> serviceResponse = new ServiceResponse<UserAchievement>();
            try {

            UserAchievement UserAchievement = await _context.UserAchievement.FindAsync(updatedAchievement.ID);
                UserAchievement.Name = updatedAchievement.Name;
                UserAchievement.Description = updatedAchievement.Description;
                UserAchievement.Status = updatedAchievement.Status;
            await _context.SaveChangesAsync();
            serviceResponse.Data = UserAchievement;
            }
            catch (Exception ex) {
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
