using Microsoft.EntityFrameworkCore;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<UserInformation> UserInfo { get; set; }
        public DbSet<ExpensesManagerInformation> EMInfo { get; set; }
        public DbSet<SavingsManagerInformation> SMInfo { get; set; }
        public DbSet<UserExpense> UserExpense { get; set; }
        public DbSet<UserBalance> UserBalance { get; set; }
        public DbSet<UserIncome> UserIncome { get; set; }
        public DbSet<ExpensesInformation> ExpensesInfo { get; set; }

        
    }
}
