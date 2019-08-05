using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class WebApiJob
    {
        public int id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public int duration { get; set; }
        public decimal progress { get; set; }
        public int? parent { get; set; }
        public string type { get; set; }
        public string target { get; set; }
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
                start_date = job.StartDate.ToString("yyyy-MM-dd HH:mm"),
                duration = job.Duration,
                parent = job.ParentId,
                type = job.Type,
                progress = job.Progress
            };
        }

        public static explicit operator Job(WebApiJob job)
        {
            return new Job
            {
                Id = job.id,
                Text = job.text,
                StartDate = DateTime.Parse(job.start_date,
                    System.Globalization.CultureInfo.InvariantCulture),
                Duration = job.duration,
                ParentId = job.parent,
                Type = job.type,
                Progress = job.progress
            };
        }

    }
}
