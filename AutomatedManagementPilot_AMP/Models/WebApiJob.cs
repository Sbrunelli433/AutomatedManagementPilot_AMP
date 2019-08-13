using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class WebApiJob
    {
        public int id { get; set; }
        public string text { get; set; }
        public string customer { get; set; }
        public string part { get; set; }
        public int order_quantity { get; set; }
        public string start_date { get; set; }
        public int duration { get; set; }
        
        public decimal progress { get; set; }
        public int? parent { get; set; }
        public string type { get; set; }
        public string target { get; set; }
        [ForeignKey("EmployeeId")]
        public int? employeeId { get; set; }
        public Employee Employee { get; set; }


        [ForeignKey("MachineId")]
        public int? machineId { get; set; }
        public Machine Machine { get; set; }

        public bool open
        {
            get { return true; }
            set { }
        }

        public static explicit operator WebApiJob(Job job )
        {
            return new WebApiJob
            {
                id = job.Id,
                text = job.Text,
                customer = job.Customer,
                part = job.Part,
                order_quantity = job.OrderQuantity,
                start_date = job.StartDate.ToString("yyyy-MM-dd HH:mm"),
                duration = job.Duration,
                parent = job.ParentId,
                type = job.Type,
                progress = job.Progress,
                employeeId = job.EmployeeId, 
                machineId = job.MachineId
            };
        }

        public static explicit operator Job(WebApiJob job)
        {
            return new Job
            {
                Id = job.id,
                Text = job.text,
                Customer = job.customer,
                Part = job.part,
                OrderQuantity = job.order_quantity,
                StartDate = DateTime.Parse(job.start_date,
                    System.Globalization.CultureInfo.InvariantCulture),
                Duration = job.duration,
                ParentId = job.parent,
                Type = job.type,
                Progress = job.progress,
                EmployeeId = job.employeeId,
                MachineId = job.machineId
            };
        }

    }
}
