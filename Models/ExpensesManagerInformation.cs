using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_WEB.Models
{
    public class ExpensesManagerInformation
    {
        public int ID { get; set; }
        public int Spent { get; set; }
        public string Category { get; set; }
        public int Limit { get; set; }
        public int uID { get; set; }
    }
}
