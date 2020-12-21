using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.BalanceService
{
    public interface IBalanceService
    {
        Task<ServiceResponse<List<UserBalance>>> GetAllBalances();
         Task<ServiceResponse<UserBalance>> GetBalanceByUserId(int id);
        Task<ServiceResponse<UserBalance>> UpdateBalance(UserBalance updatedBalance);
    }
}
