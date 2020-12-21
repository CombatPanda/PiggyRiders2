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
    }
}
