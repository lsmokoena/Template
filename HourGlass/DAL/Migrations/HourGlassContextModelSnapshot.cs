﻿// <auto-generated />
using Datastore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Datastore.Migrations
{
    [DbContext(typeof(HourGlassContext))]
    partial class HourGlassContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Datastore.Model.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactPerson");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Datastore.Model.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ReferenceNumber");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Datastore.Model.EmployeeProject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AssignmentDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("EmployeeId");

                    b.Property<long?>("EmployeeId1");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("ProjectId");

                    b.Property<long?>("ProjectId1");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId1");

                    b.HasIndex("ProjectId1");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("Datastore.Model.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("CustomerId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Datastore.Model.TimeAllocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("EmployeeId");

                    b.Property<long?>("EmployeeId1");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Note");

                    b.Property<int>("ProjectId");

                    b.Property<long?>("ProjectId1");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId1");

                    b.HasIndex("ProjectId1");

                    b.ToTable("TimeAllocation");
                });

            modelBuilder.Entity("Datastore.Model.EmployeeProject", b =>
                {
                    b.HasOne("Datastore.Model.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId1");

                    b.HasOne("Datastore.Model.Project", "Project")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("ProjectId1");
                });

            modelBuilder.Entity("Datastore.Model.Project", b =>
                {
                    b.HasOne("Datastore.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Datastore.Model.TimeAllocation", b =>
                {
                    b.HasOne("Datastore.Model.Employee", "Employee")
                        .WithMany("TimeAllocation")
                        .HasForeignKey("EmployeeId1");

                    b.HasOne("Datastore.Model.Project", "Project")
                        .WithMany("TimeAllocations")
                        .HasForeignKey("ProjectId1");
                });
#pragma warning restore 612, 618
        }
    }
}
