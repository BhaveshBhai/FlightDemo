﻿// <auto-generated />
using System;
using Flight.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flight.API.Migrations
{
    [DbContext(typeof(FlightManagmentContext))]
    [Migration("20190908034302_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flight.API.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BarrivalCity")
                        .HasColumnName("BArrivalCity")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Bdate")
                        .HasColumnName("BDate")
                        .HasMaxLength(30);

                    b.Property<string>("BdepartCity")
                        .HasColumnName("BDepartCity")
                        .HasMaxLength(20);

                    b.Property<string>("BookId")
                        .HasColumnName("BookID")
                        .HasMaxLength(20);

                    b.Property<int>("FlightId")
                        .HasColumnName("FlightID");

                    b.Property<string>("PassengerName")
                        .HasMaxLength(30);

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Flight.API.Models.Flights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArrivalCity")
                        .HasMaxLength(30);

                    b.Property<string>("DepartCity")
                        .HasMaxLength(30);

                    b.Property<DateTime>("EndDate")
                        .HasMaxLength(30);

                    b.Property<string>("FlightNo")
                        .HasMaxLength(20);

                    b.Property<int?>("PassCapacity");

                    b.Property<DateTime>("StartDate")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Flight.API.Models.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasMaxLength(50);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Flight.API.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Flight.API.Models.Booking", b =>
                {
                    b.HasOne("Flight.API.Models.Flights", "Flight")
                        .WithMany("Booking")
                        .HasForeignKey("FlightId")
                        .HasConstraintName("FK_Booking_Flights")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Flight.API.Models.Users", "User")
                        .WithMany("Booking")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Booking_User")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Flight.API.Models.Users", b =>
                {
                    b.HasOne("Flight.API.Models.Roles", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Users_Roles")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
