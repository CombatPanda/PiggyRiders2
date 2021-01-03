using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.AchievementService
{
    public class AchievementCompleter
    {
      

       static public async Task completeAchievementAsync(UserContext _context, UserAchievement ach)
        {
            var allAchievements = await _context.UserAchievement.ToListAsync(); // visi achievmentai
            ExpensesManagerInformation expensesManagerInformation = await _context.EMInfo.FindAsync(1); // spent, limit
            SavingsManagerInformation savingsManagerInformation = await _context.SMInfo.FindAsync(1); // savingsManagerInformation.Purpose
            var savingsManagerInformationList = await _context.SMInfo.ToListAsync();
            UserBalance userBalance = await _context.UserBalance.FindAsync(1); // UserBalance.balance UserBalance.user_id
            var userBalanceList = await _context.UserBalance.ToListAsync();
            UserBudget userBudget = await _context.UserBudget.FindAsync(1); // UserBudget.amount ToListAsync?
            var userBudgetList = await _context.UserBudget.ToListAsync();
            UserInformation userInformation = await _context.UserInfo.FindAsync(1); // ID username

            int count = 0;
            if (ach.ID == 1 && userInformation.Username != null)
            {
                ach.Status = 1;
            }
            foreach (SavingsManagerInformation smi in savingsManagerInformationList)
            {
                if (ach.ID == 2 && smi.Purpose != null)
                {
                    ach.Status = 1;
                }
            }
            foreach (UserBalance bal in userBalanceList)
            {
                if (ach.ID == 3 && bal.balance > 0 && userBalance.ID != null)
                {
                    ach.Status = 1;
                }
            }
            foreach (UserBudget bud in userBudgetList)
            {
                if (ach.ID == 4 && bud.amount > 0)
                {
                    ach.Status = 1;
                }
            }
            foreach (UserBudget bud in userBudgetList)
            {
                if (ach.ID == 5 && bud.amount < 0)
                {
                    ach.Status = 1;
                }
            }
            foreach (SavingsManagerInformation smi in savingsManagerInformationList)
            {
                count++;
                if (ach.ID == 6 && count >= 3)
                {
                    ach.Status = 1;
                    count = 0;
                }
            }
            foreach (SavingsManagerInformation smi in savingsManagerInformationList)
            {
                if (ach.ID == 7 && smi.Status == "Completed")
                {
                    ach.Status = 1;
                }
            }

            foreach (SavingsManagerInformation smi in savingsManagerInformationList)
            {
                if (smi.Status == "Completed")
                {
                    count++;
                }
                if (ach.ID == 8 && count >= 3)
                {
                    ach.Status = 1;
                    count = 0;
                }
            }

        }
    }
}
