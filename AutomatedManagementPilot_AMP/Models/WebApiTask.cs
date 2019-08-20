using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class WebApiTask
    {
        public int id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public int duration { get; set; }
        public decimal progress { get; set; }
        public int? parent { get; set; }
        public string type { get; set; }
        public string target { get; set; }
        public int sort_order { get; set; }
        public string description { get; set; }
        public string machine { get; set; }
        public string customer { get; set; }
        public string employee { get; set; }
        public string part_name { get; set; }
        public decimal shop_order_number { get; set; }
        public int order_quantity { get; set; }
        public bool open
        {
            get { return true; }
            set { }
        }

        public static explicit operator WebApiTask(Task task)
        {
            return new WebApiTask
            {
                id = task.Id,
                text = task.Text,
                start_date = task.StartDate.ToString("yyyy-MM-dd HH:mm"),
                duration = task.Duration,
                parent = task.ParentId,
                type = task.Type,
                progress = task.Progress,
                sort_order = task.SortOrder,
                description = task.Description,
                machine = task.Machine,
                customer = task.Customer,
                employee = task.Employee,
                part_name = task.PartName,
                shop_order_number = task.ShopOrderNumber,
                order_quantity = task.OrderQuantity
                
            };
        }

        public static explicit operator Task(WebApiTask task)
        {
            return new Task
            {
                Id = task.id,
                Text = task.text,
                StartDate = DateTime.Parse(task.start_date,
                    System.Globalization.CultureInfo.InvariantCulture),
                Duration = task.duration,
                ParentId = task.parent,
                Type = task.type,
                Progress = task.progress,
                SortOrder = task.sort_order,
                Description = task.description,
                Machine = task.machine,
                Customer = task.customer,
                Employee = task.employee,
                PartName = task.part_name,
                ShopOrderNumber = task.shop_order_number,
                OrderQuantity = task.order_quantity
            };
        }
    }
}
