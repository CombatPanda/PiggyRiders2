using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.ServicesBM
{
    public class IncomeService : IIncomeService
    {
        private readonly UserContext context;
        public IncomeService(UserContext context)
        {
            this.context = context;
        }
        public async Task<List<UserIncome>> GetAll()
        {
            //cia reiketu iterpti, kad iesko pagal user id
            List<UserIncome> income = new List<UserIncome>();
            using (context)
            {
                income = await context.UserIncome.ToListAsync();
            }
            return income;
        }

        public async Task<UserIncome> GetByID(int ID)
        {
            var income = await context.UserIncome.FirstOrDefaultAsync(e => e.ID == ID);
            if (income == null)
                return null;
            else return income;

        }

        public async Task Edit(UserIncome income, int ID)
        {
            context.Entry(income).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }

        public async Task Add(UserIncome income)
        {
            //cia reiketu iterpti User ID
            context.UserIncome.Add(income);
            await context.SaveChangesAsync();
            AddToBalanceDB(income.income);
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
