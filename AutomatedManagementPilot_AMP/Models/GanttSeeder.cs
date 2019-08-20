using AutomatedManagementPilot_AMP.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatedManagementPilot_AMP.Models
{
    public class GanttSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Tasks.Any())
            {
                return;   // DB has been seeded
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                List<Task> tasks = new List<Task>()
               {
                  new Task()
                    {
                       Id = 1,
                       Text = "Project #2",
                       ShopOrderNumber = 1.0m,
                       StartDate = DateTime.Today.AddHours(-3),
                       Duration = 10,
                       Progress = 0.4m,
                       ParentId = null,
                       Type = "Project",
                       Description = null,
                       Machine = null,
                       Customer = "Terrill Inc.",
                       Employee = null,
                       PartName = "Widget",
                       OrderQuantity = 10000
                    },
                    new Task()
                    {
                       Id = 2,
                       Text = "Operation: Setup",
                       ShopOrderNumber = 1.1m,
                       StartDate = DateTime.Today.AddHours(-1),
                       Duration = 1,
                       Progress = 1.0m,
                       ParentId = 1,
                       Type = "Task",
                       Description = null,
                       Machine = null,
                       Customer = "Terrill Inc.",
                       Employee = null,
                       PartName = "Widget",
                       OrderQuantity = 10000
                    },
                    new Task()
                    {
                       Id = 3,
                       Text = "Operation: Production",
                       ShopOrderNumber = 1.2m,
                       StartDate = DateTime.Today.AddHours(-8),
                       Duration = 8,
                       Progress = 0.5m,
                       ParentId = 2,
                       Type = "Task",
                       Description = null,
                       Machine = null,
                       Customer = "Terrill Inc.",
                       Employee = null,
                       PartName = "Widget",
                       OrderQuantity = 10000
                    },
                    new Task()
                    {
                       Id = 4,
                       Text = "Operation: Tear down",
                       ShopOrderNumber = 1.3m,
                       StartDate = DateTime.Today.AddHours(-1),
                       Duration = 1,
                       Progress = 0.0m,
                       ParentId = 3,
                       Type = "Task",
                       Description = null,
                       Machine = null,
                       Customer = "Terrill Inc.",
                       Employee = null,
                       PartName = "Widget",
                       OrderQuantity = 10000
                    }
               };

                tasks.ForEach(s => context.Tasks.Add(s));
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Tasks ON;");
                context.SaveChanges();

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Tasks OFF;");
                List<Link> links = new List<Link>()
               {
                   new Link() {Id = 1, SourceTaskId = 1, TargetTaskId = 2, Type = "1"},
                   new Link() {Id = 2, SourceTaskId = 2, TargetTaskId = 3, Type = "0"},
                   new Link() {Id = 3, SourceTaskId = 3, TargetTaskId = 4, Type = "0"}
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

