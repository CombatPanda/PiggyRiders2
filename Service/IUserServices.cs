using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service
{
    public interface IUserServices
    {

        Task<ServiceResponse<List<UserInformation>>> AddUser(UserInformation newUser);
        Task<UserInformation> CheckUser(UserInformation newUser);

    }
}
