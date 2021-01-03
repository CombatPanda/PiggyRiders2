using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSaver.Models;

namespace SmartSaver.Service.ServicesBM
{
    public interface IBudgetService
    {
        Task<List<UserBudget>> GetAll();
        Task Add(UserBudget budget);
        
        Task<int> GetExpenses();
        Task<int> GetIncomes();
    }
}
