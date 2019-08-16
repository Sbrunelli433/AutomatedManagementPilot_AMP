﻿using System;
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


        //public DbSet<Dashboard> Dashboard { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Link> Links { get; set; }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<JobCard> JobCard { get; set; }

        public DbSet<Machine> Machine { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<ShopOrder> ShopOrder { get; set; }

        public DbSet<Models.Supervisor> Supervisor { get; set; }
        public DbSet<TimeClock> TimeClock { get; set; }


        //public DbSet<AddedValue> AddedValue { get; set; }
        //public DbSet<MRP> MRPs { get; set; }
        //public DbSet<Purchasing> Purchasing { get; set; }
        //public DbSet<SalesOrder> SalesOrder { get; set; }
    }
}
