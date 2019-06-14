﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Model;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190614140434_AddedMigration")]
    partial class AddedMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication2.Model.Designation", b =>
                {
                    b.Property<int>("DesignationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("DesignationId");

                    b.ToTable("Designation");
                });

            modelBuilder.Entity("WebApplication2.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Dateofjoining");

                    b.Property<int>("DesignationId");

                    b.Property<string>("Email");

                    b.Property<int>("MerchantId");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<double?>("Salary");

                    b.Property<string>("Username");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WebApplication2.Model.Merchant", b =>
                {
                    b.Property<int>("MerchantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("OrganizationName");

                    b.Property<string>("Phone");

                    b.HasKey("MerchantId");

                    b.ToTable("Merchant");
                });

            modelBuilder.Entity("WebApplication2.Model.Employee", b =>
                {
                    b.HasOne("WebApplication2.Model.Designation", "Designation")
                        .WithMany("Employee")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication2.Model.Merchant", "Merchant")
                        .WithMany("Employee")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
