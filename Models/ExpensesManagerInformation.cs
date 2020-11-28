using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Models
{
    public class ExpensesManagerInformation
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public Nullable<int> Spent { get; set; }
        public Nullable<int> Limit { get; set; }
        public int uID { get; set; }
    }
}
