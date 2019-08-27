using AutomatedManagementPilot_AMP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.ViewModels
{
    public class ReportViewModel
    {
        [Display(Name = "Employee UserName")]
        public Employee Employee { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        [Display(Name = "Machine Id")]
        public Machine Machine { get; set; }
        public IEnumerable<Machine> Machines { get; set; }

        [Display(Name = "Shop Order Number")]
        public ShopOrder ShopOrder { get; set; }
        public IEnumerable<ShopOrder> shopOrdersWithTime { get; set; }
        public IEnumerable<ShopOrder> ShopOrders { get; set; }

        [Display(Name = "Time Clock Id")]
        public TimeClock TimeClock  { get; set; }
        public IEnumerable<TimeClock> TimeClocks { get; set; }

        public string Report { get; set; }
    }
}
