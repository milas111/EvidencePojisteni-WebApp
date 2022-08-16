﻿// <auto-generated />
using System;
using EvidencePojisteni.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvidencePojisteni.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EvidencePojisteni.Models.AssignedInsurances.AssignedInsurance", b =>
                {
                    b.Property<int>("AssignedInsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<int>("InsuranceRole")
                        .HasColumnType("int");

                    b.Property<int>("InsuredId")
                        .HasColumnType("int");

                    b.Property<string>("Issue")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("AssignedInsuranceId");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("InsuredId");

                    b.ToTable("AssignedInsurance");

                    b.HasData(
                        new
                        {
                            AssignedInsuranceId = 1,
                            InsuranceId = 1,
                            InsuranceRole = 0,
                            InsuredId = 2,
                            Issue = "Byt",
                            Paid = false,
                            ValidFrom = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidTo = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 1000000
                        },
                        new
                        {
                            AssignedInsuranceId = 2,
                            InsuranceId = 2,
                            InsuranceRole = 1,
                            InsuredId = 2,
                            Issue = "Do zahraničí",
                            Paid = false,
                            ValidFrom = new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidTo = new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 1000
                        },
                        new
                        {
                            AssignedInsuranceId = 3,
                            InsuranceId = 3,
                            InsuranceRole = 0,
                            InsuredId = 1,
                            Issue = "Povinné ručení",
                            Paid = true,
                            ValidFrom = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidTo = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 2000
                        },
                        new
                        {
                            AssignedInsuranceId = 4,
                            InsuranceId = 4,
                            InsuranceRole = 0,
                            InsuredId = 3,
                            Issue = "Úraz",
                            Paid = false,
                            ValidFrom = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValidTo = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Value = 3000
                        });
                });

            modelBuilder.Entity("EvidencePojisteni.Models.AssignedInsurances.AssignedInsurancesToPolicyholders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignedInsuranceId")
                        .HasColumnType("int");

                    b.Property<int?>("InsuredId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedInsuranceId");

                    b.HasIndex("InsuredId");

                    b.ToTable("AssignedInsurancesToPolicyholders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignedInsuranceId = 3,
                            InsuredId = 2
                        },
                        new
                        {
                            Id = 2,
                            AssignedInsuranceId = 4,
                            InsuredId = 2
                        });
                });

            modelBuilder.Entity("EvidencePojisteni.Models.InsuranceEvents.InsuranceEvent", b =>
                {
                    b.Property<int>("InsuranceEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<int?>("InsuredId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("InsuranceEventId");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("InsuredId");

                    b.ToTable("InsuranceEvent");

                    b.HasData(
                        new
                        {
                            InsuranceEventId = 1,
                            AccountNumber = "1234567891234567",
                            BankCode = "0100",
                            City = "Praha 1",
                            Email = "zobakova.vlasta@seznam.cz",
                            EventDate = new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventDescription = "Byl nám vytopen byt sousedy.",
                            FirstName = "Vlastimila",
                            Gender = 0,
                            InsuranceId = 1,
                            InsuredId = 2,
                            Phone = "731 567 957",
                            Street = "Karlova 73",
                            SurName = "Zobáková",
                            Zip = "110 00"
                        });
                });

            modelBuilder.Entity("EvidencePojisteni.Models.Insurances.Insurance", b =>
                {
                    b.Property<int>("InsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InsuranceDescription")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("InsuranceImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("InsuranceId");

                    b.ToTable("Insurance");

                    b.HasData(
                        new
                        {
                            InsuranceId = 1,
                            InsuranceDescription = "Pojištění majetku, zahrnuje pojištění nemovitosti a domácnosti, vám bude krýt záda v případě škody způsobené přírodními živly nebo zlodějem. Co všechno lze pojistit? Domáctnost: Vztahuje se na vybavení domu nebo bytu.Nemovitost: Vztahuje se na stavbu a veškeré její pevné součásti. Odpovědnost za škodu: Pokryje škody na cizím majetku nebo újmu na zdraví.",
                            InsuranceImage = "propertyInsurance.png",
                            InsuranceName = "Pojištění majetku"
                        },
                        new
                        {
                            InsuranceId = 2,
                            InsuranceDescription = "Základní cestovní pojištění kryje veškeré léčebné výlohy. Z tohoto pojištění Vám bude proplacena případná zdravotní péče v zahraničí. Pojišťovna za vás uhradí: Náklady na ošetření, hospitalizaci,léky, nezbytné převozy a repatriaci, převoz tělesných ostatků.",
                            InsuranceImage = "travel-insurance.jpg",
                            InsuranceName = "Cestovní pojištění"
                        },
                        new
                        {
                            InsuranceId = 3,
                            InsuranceDescription = "Každý majitel vozidla musí mít sjednané povinné ručení. Povinné ručení vás chrání v případě, že způsobíte dopravní nehodu: vyrovná za vás škody na autě, majetku i zdraví poškozených osob.",
                            InsuranceImage = "vehicle-insurance.png",
                            InsuranceName = "Pojištění vozidel"
                        },
                        new
                        {
                            InsuranceId = 4,
                            InsuranceDescription = "Životní pojištění finančně podrží vás i vaše blízké v případě smrti, úrazu s trvalými následky nebo dlouhodobé nemoci. Krytí si můžete vybrat tak, aby vyhovovalo vašim potřebám.",
                            InsuranceImage = "life-insurance.jpg",
                            InsuranceName = "Životní pojištění"
                        });
                });

            modelBuilder.Entity("EvidencePojisteni.Models.Insureds.Insured", b =>
                {
                    b.Property<int>("InsuredId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("InsuredId");

                    b.HasIndex("UserId");

                    b.ToTable("Insured");

                    b.HasData(
                        new
                        {
                            InsuredId = 1,
                            City = "Brno",
                            Email = "soukup.miloslav1@seznam.cz",
                            FirstName = "Miloslav",
                            Gender = 1,
                            Phone = "neznámé číslo",
                            Street = "Nepovím",
                            SurName = "Soukup",
                            UserId = "e2e36b69-61f7-4dae-bbe2-739e01adfda6",
                            Zip = "621 00"
                        },
                        new
                        {
                            InsuredId = 2,
                            City = "Praha 1",
                            Email = "zobakova.vlasta@seznam.cz",
                            FirstName = "Vlastimila",
                            Gender = 0,
                            Phone = "731 567 957",
                            Street = "Karlova 73",
                            SurName = "Zobáková",
                            UserId = "5e9cc9b8-31e3-4f15-b7e6-9ffb79287f54",
                            Zip = "110 00"
                        },
                        new
                        {
                            InsuredId = 3,
                            City = "Plzeň",
                            Email = "david.uplakanek@seznam.cz",
                            FirstName = "David",
                            Gender = 1,
                            Phone = "606 459 789",
                            Street = "Rejskova 43",
                            SurName = "Plaček",
                            Zip = "321 00"
                        },
                        new
                        {
                            InsuredId = 4,
                            City = "Pardubice",
                            Email = "sucho.jarin@seznam.cz",
                            FirstName = "Jaroslav",
                            Gender = 1,
                            Phone = "721 568 986",
                            Street = "Kosmonautů 98",
                            SurName = "Suchý",
                            Zip = "530 03"
                        },
                        new
                        {
                            InsuredId = 5,
                            City = "Kroměříž",
                            Email = "renatka.naruzivka@seznam.cz",
                            FirstName = "Renata",
                            Gender = 0,
                            Phone = "798 251 368",
                            Street = "Zvonková 45",
                            SurName = "Náruživá",
                            Zip = "767 01"
                        },
                        new
                        {
                            InsuredId = 6,
                            City = "Poděbrady",
                            Email = "horako.jana@seznam.cz",
                            FirstName = "Jana",
                            Gender = 0,
                            Phone = "607 899 456",
                            Street = "Sokolečská 93",
                            SurName = "Horáková",
                            Zip = "290 01"
                        },
                        new
                        {
                            InsuredId = 7,
                            City = "Ostrava",
                            Email = "vlasta.otevrel@seznam.cz",
                            FirstName = "Vlastimil",
                            Gender = 1,
                            Phone = "732 564 789",
                            Street = "Horní 25",
                            SurName = "Otevřel",
                            Zip = "700 30"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "ed1e00b3-56c7-4076-bcf2-14c7e6c5ba42",
                            ConcurrencyStamp = "03f8222e-627c-48e3-884c-0d90723544eb",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "e2e36b69-61f7-4dae-bbe2-739e01adfda6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e5077a54-57fa-48c3-875b-43842b46062a",
                            Email = "soukup.miloslav1@seznam.cz",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "SOUKUP.MILOSLAV1@SEZNAM.CZ",
                            NormalizedUserName = "SOUKUP.MILOSLAV1@SEZNAM.CZ",
                            PasswordHash = "AQAAAAEAACcQAAAAEChiF/H0cKhQXypgs3JJLbBUEiv1CwvIBEiYNQwcx+ZvuoCtWmNycVq4KiX6lOV4PQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8ebe85f4-58c5-4ff8-becd-ad4b12f5934d",
                            TwoFactorEnabled = false,
                            UserName = "soukup.miloslav1@seznam.cz"
                        },
                        new
                        {
                            Id = "5e9cc9b8-31e3-4f15-b7e6-9ffb79287f54",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a0d66d01-7651-4613-8f4f-e076bc9e17f8",
                            Email = "zobakova.vlasta@seznam.cz",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "ZOBAKOVA.VLASTA@SEZNAM.CZ",
                            NormalizedUserName = "ZOBAKOVA.VLASTA@SEZNAM.CZ",
                            PasswordHash = "AQAAAAEAACcQAAAAEChiF/H0cKhQXypgs3JJLbBUEiv1CwvIBEiYNQwcx+ZvuoCtWmNycVq4KiX6lOV4PQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7b4ea926-276c-47df-a788-bd8e96c7d982",
                            TwoFactorEnabled = false,
                            UserName = "zobakova.vlasta@seznam.cz"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "e2e36b69-61f7-4dae-bbe2-739e01adfda6",
                            RoleId = "ed1e00b3-56c7-4076-bcf2-14c7e6c5ba42"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EvidencePojisteni.Models.AssignedInsurances.AssignedInsurance", b =>
                {
                    b.HasOne("EvidencePojisteni.Models.Insurances.Insurance", "Insurance")
                        .WithMany()
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvidencePojisteni.Models.Insureds.Insured", "Insured")
                        .WithMany("AssignedInsurances")
                        .HasForeignKey("InsuredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insurance");

                    b.Navigation("Insured");
                });

            modelBuilder.Entity("EvidencePojisteni.Models.AssignedInsurances.AssignedInsurancesToPolicyholders", b =>
                {
                    b.HasOne("EvidencePojisteni.Models.AssignedInsurances.AssignedInsurance", "AssignedInsurance")
                        .WithMany()
                        .HasForeignKey("AssignedInsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvidencePojisteni.Models.Insureds.Insured", "Insured")
                        .WithMany("AssignedInsurancesToPolicyholders")
                        .HasForeignKey("InsuredId");

                    b.Navigation("AssignedInsurance");

                    b.Navigation("Insured");
                });

            modelBuilder.Entity("EvidencePojisteni.Models.InsuranceEvents.InsuranceEvent", b =>
                {
                    b.HasOne("EvidencePojisteni.Models.Insurances.Insurance", "Insurance")
                        .WithMany()
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvidencePojisteni.Models.Insureds.Insured", "Insured")
                        .WithMany()
                        .HasForeignKey("InsuredId");

                    b.Navigation("Insurance");

                    b.Navigation("Insured");
                });

            modelBuilder.Entity("EvidencePojisteni.Models.Insureds.Insured", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EvidencePojisteni.Models.Insureds.Insured", b =>
                {
                    b.Navigation("AssignedInsurances");

                    b.Navigation("AssignedInsurancesToPolicyholders");
                });
#pragma warning restore 612, 618
        }
    }
}
