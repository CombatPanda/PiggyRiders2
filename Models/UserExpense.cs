using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_WEB.Models
{
    public class UserExpense
    {
        public int ID { get; set; }
        public int expenses { get; set; }
        public string expensesInfo { get; set; }
        public int userID { get; set; }
    }
}
