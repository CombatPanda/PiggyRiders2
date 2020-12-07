using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.ServicesBM
{
    public class ExpenseService : IExpenseService
    {
        private readonly UserContext context;
        public ExpenseService(UserContext context)
        {
            this.context = context;
        }
        public async Task<List<UserExpense>> GetAll()
        {
            //cia reiketu iterpti, kad iesko pagal user id
            List<UserExpense> expense = new List<UserExpense>();
            using (context)
            {
                expense = await context.UserExpense.ToListAsync();
            }
            return expense;
        }

        public async Task<UserExpense> GetByID(int ID)
        {
            var expense = await context.UserExpense.FirstOrDefaultAsync(e => e.ID == ID);
            if (expense == null)
                return null;
            else return expense;

        }

        public async Task Edit(UserExpense expense, int ID)
        {
            context.Entry(expense).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }

        public async Task Add(UserExpense expense)
        {
            //cia reiketu iterpti User ID
            context.UserExpense.Add(expense);
            await context.SaveChangesAsync();
        }

        //is budget trackerio
        //reikia iterpti user id
        public void AddToDB(int amount, string info)
        {
            var l = new UserExpense
            {
                expenses = amount,
                expensesInfo = info,
                userID = 1
            };
            context.UserExpense.Add(l);
            context.SaveChanges();
        }
    }
}
