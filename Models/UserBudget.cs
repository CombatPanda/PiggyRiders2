using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Models
{
    public class UserBudget
    {
        public int ID { get; set; }
        public int amount { get; set; }
        public string text { get; set; }
        public int userID { get; set; }
    }
}
