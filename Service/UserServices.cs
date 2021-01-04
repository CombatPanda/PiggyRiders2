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
                UserAchievement userAchievement = new UserAchievement();

                _context.UserInfo.Add(newUser);
                _context.UserBalance.Add(userBalance);
                await _context.SaveChangesAsync();
                userBalance.user_id = (_context.UserInfo.Where(e => e.Email == newUser.Email && e.Password == newUser.Password).FirstOrDefault()).ID.ToString();
                _context.UserBalance.Add(userBalance);

                userAchievement.userID = (_context.UserInfo.Where(e => e.Email == newUser.Email && e.Password == newUser.Password).FirstOrDefault()).ID;
                _context.UserAchievement.Add(new UserAchievement { Nr = 1, Name = "Register", Description = "Create an account", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 2, Name = "Baby Steps", Description = "Create your first item to save for", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 3, Name = "Profiting", Description = "Have more income than expenses", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 4, Name = "Gains", Description = "Add some income", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 5, Name = "Losses", Description = "Add some expenses", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 6, Name = "Getting Started", Description = "Have three saving goals", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 7, Name = "Completed!", Description = "Complete one saving goal", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 8, Name = "Progress", Description = "Complete three saving goals", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 9, Name = "Keep going", Description = "Complete five saving goals", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 10, Name = "Nice job", Description = "Complete ten saving goals", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 11, Name = "Great job", Description = "Complete twenty five saving goals", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 12, Name = "Awesome", Description = "Complete fifty saving goals", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 13, Name = "Incredible", Description = "Complete a hundred saving goals", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 14, Name = "Profiting 2x", Description = "Have twice as much income than expenses", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 15, Name = "Making Cash", Description = "Have five times as much income than expenses", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 16, Name = "Big Dreams", Description = "Have ten saving goals submitted", Status = 0, Score = 10, userID = userAchievement.userID });
                _context.UserAchievement.Add(new UserAchievement { Nr = 17, Name = "Only Wishes", Description = "Have fifteen saving goals submitted", Status = 0, Score = 10, userID = userAchievement.userID });
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

        //Barto
        public async Task<ServiceResponse<List<UserInformation>>> GetAllUsers()
        {
            ServiceResponse<List<UserInformation>> serviceResponse = new ServiceResponse<List<UserInformation>>();
            serviceResponse.Data = await _context.UserInfo.ToListAsync();
            return serviceResponse;
        }
    }


}