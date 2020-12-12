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
            AddToLimitDB(expense.expenses, expense.expensesInfo);
            AddToBalanceDB(expense.expenses);
        }

        //reikia iterpti user id
        public void AddToLimitDB(int spent, string category)
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
        //reikia prideti userID
        public void AddToBalanceDB(int amount)
        {
            UserBalance balance = context.UserBalance.SingleOrDefault(b => b.user_id == 1);
            if (balance == null)
            {
                var b = new UserBalance
                {
                    balance = -amount,
                    user_id = 1
                };
                context.UserBalance.Add(b);
            }
            else
            {
                balance.balance -= amount;
            }
            context.SaveChanges();
        }
    }

}
