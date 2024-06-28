﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.Data;

#nullable disable

namespace project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240628142042_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("project.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("KRS")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Warsaw",
                            Email = "iunce@gamil.com",
                            KRS = 128374493L,
                            Name = "Company1",
                            PhoneNumber = "+82374982347"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Gdansk",
                            Email = "83hdkjfr@gamil.com",
                            KRS = 2849750727L,
                            Name = "Company2",
                            PhoneNumber = "+29479124984"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Berlin",
                            Email = "aoucn2@gamil.com",
                            KRS = 259824905L,
                            Name = "Company2",
                            PhoneNumber = "+28739418645"
                        });
                });

            modelBuilder.Entity("project.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSigned")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            EndDate = new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsSigned = false,
                            Price = 28497.0,
                            SoftwareId = 1,
                            StartDate = new DateTime(2024, 6, 28, 16, 20, 41, 842, DateTimeKind.Local).AddTicks(140),
                            Version = "first"
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 2,
                            EndDate = new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsSigned = false,
                            Price = 8575.0,
                            SoftwareId = 2,
                            StartDate = new DateTime(2024, 6, 28, 16, 20, 41, 842, DateTimeKind.Local).AddTicks(400),
                            Version = "first"
                        });
                });

            modelBuilder.Entity("project.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Black Friday Discount",
                            StartTime = new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            Value = 10.0
                        },
                        new
                        {
                            Id = 2,
                            EndTime = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "New Year Discount",
                            StartTime = new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            Value = 15.0
                        },
                        new
                        {
                            Id = 3,
                            EndTime = new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Summer Discount",
                            StartTime = new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            Value = 30.0
                        });
                });

            modelBuilder.Entity("project.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("project.Models.Individual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PESEL")
                        .HasColumnType("bigint");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Individuals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Rome",
                            Email = "iuwnb4f84b@gamil.com",
                            FirstName = "name1",
                            IsDeleted = false,
                            LastName = "surname1",
                            PESEL = 29748384850L,
                            PhoneNumber = "+29840928565"
                        },
                        new
                        {
                            Id = 2,
                            Address = "London",
                            Email = "aibd7662@gamil.com",
                            FirstName = "name2",
                            IsDeleted = false,
                            LastName = "surname2",
                            PESEL = 98347598375L,
                            PhoneNumber = "+39482209755"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Vienna",
                            Email = "blvne784@gamil.com",
                            FirstName = "name3",
                            IsDeleted = false,
                            LastName = "surname3",
                            PESEL = 92480370580L,
                            PhoneNumber = "+98246950593"
                        });
                });

            modelBuilder.Entity("project.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 8273.0,
                            ContractId = 1,
                            Date = new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amount = 10394.0,
                            ContractId = 1,
                            Date = new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amount = 2397.0,
                            ContractId = 1,
                            Date = new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amount = 8575.0,
                            ContractId = 2,
                            Date = new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("project.Models.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Softwares");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "education",
                            Description = "b b b b",
                            Name = "Software1"
                        },
                        new
                        {
                            Id = 2,
                            Category = "science",
                            Description = "a a a a",
                            Name = "Software2"
                        },
                        new
                        {
                            Id = 3,
                            Category = "finances",
                            Description = "c c c c",
                            Name = "Software3"
                        });
                });

            modelBuilder.Entity("project.Models.Version", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Versions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Version1",
                            SoftwareId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Version2",
                            SoftwareId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Version3",
                            SoftwareId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Version4",
                            SoftwareId = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}