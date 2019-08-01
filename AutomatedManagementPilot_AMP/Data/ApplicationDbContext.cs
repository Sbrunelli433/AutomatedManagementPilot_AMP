using System;
using System.Collections.Generic;
using System.Text;
using AutomatedManagementPilot_AMP.Models;
//using AutomatedManagementPilotAMP.ReportModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutomatedManagementPilot_AMP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShopOrder>().HasData(
                new ShopOrder
                {
                    ShopOrderNumber = 001,
                    Customer = "Terrill Inc.",
                    PartNumber = 12345,
                    PartName = "Widget",
                    OrderQuantity = 10000,
                    RawMatlInventoryId = "00277",
                    OrderRecDate = new DateTime(2019, 07, 06),
                    OrderDueDate = new DateTime(2019, 07, 09),
                    MachineId = 01,
                    ScheduleStartTime = new DateTime(2019, 07, 06),
                    ScheduleEndTime = new DateTime(2019, 07, 08),
                    OperationSetUpHours = new TimeSpan(0, 30, 0),
                    OperationProductionHours = new TimeSpan(2, 30, 0),
                    OperationTearDownHours = new TimeSpan(0, 45, 0),
                    //GrossProductionRate = null,
                    //NetProductionRate = null,
                    //Profitability = null,   
                });
            modelBuilder.Entity<ShopOrder>().HasData(
                new ShopOrder
                {
                    ShopOrderNumber = 002,
                    Customer = "Bradley Industries.",
                    PartNumber = 002,
                    PartName = "Clip",
                    OrderQuantity = 200000,
                    RawMatlInventoryId = "00244",
                    OrderRecDate = new DateTime(2019, 07, 07),
                    OrderDueDate = new DateTime(2019, 07, 11),
                    MachineId = 01,
                    ScheduleStartTime = new DateTime(2019, 07, 07),
                    ScheduleEndTime = new DateTime(2019, 07, 10),
                    OperationSetUpHours = new TimeSpan(1, 0, 0),
                    OperationProductionHours = new TimeSpan(5, 30, 0),
                    OperationTearDownHours = new TimeSpan(1, 30, 0),
                    //GrossProductionRate = null,
                    //NetProductionRate = null,
                    //Profitability = null,   
                });

            modelBuilder.Entity<ShopOrder>().HasData(
                new ShopOrder
                {
                    ShopOrderNumber = 003,
                    Customer = "ACME Solutions",
                    PartNumber = 321,
                    PartName = "Washer",
                    OrderQuantity = 15000,
                    RawMatlInventoryId = "00101",
                    OrderRecDate = new DateTime(2019, 07, 07),
                    OrderDueDate = new DateTime(2019, 07, 09),
                    MachineId = 01,
                    ScheduleStartTime = new DateTime(2019, 07, 07),
                    ScheduleEndTime = new DateTime(2019, 07, 10),
                    OperationSetUpHours = new TimeSpan(0, 30, 0),
                    OperationProductionHours = new TimeSpan(2, 30, 0),
                    OperationTearDownHours = new TimeSpan(0, 45, 0),
                    //GrossProductionRate = null,
                    //NetProductionRate = null,
                    //Profitability = null,   
                });

            modelBuilder.Entity<Machine>().HasData(
                new Machine
                {
                    MachineId = 01,
                    ShopOrderNumber = 001,
                    
                });

            modelBuilder.Entity<Machine>().HasData(
                new Machine
                {
                    MachineId = 02,
                    ShopOrderNumber = 002,

                });



        }
        //public DbSet<Dashboard> Dashboard { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<ShopOrder> ShopOrder { get; set; }

        public DbSet<Models.Supervisor> Supervisor { get; set; }
        public DbSet<TimeClock> TimeClock { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        //public DbSet<AddedValue> AddedValue { get; set; }
        //public DbSet<MRP> MRPs { get; set; }
        //public DbSet<Purchasing> Purchasing { get; set; }
        //public DbSet<SalesOrder> SalesOrder { get; set; }
    }
}
