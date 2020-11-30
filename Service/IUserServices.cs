using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service
{
    interface IUserServices
    {
            Task<List<UserInformation>> GetUser();
            Task<bool> SaveUser(UserInformation contact);
            Task<bool> DeleteUser(int Id);

    }
}
