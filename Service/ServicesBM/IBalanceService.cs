using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSaver.Contexts;
using SmartSaver.Models;

namespace SmartSaver.Service.ServicesBM
{
    public interface IBalanceServices
    {
        Task<List<UserBalance>> GetAll();
        Task<UserBalance> GetByID(int ID);
        Task Edit(UserBalance balance, int ID);
        Task Add(UserBalance balance);
    }
}
