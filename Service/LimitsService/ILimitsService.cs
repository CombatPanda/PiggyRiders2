using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSaver.Contexts;
using SmartSaver.Models;

namespace SmartSaver.Services
{
   public  interface ILimitsService
    {
        Task<List<ExpensesManagerInformation>> GetAll();
        Task<ExpensesManagerInformation> GetById(int id);
        Task Edit(ExpensesManagerInformation expense, int id);
        Task Add(ExpensesManagerInformation expense);
        Task Delete(int id);

    }
}
