using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSaver.Contexts;
using SmartSaver.Models;

namespace SmartSaver.Service.ServicesBM
{
    public interface IIncomeService
    {
        Task<List<UserIncome>> GetAll();
        Task<UserIncome> GetByID(int ID);
        Task Edit(UserIncome income, int ID);
        Task Add(UserIncome income);
    }
}
