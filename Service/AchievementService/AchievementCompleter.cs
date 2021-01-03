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
        int score = 0;
        public async Task completeAchievementAsync(UserContext _context, UserAchievement ach)
        {

            var allAchievements = await _context.UserAchievement.ToListAsync(); // visi achievmentai
            ExpensesManagerInformation expensesManagerInformation = await _context.EMInfo.FindAsync(1); // spent, limit
            SavingsManagerInformation savingsManagerInformation = await _context.SMInfo.FindAsync(1); // savingsManagerInformation.Purpose
            var savingsManagerInformationList = await _context.SMInfo.ToListAsync();
            UserBalance userBalance = await _context.UserBalance.FindAsync(1); // UserBalance.balance UserBalance.user_id
            var userBalanceList = await _context.UserBalance.ToListAsync();
            UserBudget userBudget = await _context.UserBudget.FindAsync(1); // UserBudget.amount ToListAsync?
            var userBudgetList = await _context.UserBudget.ToListAsync();
            UserInformation userInformation = await _context.UserInfo.FindAsync(1); // ID username score

            int count = 0;
            int positive = 0;
            int negative = 0;
            if (ach.Nr == 1 && userInformation.Username != null)
            {
                ach.Status = 1;
            }
            foreach (SavingsManagerInformation smi in savingsManagerInformationList)
            {
                if (ach.Nr == 2 && smi.Purpose != null)
                {
                    ach.Status = 1;
                }
            }
            foreach (UserBalance bal in userBalanceList)
            {
                if (ach.Nr == 3 && bal.balance > 0 && userBalance.ID != null)
                {
                    ach.Status = 1;
                }
            }
            foreach (UserBudget bud in userBudgetList)
            {
                if (ach.Nr == 4 && bud.amount > 0)
                {
                    ach.Status = 1;
                }
            }
            foreach (UserBudget bud in userBudgetList)
            {
                if (ach.Nr == 5 && bud.amount < 0)
                {
                    ach.Status = 1;
                }
            }
            foreach (SavingsManagerInformation smi in savingsManagerInformationList)
            {
                count++;
                if (ach.Nr == 6 && count >= 3)
                {
                    ach.Status = 1;
                    count = 0;
                }
            }
            foreach (SavingsManagerInformation smi in savingsManagerInformationList)
            {
                if (ach.Nr == 7 && smi.Status == "Completed")
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
                if (ach.Nr == 8 && count >= 3)
                {
                    ach.Status = 1;
                    count = 0;
                }
                if (ach.Nr == 9 && count >= 5)
                {
                    ach.Status = 1;
                    count = 0;
                }
                if (ach.Nr == 10 && count >= 10)
                {
                    ach.Status = 1;
                    count = 0;
                }
                if (ach.Nr == 11 && count >= 25)
                {
                    ach.Status = 1;
                    count = 0;
                }
                if (ach.Nr == 12 && count >= 50)
                {
                    ach.Status = 1;
                    count = 0;
                }
                if (ach.Nr == 13 && count >= 100)
                {
                    ach.Status = 1;
                    count = 0;
                }
            }
            foreach (UserBalance bal in userBalanceList)
            {
                foreach (UserBalance bal2 in userBalanceList)
                {
                    if (bal2.balance > 0)
                    {
                        positive = positive + bal2.balance;
                    }
                    if (bal2.balance < 0)
                    {
                        negative = negative + bal2.balance;
                    }
                }
                if (ach.Nr == 14 && ((positive * 2) > negative * -1) && negative != 0)
                {
                    ach.Status = 1;
                }
                if (ach.Nr == 15 && ((positive * 5) > negative * -1) && negative != 0)
                {
                    ach.Status = 1;
                }
            }
            foreach (SavingsManagerInformation smi in savingsManagerInformationList)
            {
                foreach (SavingsManagerInformation smi2 in savingsManagerInformationList)
                {
                    if (smi2.Purpose != null)
                    {
                        count++;
                    }
                }
                if (ach.Nr == 16 && count >= 10)
                {
                    ach.Status = 1;
                }
                if (ach.Nr == 17 && count >= 15)
                {
                    ach.Status = 1;
                }
            }
        }
        public async Task CalculateScore(UserContext _context)
        {
            UserInformation userInformation = await _context.UserInfo.FindAsync(1);
            UserAchievement UserAchievement = await _context.UserAchievement.FindAsync(1);
            var allAchievements = await _context.UserAchievement.ToListAsync(); // visi achievmentai
            foreach (UserAchievement ach in allAchievements)
            {
                if(ach.Status == 1)
                {
                    score = score + ach.Score;
                }
            }
            userInformation.Score = score;
        }

    }
}
