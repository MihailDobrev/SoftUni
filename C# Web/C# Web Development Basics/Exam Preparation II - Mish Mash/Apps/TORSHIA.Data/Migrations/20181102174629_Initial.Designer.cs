﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TORSHIA.Data;

namespace TORSHIA.Data.Migrations
{
    [DbContext(typeof(TorshiaDbContext))]
    [Migration("20181102174629_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TORSHIA.Domain.Report", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ReportedOn");

                    b.Property<string>("ReporterId");

                    b.Property<string>("StatusId");

                    b.Property<string>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("ReporterId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TaskId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("TORSHIA.Domain.ReportStatus", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("ReportStatuses");
                });

            modelBuilder.Entity("TORSHIA.Domain.Sector", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("TORSHIA.Domain.Task", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("IsReported");

                    b.Property<string>("ParticipantsString");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TORSHIA.Domain.TaskSector", b =>
                {
                    b.Property<string>("TaskId");

                    b.Property<string>("SectorId");

                    b.HasKey("TaskId", "SectorId");

                    b.HasIndex("SectorId");

                    b.ToTable("TasksSectors");
                });

            modelBuilder.Entity("TORSHIA.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<bool>("IsValid");

                    b.Property<string>("Password");

                    b.Property<string>("RoleId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TORSHIA.Domain.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TORSHIA.Domain.Report", b =>
                {
                    b.HasOne("TORSHIA.Domain.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterId");

                    b.HasOne("TORSHIA.Domain.ReportStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("TORSHIA.Domain.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("TORSHIA.Domain.TaskSector", b =>
                {
                    b.HasOne("TORSHIA.Domain.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TORSHIA.Domain.Task", "Task")
                        .WithMany("AffectedSectors")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TORSHIA.Domain.User", b =>
                {
                    b.HasOne("TORSHIA.Domain.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
