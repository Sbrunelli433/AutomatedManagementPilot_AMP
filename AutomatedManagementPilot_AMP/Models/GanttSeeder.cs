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
                        start_date = DateTime.Today.AddDays(-1),
                        Duration = 1,
                        Progress = 0.4m,
                        ParentId = null,
                        SortOrder = 0,
                        Type = "task",
                        Description = null,
                        Machine = null,
                        Customer = "Terrill Inc."
                    },
                    new Task()
                    {
                        Id = 2,
                        Text = "Task #1",
                        start_date = DateTime.Today.AddDays(-1),
                        Duration = 1,
                        Progress = 0.6m,
                        ParentId = 1,
                        SortOrder = 1,
                        Type = "task",
                        Description = null,
                        Machine = null,
                        Customer = "Terrill Inc."
                    },
                    new Task()
                    {
                        Id = 3,
                        Text = "Task #2",
                        start_date = DateTime.Today.AddDays(-1),
                        Duration = 1,
                        Progress = 0.6m,
                        ParentId = 2,
                        SortOrder = 2,
                        Type = "task",
                        Description = null,
                        Machine = null,
                        Customer = "Terrill Inc."
                    },
                    new Task()
                    {
                        Id = 4,
                        Text = "Task #3",
                        start_date = DateTime.Today.AddDays(-1),
                        Duration = 1,
                        Progress = 0.6m,
                        ParentId = 0,
                        SortOrder = 2,
                        Type = "task",
                        Description = null,
                        Machine = null,
                        Customer = "Bradley"
                    },
                    new Task()
                    {
                        Id = 5,
                        Text = "Task #4",
                        start_date = DateTime.Today.AddDays(-1),
                        Duration = 1,
                        Progress = 0.6m,
                        ParentId = 0,
                        SortOrder = 2,
                        Type = "task",
                        Description = null,
                        Machine = null,
                        Customer = "ian"
                    },
               // List<Task> tasks = new List<Task>()
               //{
               //   new Task()
               //     {
               //        Id = 1,
               //        Text = "Project #1",
               //        ShopOrderNumber = 1.0m,
               //        start_date = DateTime.Today.AddHours(-3),
               //        Duration = 10,
               //        Progress = 0.4m,
               //        ParentId = null,
               //        SortOrder = 0,
               //        Type = "task",
               //        Description = null,
               //        Machine = null,
               //        Customer = "Terrill Inc.",
               //        Employee = null,
               //        PartName = "Widget",
               //        OrderQuantity = 10000
               //     },
               //     new Task()
               //     {
               //        Id = 2,
               //        Text = "Operation: Setup",
               //        ShopOrderNumber = 1.1m,
               //        start_date = DateTime.Today.AddHours(-1),
               //        Duration = 1,
               //        Progress = 1.0m,
               //        ParentId = 1,
               //        SortOrder = 1,
               //        Type = "task",
               //        Description = null,
               //        Machine = null,
               //        Customer = "Terrill Inc.",
               //        Employee = null,
               //        PartName = "Widget",
               //        OrderQuantity = 10000
               //     },
               //     new Task()
               //     {
               //        Id = 3,
               //        Text = "Operation: Production",
               //        ShopOrderNumber = 1.2m,
               //        start_date = DateTime.Today.AddHours(-8),
               //        Duration = 8,
               //        Progress = 0.5m,
               //        ParentId = 2,
               //        SortOrder = 2,
               //        Type = "task",
               //        Description = null,
               //        Machine = null,
               //        Customer = "Terrill Inc.",
               //        Employee = null,
               //        PartName = "Widget",
               //        OrderQuantity = 10000
               //     },
               //     new Task()
               //     {
               //        Id = 4,
               //        Text = "Operation: Tear down",
               //        ShopOrderNumber = 1.3m,
               //        start_date = DateTime.Today.AddHours(-1),
               //        Duration = 1,
               //        Progress = 0.0m,
               //        ParentId = 3,
               //        SortOrder = 3,
               //        Type = "task",
               //        Description = null,
               //        Machine = null,
               //        Customer = "Terrill Inc.",
               //        Employee = null,
               //        PartName = "Widget",
               //        OrderQuantity = 10000
               //     },
                    //new Task()
                    //{
                    //   Id = 1,
                    //   Text = "Project #2",
                    //   ShopOrderNumber = 2.0m,
                    //   start_date = DateTime.Today.AddHours(+3),
                    //   Duration = 10,
                    //   Progress = 0.4m,
                    //   ParentId = null,
                    //   SortOrder = 0,
                    //   Type = "project",
                    //   Description = null,
                    //   Machine = null,
                    //   Customer = "Bradley Industries",
                    //   Employee = null,
                    //   PartName = "Clip",
                    //   OrderQuantity = 200000
                    //},
                    //new Task()
                    //{
                    //   Id = 2,
                    //   Text = "Operation: Setup",
                    //   ShopOrderNumber = 2.1m,
                    //   start_date = DateTime.Today.AddHours(+1),
                    //   Duration = 1,
                    //   Progress = 1.0m,
                    //   ParentId = 1,
                    //   SortOrder = 1,
                    //   Type = "task",
                    //   Description = null,
                    //   Machine = null,
                    //   Customer = "Bradley Industries",
                    //   Employee = null,
                    //   PartName = "Clip",
                    //   OrderQuantity = 200000
                    //},
                    //new Task()
                    //{
                    //   Id = 3,
                    //   Text = "Operation: Production",
                    //   ShopOrderNumber = 2.2m,
                    //   start_date = DateTime.Today.AddHours(+8),
                    //   Duration = 8,
                    //   Progress = 0.5m,
                    //   ParentId = 2,
                    //   SortOrder = 2,
                    //   Type = "task",
                    //   Description = null,
                    //   Machine = null,
                    //   Customer = "Bradley Industries",
                    //   Employee = null,
                    //   PartName = "Clip",
                    //   OrderQuantity = 200000
                    //},
                    //new Task()
                    //{
                    //   Id = 4,
                    //   Text = "Operation: Tear down",
                    //   ShopOrderNumber = 2.3m,
                    //   start_date = DateTime.Today.AddHours(+1),
                    //   Duration = 1,
                    //   Progress = 0.0m,
                    //   ParentId = 3,
                    //   SortOrder = 3,
                    //   Type = "task",
                    //   Description = null,
                    //   Machine = null,
                    //   Customer = "Bradley Industries",
                    //   Employee = null,
                    //   PartName = "Clip",
                    //   OrderQuantity = 200000
                    //}
               };

                tasks.ForEach(s => context.Tasks.Add(s));
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Tasks ON;");
                context.SaveChanges();

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Tasks OFF;");
                List<Link> links = new List<Link>()
                {
                    new Link() {Id = 1, SourceTaskId = 1, TargetTaskId = 2, Type = "1"},
                    new Link() {Id = 2, SourceTaskId = 2, TargetTaskId = 3, Type = "0"}
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

