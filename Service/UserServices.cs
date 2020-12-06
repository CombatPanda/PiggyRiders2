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

        public async Task<List<UserInformation>> GetUser(UserInformation user)
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
    }
}
