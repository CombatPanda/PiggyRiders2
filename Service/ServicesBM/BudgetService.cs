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
        private readonly IJWTService service;
        public BudgetService(UserContext context, IJWTService service)
        {
            this.context = context;
            this.service = service;
        }
        public async Task Add(UserBudget budget)
        {
           int user = UserID();
           budget.userID = user;
           context.UserBudget.Add(budget);
           await context.SaveChangesAsync();
        }

        public async Task<List<UserBudget>> GetAll()
        {
            int user = UserID();
            List<UserBudget> budget = new List<UserBudget>();
            using (context)
            {
                budget = await context.UserBudget.Where(b=>b.userID==user).ToListAsync();
            }
            return budget;
        }

        public async Task<int> GetExpenses()
        {
            int user = UserID();
            int expenses = 0;
            var items = context.UserBudget.Where(i => i.userID == user).ToList();
            foreach (var i in items)
            {
                if (i.amount < 0)
                    expenses += (i.amount * -1);
            }
           return expenses;
        }

        public async Task<int> GetIncomes()
        {
            int user = UserID();
            int incomes = 0;
            var items = context.UserBudget.Where(i => i.userID == user).ToList();
            foreach (var i in items)
            {
                if (i.amount > 0)
                    incomes += i.amount;
            }
            return incomes;
        }

        private int UserID()
        {
            int userID;
            bool convertable = Int32.TryParse(service.GetID(), out userID);
            if (convertable)
                return userID;
            else throw new Exception("Invalid user id");
        }
    }
}
