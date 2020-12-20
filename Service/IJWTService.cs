﻿using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service
{
    public interface IJWTService
    {
        string GenerateJSONWebToken(UserInformation userInfo);
       UserInformation AuthenticateUserAsync(UserInformation login);


    }
}