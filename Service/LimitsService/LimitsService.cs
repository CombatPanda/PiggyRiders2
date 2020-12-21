using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;

namespace SmartSaver.Services
{
    public class LimitsService : ILimitsService
    {
        private readonly UserContext context;
        public LimitsService(UserContext context)
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
            var expense = await context.EMInfo.FirstOrDefaultAsync(e => e.ID == id);
            if (expense == null)
                return null;
            else return expense;

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
       
        //is budget trackerio
        //reikia iterpti user id
        public void AddToDB(int spent, string category)
        {
            ExpensesManagerInformation limit = context.EMInfo.SingleOrDefault(l => l.Category == category); //cia reiketu patikrinti dar ir useri
            if (limit == null)
            {
                var l = new ExpensesManagerInformation
                {
                    Category = category,
                    Spent = spent,
                    Limit = null,
                    uID = 1
                };
                context.EMInfo.Add(l);
            }
            else
            {
                limit.Spent += spent;
            }
            context.SaveChanges();
        }
    }
}
