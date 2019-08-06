using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatedManagementPilot_AMP.Data;
using Microsoft.EntityFrameworkCore;

namespace AutomatedManagementPilot_AMP.Models
{
    public static class GanttSeeder
    {


        public static void Seed(ApplicationDbContext context)
        {
            if (context.Jobs.Any())
            {
                return;   // DB has been seeded
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                List<Job> jobs = new List<Job>()
               {
                  new Job()
                    {
                       Id = 1,
                       Text = "Terrill Inc.",
                       Customer = "Terrill Inc.",
                       Part = "Widget",
                       OrderQuantity = 10000,
                       StartDate = DateTime.Today.AddDays(-3),
                       Duration = 10,
                       Progress = 0.4m,
                       ParentId = null,
                       MachineId = null
                    },

                    new Job()
                    {
                       Id = 2,
                       Text = "Operation: Set Up",
                       
                       Customer = null,
                       Part = null,
                       OrderQuantity = 0,
                       StartDate = DateTime.Today.AddDays(-2),
                       Duration = 1,
                       Progress = 1,
                       ParentId = 1,
                       MachineId = 01
                    },


                    new Job()
                    {
                       Id = 3,
                       Text = "Operation: Production",
                       Customer = null,
                       Part = null,
                       OrderQuantity = 10000,
                       StartDate = DateTime.Today.AddDays(-2),
                       Duration = 6,
                       Progress = 3,
                       ParentId = 2,
                       MachineId = 01
                    },

                    new Job()
                    {
                       Id = 4,
                       Text = "Operation: Tear Down",
                       Customer = null,
                       Part = null,
                       OrderQuantity = 0,
                       StartDate = DateTime.Today.AddDays(-2),
                       Duration = 1,
                       Progress = 0,
                       ParentId = 3,
                       MachineId = 01
                    },
               };

                jobs.ForEach(s => context.Jobs.Add(s));
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Jobs ON;");
                context.SaveChanges();

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Jobs OFF;");
                List<Link> links = new List<Link>()
               {
                   new Link() {Id = 1, SourceJobId = 1, TargetJobId = 2, Type = "1"},
                   new Link() {Id = 2, SourceJobId = 2, TargetJobId = 3, Type = "0"}
               };

                links.ForEach(s => context.Links.Add(s));
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Links ON;");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Links OFF;");
                transaction.Commit();
            }
        }
    }
}
