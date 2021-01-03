using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.AchievementService
{
    public interface IAchievementService
    {
        Task<ServiceResponse<List<UserAchievement>>> GetAllAchievements(string id);
        Task<ServiceResponse<UserAchievement>> GetAchievmenetsById(int id);
        Task<ServiceResponse<UserAchievement>> UpdateAchievement(string id);
    }
}
