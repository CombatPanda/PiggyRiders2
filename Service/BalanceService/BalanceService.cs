using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.BalanceService
{
    public class BalanceService : IBalanceService
    {
        private readonly UserContext _context;

        public BalanceService(UserContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<UserBalance>>> GetAllBalances()
        {
            ServiceResponse<List<UserBalance>> serviceResponse = new ServiceResponse<List<UserBalance>>();
            try
            {
                serviceResponse.Data = await _context.UserBalance.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserBalance>> GetBalanceByUserId(int id)
        {
            ServiceResponse<UserBalance> serviceResponse = new ServiceResponse<UserBalance>();
            try
            {
                serviceResponse.Data = await _context.UserBalance.FirstAsync(s => s.user_id == 1);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserBalance>> UpdateBalance(UserBalance updatedBalance)
        {
            ServiceResponse<UserBalance> serviceResponse = new ServiceResponse<UserBalance>();
            try {
                UserBalance userBalance = await _context.UserBalance.FirstAsync(s => s.user_id == 1);
                if (updatedBalance.add > 0)
                {
                    userBalance.balance += updatedBalance.add;
                }
                if (updatedBalance.remove > 0)
                {
                    userBalance.balance -= updatedBalance.remove;
                }
                await _context.SaveChangesAsync();
                serviceResponse.Data = userBalance;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
