﻿// <auto-generated />
using EventAll.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventAll.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200122165048_EquipmentItems")]
    partial class EquipmentItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventAll.Models.Equipment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("EventAll.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Budget")
                        .HasColumnType("float");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MiscCost")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventAll.Models.EventEquipment", b =>
                {
                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentID")
                        .HasColumnType("int");

                    b.HasKey("EventID", "EquipmentID");

                    b.HasIndex("EquipmentID");

                    b.ToTable("EventEquipments");
                });

            modelBuilder.Entity("EventAll.Models.EventStaff", b =>
                {
                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("StaffID")
                        .HasColumnType("int");

                    b.HasKey("EventID", "StaffID");

                    b.HasIndex("StaffID");

                    b.ToTable("EventStaffs");
                });

            modelBuilder.Entity("EventAll.Models.EventVenue", b =>
                {
                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("VenueID")
                        .HasColumnType("int");

                    b.HasKey("EventID", "VenueID");

                    b.HasIndex("VenueID");

                    b.ToTable("EventVenues");
                });

            modelBuilder.Entity("EventAll.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipmentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("EventAll.Models.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Wage")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("EventAll.Models.Venue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("EventAll.Models.EventEquipment", b =>
                {
                    b.HasOne("EventAll.Models.Equipment", "Equipment")
                        .WithMany("EventEquipments")
                        .HasForeignKey("EquipmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventAll.Models.Event", "Event")
                        .WithMany("Equipments")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventAll.Models.EventStaff", b =>
                {
                    b.HasOne("EventAll.Models.Event", "Event")
                        .WithMany("Staffs")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventAll.Models.Staff", "Staff")
                        .WithMany("Events")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventAll.Models.EventVenue", b =>
                {
                    b.HasOne("EventAll.Models.Event", "Event")
                        .WithMany("Venues")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventAll.Models.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventAll.Models.Item", b =>
                {
                    b.HasOne("EventAll.Models.Equipment", "Equipment")
                        .WithMany("Items")
                        .HasForeignKey("EquipmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}