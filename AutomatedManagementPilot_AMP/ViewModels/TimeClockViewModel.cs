using AutomatedManagementPilot_AMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutomatedManagementPilot_AMP.ViewModels
{
    public class TimeClockViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public TimeClock TimeClock { get; set; }
        public IEnumerable<TimeClock> TimeClocks { get; set; }
        public ShopOrder ShopOrder { get; set; }
        public IEnumerable<ShopOrder> ShopOrders { get; set; }

        public Models.Task Task { get; set; }
        public IEnumerable<Models.Task> Tasks { get; set; }

        public SelectList TaskSelectList { get; set; }
        public string TaskId { get; set; }


    }
}
