﻿// <auto-generated />
using System;
using Hairdresser.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hairdresser.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241201204848_MigrationName")]
    partial class MigrationName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExpertisePersonnel", b =>
                {
                    b.Property<int>("expertisesexpertiseID")
                        .HasColumnType("integer");

                    b.Property<int>("personnelspersonnelID")
                        .HasColumnType("integer");

                    b.HasKey("expertisesexpertiseID", "personnelspersonnelID");

                    b.HasIndex("personnelspersonnelID");

                    b.ToTable("ExpertisePersonnel");
                });

            modelBuilder.Entity("Hairdresser.Entities.Admin", b =>
                {
                    b.Property<int>("adminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("adminID"));

                    b.Property<string>("adminEmail")
                        .HasColumnType("text");

                    b.Property<string>("adminPassword")
                        .HasColumnType("text");

                    b.HasKey("adminID");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("Hairdresser.Entities.Appointment", b =>
                {
                    b.Property<int>("appointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("appointmentID"));

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("appointmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("customerID")
                        .HasColumnType("integer");

                    b.Property<int>("personnelID")
                        .HasColumnType("integer");

                    b.Property<int>("serviceID")
                        .HasColumnType("integer");

                    b.HasKey("appointmentID");

                    b.HasIndex("customerID");

                    b.HasIndex("personnelID");

                    b.HasIndex("serviceID");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("Hairdresser.Entities.Customer", b =>
                {
                    b.Property<int>("customerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("customerID"));

                    b.Property<string>("customerEmail")
                        .HasColumnType("text");

                    b.Property<string>("customerName")
                        .HasColumnType("text");

                    b.Property<string>("customerPassword")
                        .HasColumnType("text");

                    b.HasKey("customerID");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Hairdresser.Entities.Expertise", b =>
                {
                    b.Property<int>("expertiseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("expertiseID"));

                    b.Property<string>("expertiseName")
                        .HasColumnType("text");

                    b.HasKey("expertiseID");

                    b.ToTable("expertises");
                });

            modelBuilder.Entity("Hairdresser.Entities.Personnel", b =>
                {
                    b.Property<int>("personnelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("personnelID"));

                    b.Property<string>("availableHours")
                        .HasColumnType("text");

                    b.Property<string>("personnelEmail")
                        .HasColumnType("text");

                    b.Property<string>("personnelName")
                        .HasColumnType("text");

                    b.Property<string>("personnelPassword")
                        .HasColumnType("text");

                    b.Property<int>("salonID")
                        .HasColumnType("integer");

                    b.HasKey("personnelID");

                    b.HasIndex("salonID");

                    b.ToTable("personnels");
                });

            modelBuilder.Entity("Hairdresser.Entities.Salon", b =>
                {
                    b.Property<int>("salonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("salonID"));

                    b.Property<string>("salonAddress")
                        .HasColumnType("text");

                    b.Property<string>("salonName")
                        .HasColumnType("text");

                    b.Property<string>("salonType")
                        .HasColumnType("text");

                    b.Property<string>("workingHours")
                        .HasColumnType("text");

                    b.HasKey("salonID");

                    b.ToTable("salons");
                });

            modelBuilder.Entity("Hairdresser.Entities.Service", b =>
                {
                    b.Property<int>("serviceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("serviceID"));

                    b.Property<int>("salonID")
                        .HasColumnType("integer");

                    b.Property<int>("serviceDuration")
                        .HasColumnType("integer");

                    b.Property<string>("serviceName")
                        .HasColumnType("text");

                    b.Property<decimal>("servicePrice")
                        .HasColumnType("numeric");

                    b.HasKey("serviceID");

                    b.HasIndex("salonID");

                    b.ToTable("services");
                });

            modelBuilder.Entity("ExpertisePersonnel", b =>
                {
                    b.HasOne("Hairdresser.Entities.Expertise", null)
                        .WithMany()
                        .HasForeignKey("expertisesexpertiseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hairdresser.Entities.Personnel", null)
                        .WithMany()
                        .HasForeignKey("personnelspersonnelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hairdresser.Entities.Appointment", b =>
                {
                    b.HasOne("Hairdresser.Entities.Customer", "Customer")
                        .WithMany("appointments")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hairdresser.Entities.Personnel", "personnel")
                        .WithMany("appointments")
                        .HasForeignKey("personnelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hairdresser.Entities.Service", "service")
                        .WithMany("appointments")
                        .HasForeignKey("serviceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("personnel");

                    b.Navigation("service");
                });

            modelBuilder.Entity("Hairdresser.Entities.Personnel", b =>
                {
                    b.HasOne("Hairdresser.Entities.Salon", "salon")
                        .WithMany("personnels")
                        .HasForeignKey("salonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("salon");
                });

            modelBuilder.Entity("Hairdresser.Entities.Service", b =>
                {
                    b.HasOne("Hairdresser.Entities.Salon", "salon")
                        .WithMany("Services")
                        .HasForeignKey("salonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("salon");
                });

            modelBuilder.Entity("Hairdresser.Entities.Customer", b =>
                {
                    b.Navigation("appointments");
                });

            modelBuilder.Entity("Hairdresser.Entities.Personnel", b =>
                {
                    b.Navigation("appointments");
                });

            modelBuilder.Entity("Hairdresser.Entities.Salon", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("personnels");
                });

            modelBuilder.Entity("Hairdresser.Entities.Service", b =>
                {
                    b.Navigation("appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
