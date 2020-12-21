using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;

namespace SmartSaver.Services
{
    public class ExpensesService : ILimitsService
    {
        private readonly UserContext context;
        public ExpensesService(UserContext context)
        {
            this.context = context;
        }
        public async Task<List<ExpensesManagerInformation>> GetAll()
        {
            //cia reiketu iterpti, kad iesko pagal user id
            List<ExpensesManagerInformation> expenses = new List<ExpensesManagerInformation>();
            using(context)
            {
                expenses = await context.EMInfo.ToListAsync();
            }
            return expenses;
        }

        public async Task<ExpensesManagerInformation> GetById(int id)
        {
                var expense = context.EMInfo.SingleOrDefault(e => e.ID==id);
                return expense;
        }

        public async Task Edit(ExpensesManagerInformation expense, int id)      
        {
            context.Entry(expense).State = EntityState.Modified;
            try
            {
               await  context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
            
        }

        public async Task Add( ExpensesManagerInformation expense)
        {
            //cia reiketu iterpti User ID
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
            
                ExpensesManagerInformation limit = context.EMInfo.SingleOrDefault(l => l.Category == expense.Category); //cia reiketu patikrinti dar ir useri
                if (limit == null)
                {
                    var l = new ExpensesManagerInformation
                    {
                        Category = expense.Category,
                        Spent = expense.Spent,
                        Limit = null,
                        uID = 1
                    };
                    context.EMInfo.Add(l);
                }
                else
                {
                    limit.Spent += expense.Spent;
                }
                await context.SaveChangesAsync();
        }
    }
}
