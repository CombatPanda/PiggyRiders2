using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.SavingService
{
    public class StatusSetter
    {
        public string SetStatus(int savedAmount, int cost)
        {
            if (savedAmount > 0 && savedAmount < cost)
            {
                return "In progress";
            }
            else if (savedAmount >= cost)
            {
                return "Completed";
            }
            else return "Not Started";
        }
    }
}
