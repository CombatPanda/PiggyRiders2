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
                _context.UserInfo.Add(newUser);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.UserInfo.ToListAsync();
                return serviceResponse;
            }

        }

        public async Task<ServiceResponse<UserInformation>> GetUser(string email,string password)
        {
            ServiceResponse<UserInformation> serviceResponse = new ServiceResponse<UserInformation>();
            if (EmailExists(email))
            {
               
                serviceResponse.Data = _context.UserInfo.Where(e => e.Email == email && e.Password == password).FirstOrDefault<UserInformation>();
                serviceResponse.Message = "Loggin was successful";
                return serviceResponse;
            }
            else
            {
                serviceResponse.Success = false;
                return serviceResponse;
            }

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


    /*        public async Task<List<UserInformation>> GetUser(UserInformation user)
            {
                using (UserContext db = new UserContext())
                {
                    return await (from a in db.UserInfo.AsNoTracking()
                                  select new UserInformation
                                  {
                                      Password = a.Password,
                                      Email = a.Email,
                                  }).ToListAsync();
                }
            }

            public async Task<bool> SaveUser(UserInformation user)
            {
                using (UserContext db = new UserContext())
                {
                    var usr = db.UserInfo
                        .Where(b => b.Username == user.Username
                        && b.Password == user.Password).FirstOrDefault<UserInformation>();
                    if (usr == null)
                    {
                        var newUser = new UserInformation()
                        {
                            Username = user.Username,
                            Password = user.Password,
                            Email = user.Email,
                        };
                        db.UserInfo.Add(newUser);

                    }
                    return await db.SaveChangesAsync() >= 1;
                }
            }

            public async Task<bool> DeleteUser(int Id)
            {
                using (UserContext db = new UserContext())
                {
                    var usr = db.UserInfo
                        .Where(x => x.ID == Id).FirstOrDefault<UserInformation>();
                    if (usr != null)
                    {
                        db.UserInfo.Remove(usr);
                    }
                    return await db.SaveChangesAsync() >= 1;
                }
            }
        }*/
}
