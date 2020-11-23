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
        public async Task<List<UserInformation>> GetUser()
        {
            using (UserContext db = new UserContext())
            {
                return await (from a in db.UserInformation.AsNoTracking()
                              select new UserInformation
                              {
                                  ID = a.ID,
                                  Username = a.Username,
                                  Password = a.Password,
                                  Email = a.Email,
                              }).ToListAsync();
            }
        }

        public async Task<bool> SaveUser(UserInformation user)
        {
            using (UserContext db = new UserContext())
            {
                var usr = db.UserInformation
                    .Where(x => x.ID == user.ID).FirstOrDefault<UserInformation>();
                if (usr == null)
                {
                    usr = new UserInformation()
                    {
                        Username = usr.Username,
                        Password = usr.Password,
                        Email = usr.Email,
                    };
                    db.UserInformation.Add(usr);

                }
/*                else
                {
                    Username = usr.Username,
                    Password = usr.Password,
                    Email = UserInformation.Email,
                }*/

                return await db.SaveChangesAsync() >= 1;
            }
        }

        public async Task<bool> DeleteUser(int Id)
        {
            using (UserContext db = new UserContext())
            {
                var usr = db.UserInformation
                    .Where(x => x.ID == Id).FirstOrDefault<UserInformation>();
                if (usr != null)
                {
                    db.UserInformation.Remove(usr);
                }
                return await db.SaveChangesAsync() >= 1;
            }
        }
    }
}
