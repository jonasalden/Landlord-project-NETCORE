﻿// <auto-generated />
using System;
using Landlord_project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Landlord_project.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Landlord_project.Data.Residence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ApplicationFrom")
                        .HasColumnType("datetime2");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CanRental")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateBuilt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRenovated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<bool>("HasBalcony")
                        .HasColumnType("bit");

                    b.Property<bool>("HasCourtyard")
                        .HasColumnType("bit");

                    b.Property<bool>("HasElevator")
                        .HasColumnType("bit");

                    b.Property<string>("HousingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageMimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RentalPrice")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShowFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShowTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfResidence")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Residence");
                });

            modelBuilder.Entity("Landlord_project.Data.ResidenceAssignment", b =>
                {
                    b.Property<int>("ResidenceID")
                        .HasColumnType("int");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.HasKey("ResidenceID", "TenantID");

                    b.HasIndex("TenantID");

                    b.ToTable("ResidenceAssignments");
                });

            modelBuilder.Entity("Landlord_project.Data.ResidenceReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanAccessResidence")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HousingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageMimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResidenceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResidenceId");

                    b.ToTable("ResidenceReports");
                });

            modelBuilder.Entity("Landlord_project.Data.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasResidence")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(7, 2)");

                    b.Property<string>("SocialSecurityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("Landlord_project.Data.ResidenceAssignment", b =>
                {
                    b.HasOne("Landlord_project.Data.Residence", "Residence")
                        .WithMany("ResidenceAssignments")
                        .HasForeignKey("ResidenceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Landlord_project.Data.Tenant", "Tenant")
                        .WithMany("ResidenceAssignments")
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Landlord_project.Data.ResidenceReport", b =>
                {
                    b.HasOne("Landlord_project.Data.Residence", "Residence")
                        .WithMany("ResidenceReports")
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
