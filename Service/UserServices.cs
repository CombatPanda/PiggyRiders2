using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service
{
    public class UserServices : IUserServices
    {
        public static UserInformation user;
        private readonly UserContext _context;

        public UserServices(UserContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<UserInformation>>> AddUser(UserInformation newUser)
        {
            ServiceResponse<List<UserInformation>> serviceResponse = new ServiceResponse<List<UserInformation>>();

            if (UsernameExists(newUser.Username) || EmailExists(newUser.Email))
            {
                serviceResponse.Success = false;
                return serviceResponse;

            }
            else
            {
                UserBalance userBalance = new UserBalance();
                userBalance.user_id = newUser.ID;


                _context.UserInfo.Add(newUser);
                _context.UserBalance.Add(userBalance);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.UserInfo.ToListAsync();
                return serviceResponse;
            }

        }

        public async Task<UserInformation> CheckUser(UserInformation newUser)
        {
            return _context.UserInfo.Where(e => e.Email == newUser.Email && e.Password == newUser.Password).FirstOrDefault();

        }



        private bool UsernameExists(string username)
        {
            return _context.UserInfo.Any(e => e.Username == username);
        }

        private bool EmailExists(string email)
        {
            return _context.UserInfo.Any(e => e.Email == email);
        }
    }


}