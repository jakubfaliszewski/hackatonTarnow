﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hackhathonTarnow.Context;

namespace hackhathonTarnow.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20190415161716_plates")]
    partial class plates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("hackhathonTarnow.Models.Parking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longtitude");

                    b.Property<int>("NumberOfFreeCarsPlaces");

                    b.Property<int>("NumberOfFreeCyclesPlaces");

                    b.Property<int>("NumberOfFreeDisabledPlaces");

                    b.Property<int>("NumberOfFreePlaces");

                    b.Property<int>("NumberOfPlaces");

                    b.HasKey("Id");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("hackhathonTarnow.Models.ParkingHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("HowLong");

                    b.Property<Guid>("ParkingId");

                    b.Property<DateTime>("StartTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ParkingHistories");
                });

            modelBuilder.Entity("hackhathonTarnow.Models.Space", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsBusy");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longtitude");

                    b.Property<Guid>("ParkingId");

                    b.Property<string>("Plate");

                    b.Property<string>("SpaceType");

                    b.HasKey("Id");

                    b.HasIndex("ParkingId");

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("hackhathonTarnow.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ActivationDate");

                    b.Property<string>("CardId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DefaultPlate");

                    b.Property<string>("Email");

                    b.Property<bool>("IsActivated");

                    b.Property<bool?>("IsPremium");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Role");

                    b.Property<string>("Surname");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("hackhathonTarnow.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarPlate");

                    b.Property<Guid?>("ParkingId");

                    b.Property<Guid?>("UserId");

                    b.Property<string>("VehicleType");

                    b.HasKey("Id");

                    b.HasIndex("ParkingId");

                    b.HasIndex("UserId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("hackhathonTarnow.Models.Space", b =>
                {
                    b.HasOne("hackhathonTarnow.Models.Parking")
                        .WithMany("Spaces")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("hackhathonTarnow.Models.Vehicle", b =>
                {
                    b.HasOne("hackhathonTarnow.Models.Parking", "Parking")
                        .WithMany()
                        .HasForeignKey("ParkingId");

                    b.HasOne("hackhathonTarnow.Models.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
