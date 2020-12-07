using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.ServicesBM
{
    public class BalanceService
    {
        private readonly UserContext context;
        public BalanceService(UserContext context)
        {
            this.context = context;
        }
        public async Task<List<UserBalance>> GetAll()
        {
            //cia reiketu iterpti, kad iesko pagal user id
            List<UserBalance> balance = new List<UserBalance>();
            using (context)
            {
                balance = await context.UserBalance.ToListAsync();
            }
            return balance;
        }

        public async Task<UserBalance> GetByID(int ID)
        {
            var balance = await context.UserBalance.FirstOrDefaultAsync(e => e.ID == ID);
            if (balance == null)
                return null;
            else return balance;

        }

        public async Task Edit(UserBalance balance, int ID)
        {
            context.Entry(balance).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }

        public async Task Add(UserBalance balance)
        {
            //cia reiketu iterpti User ID
            context.UserBalance.Add(balance);
            await context.SaveChangesAsync();
        }

        //is budget trackerio
        //reikia iterpti user id
        public void AddToDB(int amount)
        {
            var l = new UserBalance
            {
                balance = amount,
                user_id = 1
            };
            context.UserBalance.Add(l);
            context.SaveChanges();
        }
    }
}
