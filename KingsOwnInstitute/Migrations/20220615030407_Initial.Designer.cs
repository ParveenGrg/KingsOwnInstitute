﻿// <auto-generated />
using System;
using KingsOwnInstitute.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KingsOwnInstitute.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220615030407_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KingsOwnInstitute.Models.Attendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.RegistrationInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeminarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.HasIndex("SeminarId");

                    b.ToTable("RegistrationInfo");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.Seminar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("SeminarDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeminarTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeminarTypeId");

                    b.ToTable("Seminars");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.SeminarOrganizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<int>("SeminarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.HasIndex("SeminarId");

                    b.ToTable("SeminarOrganizers");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.SeminarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SeminarTypes");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.RegistrationInfo", b =>
                {
                    b.HasOne("KingsOwnInstitute.Models.Attendee", "Attendee")
                        .WithMany()
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KingsOwnInstitute.Models.Seminar", "Seminar")
                        .WithMany("RegistrationInfo")
                        .HasForeignKey("SeminarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Seminar");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.Seminar", b =>
                {
                    b.HasOne("KingsOwnInstitute.Models.SeminarType", "SeminarType")
                        .WithMany()
                        .HasForeignKey("SeminarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SeminarType");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.SeminarOrganizer", b =>
                {
                    b.HasOne("KingsOwnInstitute.Models.Organizer", "Organizer")
                        .WithMany("SeminarOrganizers")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KingsOwnInstitute.Models.Seminar", "Seminar")
                        .WithMany("SeminarOrganizers")
                        .HasForeignKey("SeminarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");

                    b.Navigation("Seminar");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.Organizer", b =>
                {
                    b.Navigation("SeminarOrganizers");
                });

            modelBuilder.Entity("KingsOwnInstitute.Models.Seminar", b =>
                {
                    b.Navigation("RegistrationInfo");

                    b.Navigation("SeminarOrganizers");
                });
#pragma warning restore 612, 618
        }
    }
}
