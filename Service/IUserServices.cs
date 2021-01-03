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
        Task<ServiceResponse<UserInformation>> GetUser(string email, string password);

        Task<ServiceResponse<List<UserInformation>>> GetAllUsers(); // WIP, man reikia gauti visus userius - Bartas

    }
}
