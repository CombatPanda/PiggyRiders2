﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Models
{
    public class UserBalance
    {
        public int ID { get; set; }
        public int balance { get; set; } = 0;
        public int add { get; set; } = 0;
        public int remove { get; set; } = 0;
        public string user_id { get; set; } 
    }
}
