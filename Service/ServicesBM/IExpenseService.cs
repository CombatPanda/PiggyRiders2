using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSaver.Contexts;
using SmartSaver.Models;

namespace SmartSaver.Service.ServicesBM
{
    public interface IExpenseService
    {
        Task<List<UserExpense>> GetAll();
        Task<UserExpense> GetByID(int ID);
        Task Edit(UserExpense expense, int ID);
        Task Add(UserExpense expense);
    }
}
