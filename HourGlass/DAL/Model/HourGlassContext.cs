using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datastore.Model
{
    public class HourGlassContext : DbContext
    {
        public HourGlassContext(DbContextOptions<HourGlassContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=HourGlass;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Employee Project
            //modelBuilder.Entity<EmployeeProject>()
            //   .HasKey(ep => new
            //   {
            //       ep.EmployeeId,
            //       ep.ProjectId
            //   });

            //modelBuilder.Entity<EmployeeProject>()
            //    .HasOne(p => p.Employee)
            //    .WithMany(u => u.EmployeeProjects)
            //    .HasForeignKey(up => up.ProjectId);

            //modelBuilder.Entity<EmployeeProject>()
            //    .HasOne(u => u.Project)
            //    .WithMany(p => p.ProjectEmployees)
            //    .HasForeignKey(up => up.EmployeeId);

            //modelBuilder.Entity<EmployeeProject>()
            //   .HasKey(ep => new
            //   {
            //       ep.EmployeeId,
            //       ep.ProjectId
            //   });

            ////Time Allocation
            //modelBuilder.Entity<TimeAllocation>()
            //    .HasOne(p => p.Project)
            //    .WithMany(u => u.TimeAllocations)
            //    .HasForeignKey(up => up.EmployeeId);

            //modelBuilder.Entity<TimeAllocation>()
            //    .HasOne(u => u.Employee)
            //    .WithMany(p => p.TimeAllocation)
            //    .HasForeignKey(up => up.ProjectId);
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<EmployeeProject> EmployeeProject { get; set; }

        public DbSet<TimeAllocation> TimeAllocation { get; set; }
    }
}
