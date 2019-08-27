using AutomatedManagementPilot_AMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.ViewModels
{
    public class MachineShopOrderViewModel
    {
        public Machine Machine { get; set; }
        public IEnumerable<Machine> Machines { get; set; }
        public ShopOrder ShopOrder { get; set; }
        public IEnumerable<ShopOrder> ShopOrders { get; set; }

        public Employee Employee { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
         public TimeClock TimeClock { get; set; }
        public IEnumerable<TimeClock> TimeClocks { get; set; }


    }
}
