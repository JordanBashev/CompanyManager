﻿// <auto-generated />
using System;
using CompanyManager.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyManager.Migrations
{
    [DbContext(typeof(CompanyManagerContext))]
    partial class CompanyManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyManager.Database.Entities.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("managerId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("password")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<DateTime?>("removedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("salary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("teamId")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<int>("yearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("managerId");

                    b.HasIndex("teamId");

                    b.HasIndex("username")
                        .IsUnique()
                        .HasFilter("[username] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CompanyManager.Database.Entities.Manager", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("password")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<DateTime?>("removedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("salary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("username")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<int>("yearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("username")
                        .IsUnique()
                        .HasFilter("[username] IS NOT NULL");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("CompanyManager.Database.Entities.Project", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("FinishedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("cost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("managerId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<DateTime?>("removedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("managerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CompanyManager.Database.Entities.Team", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<double>("pointsPerPerson")
                        .HasColumnType("float");

                    b.Property<DateTime?>("removedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("task")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CompanyManager.Database.Entities.TeamToProject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("projectId")
                        .HasColumnType("int");

                    b.Property<int?>("teamId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("projectId");

                    b.HasIndex("teamId");

                    b.ToTable("TeamToProject");
                });

            modelBuilder.Entity("CompanyManager.Database.Entities.Employee", b =>
                {
                    b.HasOne("CompanyManager.Database.Entities.Manager", "manager")
                        .WithMany()
                        .HasForeignKey("managerId");

                    b.HasOne("CompanyManager.Database.Entities.Team", "team")
                        .WithMany()
                        .HasForeignKey("teamId");

                    b.Navigation("manager");

                    b.Navigation("team");
                });

            modelBuilder.Entity("CompanyManager.Database.Entities.Project", b =>
                {
                    b.HasOne("CompanyManager.Database.Entities.Manager", "manager")
                        .WithMany()
                        .HasForeignKey("managerId");

                    b.Navigation("manager");
                });

            modelBuilder.Entity("CompanyManager.Database.Entities.TeamToProject", b =>
                {
                    b.HasOne("CompanyManager.Database.Entities.Project", "employee")
                        .WithMany()
                        .HasForeignKey("projectId");

                    b.HasOne("CompanyManager.Database.Entities.Team", "team")
                        .WithMany()
                        .HasForeignKey("teamId");

                    b.Navigation("employee");

                    b.Navigation("team");
                });
#pragma warning restore 612, 618
        }
    }
}
