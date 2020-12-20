using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;

namespace SmartSaver.Service.ServicesBM
{
    public class BudgetService : IBudgetService
    {
        private readonly UserContext context;
        public BudgetService(UserContext context)
        {
            this.context = context;
        }
        public async Task Add(UserBudget budget)
        {
           context.UserBudget.Add(budget);
           await context.SaveChangesAsync();
        }

        public async Task<List<UserBudget>> GetAll()
        {
            List<UserBudget> budget = new List<UserBudget>();
            using (context)
            {
                budget = await context.UserBudget.ToListAsync();
            }
            return budget;
        }
        public void AddToBalanceDB(int amount)
        {
            UserBalance balance = context.UserBalance.SingleOrDefault(b => b.user_id == 1);
            if (balance == null)
            {
                var b = new UserBalance
                {
                    balance = amount,
                    user_id = 1
                };
                context.UserBalance.Add(b);
            }
            else
            {
                balance.balance += amount;
            }
            context.SaveChanges();
        }
    }
}
