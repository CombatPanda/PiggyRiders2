using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using SmartSaver.Service;

namespace SmartSaver.Services
{
    public class LimitsService : ILimitsService
    {
        private readonly UserContext context;
        private readonly IJWTService service;
        public LimitsService(UserContext context, IJWTService service)
        {
            this.context = context;
            this.service = service;

        }
        public async Task<List<ExpensesManagerInformation>> GetAll()
        {
            int user = UserID();
            List<ExpensesManagerInformation> expenses = new List<ExpensesManagerInformation>();
            using (context)
            {
                expenses = await context.EMInfo.Where(e=>e.uID==user).ToListAsync();
            }
            return expenses;
        }

        public async Task<ExpensesManagerInformation> GetById(int id)
        {
            var expense = context.EMInfo.SingleOrDefault(e => e.ID == id);
            return expense;
        }

        public async Task Edit(ExpensesManagerInformation expense, int id)      
        {
            int user = UserID();
            try
            {
                ExpensesManagerInformation limit = await context.EMInfo.FirstAsync(l => l.ID == id);
                limit.Limit = expense.Limit;
                limit.Spent = expense.Spent;
                limit.Category = expense.Category;
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Limit cannot be updated");
            }
        }

        public async Task Add( ExpensesManagerInformation expense)
        {
            int user = UserID();
            expense.uID = user;
            context.EMInfo.Add(expense);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var expense = await context.EMInfo.FindAsync(id);
            context.EMInfo.Remove(expense);
            await context.SaveChangesAsync();
        }
       
        public async Task EditFromBudgetManager(ExpensesManagerInformation expense)
        {
            int user = UserID();
                ExpensesManagerInformation limit = context.EMInfo.SingleOrDefault(l => l.Category == expense.Category); //cia reiketu patikrinti dar ir useri
                if (limit == null)
                {
                    var l = new ExpensesManagerInformation
                    {
                        Category = expense.Category,
                        Spent = expense.Spent,
                        Limit = null,
                        uID = user
                    };
                    context.EMInfo.Add(l);
                }
                else
                {
                    limit.Spent += expense.Spent;
                }
                await context.SaveChangesAsync();
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
