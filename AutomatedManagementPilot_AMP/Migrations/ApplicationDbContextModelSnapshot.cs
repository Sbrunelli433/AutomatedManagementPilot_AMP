﻿// <auto-generated />
using System;
using AutomatedManagementPilot_AMP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutomatedManagementPilot_AMP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationId");

                    b.Property<string>("Name");

                    b.Property<double>("PayRoll");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CycleTime");

                    b.Property<int>("ShopOrderNumber");

                    b.Property<decimal>("Utilization");

                    b.HasKey("MachineId");

                    b.HasIndex("ShopOrderNumber")
                        .IsUnique();

                    b.ToTable("Machine");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationId");

                    b.Property<string>("Name");

                    b.Property<double>("PayRoll");

                    b.HasKey("ManagerId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.ShopOrder", b =>
                {
                    b.Property<int>("ShopOrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer");

                    b.Property<decimal>("GrossProductionRate");

                    b.Property<int>("MachineId");

                    b.Property<decimal>("NetProductionRate");

                    b.Property<decimal>("OperationEmpBreakHours");

                    b.Property<decimal>("OperationMachineBreakHours");

                    b.Property<decimal>("OperationProductionHours");

                    b.Property<decimal>("OperationSetUpHours");

                    b.Property<decimal>("OperationTearDownHours");

                    b.Property<DateTime>("OrderDueDate");

                    b.Property<int>("OrderQuantity")
                        .HasMaxLength(25);

                    b.Property<DateTime>("OrderRecDate")
                        .HasMaxLength(8);

                    b.Property<string>("PartName")
                        .HasMaxLength(15);

                    b.Property<int>("PartNumber")
                        .HasMaxLength(6);

                    b.Property<decimal>("Profitability");

                    b.Property<string>("RawMatlInventoryId")
                        .HasMaxLength(250000);

                    b.Property<DateTime>("ScheduleEndTime");

                    b.Property<DateTime>("ScheduleStartTime");

                    b.HasKey("ShopOrderNumber");

                    b.ToTable("ShopOrder");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.Supervisor", b =>
                {
                    b.Property<int>("SupervisorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationId");

                    b.Property<string>("Name");

                    b.Property<double>("PayRoll");

                    b.HasKey("SupervisorId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Supervisor");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.TimeClock", b =>
                {
                    b.Property<int>("TimeClockId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ClockIn");

                    b.Property<DateTime>("ClockOut");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("HoursWorked");

                    b.HasKey("TimeClockId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeClock");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.Employee", b =>
                {
                    b.HasOne("AutomatedManagementPilot_AMP.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.Machine", b =>
                {
                    b.HasOne("AutomatedManagementPilot_AMP.Models.ShopOrder", "ShopOrder")
                        .WithOne("Machine")
                        .HasForeignKey("AutomatedManagementPilot_AMP.Models.Machine", "ShopOrderNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.Manager", b =>
                {
                    b.HasOne("AutomatedManagementPilot_AMP.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.Supervisor", b =>
                {
                    b.HasOne("AutomatedManagementPilot_AMP.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("AutomatedManagementPilot_AMP.Models.TimeClock", b =>
                {
                    b.HasOne("AutomatedManagementPilot_AMP.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AutomatedManagementPilot_AMP.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AutomatedManagementPilot_AMP.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AutomatedManagementPilot_AMP.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AutomatedManagementPilot_AMP.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
