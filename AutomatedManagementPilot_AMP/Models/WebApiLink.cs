using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class WebApiLink
    {
        public int id { get; set; }
        public string type { get; set; }
        public int source { get; set; }
        public int target { get; set; }

        public static explicit operator WebApiLink(Link link)
        {
            return new WebApiLink
            {
                id = link.Id,
                type = link.Type,
                source = link.SourceJobId,
                target = link.TargetJobId
            };
        }

        public static explicit operator Link(WebApiLink link)
        {
            return new Link
            {
                Id = link.id,
                Type = link.type,
                SourceJobId = link.source,
                TargetJobId = link.target
            };
        }
    }
}
