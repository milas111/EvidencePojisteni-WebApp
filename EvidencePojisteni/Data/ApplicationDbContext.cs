using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EvidencePojisteni.Models.Insureds;
using EvidencePojisteni.Models.Insurances;
using EvidencePojisteni.Models.AssignedInsurances;
using EvidencePojisteni.Models.InsuranceEvents;
using Microsoft.AspNetCore.Identity;

namespace EvidencePojisteni.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<Insured> Insured { get; set; }
        public DbSet<AssignedInsurance> AssignedInsurance { get; set; }
        public DbSet<EvidencePojisteni.Models.AssignedInsurances.AssignedInsurancesToPolicyholders> AssignedInsurancesToPolicyholders { get; set; }
        public DbSet<EvidencePojisteni.Models.InsuranceEvents.InsuranceEvent> InsuranceEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Insurance>().HasData
                (
                new Insurance()
                {
                    InsuranceId = 1,
                    InsuranceName = "Pojištění majetku",
                    InsuranceDescription = "Pojištění majetku, zahrnuje pojištění nemovitosti a domácnosti, vám bude krýt záda v případě škody způsobené přírodními živly nebo zlodějem. Co všechno lze pojistit? Domáctnost: Vztahuje se na vybavení domu nebo bytu.Nemovitost: Vztahuje se na stavbu a veškeré její pevné součásti. Odpovědnost za škodu: Pokryje škody na cizím majetku nebo újmu na zdraví.",
                    InsuranceImage = "propertyInsurance.png"
                },
                new Insurance()
                {
                    InsuranceId = 2,
                    InsuranceName = "Cestovní pojištění",
                    InsuranceDescription = "Základní cestovní pojištění kryje veškeré léčebné výlohy. Z tohoto pojištění Vám bude proplacena případná zdravotní péče v zahraničí. Pojišťovna za vás uhradí: Náklady na ošetření, hospitalizaci,léky, nezbytné převozy a repatriaci, převoz tělesných ostatků.",
                    InsuranceImage = "travel-insurance.jpg"
                },
                new Insurance()
                {
                    InsuranceId = 3,
                    InsuranceName = "Pojištění vozidel",
                    InsuranceDescription = "Každý majitel vozidla musí mít sjednané povinné ručení. Povinné ručení vás chrání v případě, že způsobíte dopravní nehodu: vyrovná za vás škody na autě, majetku i zdraví poškozených osob.",
                    InsuranceImage = "vehicle-insurance.png"
                },
                new Insurance()
                {
                    InsuranceId = 4,
                    InsuranceName = "Životní pojištění",
                    InsuranceDescription = "Životní pojištění finančně podrží vás i vaše blízké v případě smrti, úrazu s trvalými následky nebo dlouhodobé nemoci. Krytí si můžete vybrat tak, aby vyhovovalo vašim potřebám.",
                    InsuranceImage = "life-insurance.jpg"
                }
                );

            builder.Entity<IdentityUser>().HasData
                (
                new IdentityUser() { Id = "a1b2c3d4e5f6g7h8", UserName = "soukup.miloslav1@seznam.cz", Email = "soukup.miloslav1@seznam.cz", NormalizedEmail = "SOUKUP.MILOSLAV1@SEZNAM.CZ", NormalizedUserName = "SOUKUP.MILOSLAV1@SEZNAM.CZ", PasswordHash = "AQAAAAEAACcQAAAAEChiF/H0cKhQXypgs3JJLbBUEiv1CwvIBEiYNQwcx+ZvuoCtWmNycVq4KiX6lOV4PQ==", LockoutEnabled = true },
                new IdentityUser() { Id = "b2c3d4e5f6g7h8i9", UserName = "zobakova.vlasta@seznam.cz", Email = "zobakova.vlasta@seznam.cz", NormalizedEmail = "ZOBAKOVA.VLASTA@SEZNAM.CZ", NormalizedUserName = "ZOBAKOVA.VLASTA@SEZNAM.CZ", PasswordHash = "AQAAAAEAACcQAAAAEChiF/H0cKhQXypgs3JJLbBUEiv1CwvIBEiYNQwcx+ZvuoCtWmNycVq4KiX6lOV4PQ==", LockoutEnabled = true }
                );

            builder.Entity<Insured>().HasData
               (
               new Insured() { InsuredId = 1, Email = "soukup.miloslav1@seznam.cz", FirstName = "Miloslav", SurName = "Soukup", Gender = Gender.Man, Phone = "neznámé číslo", Street = "Nepovím", Zip = "621 00", City = "Brno", UserId = "a1b2c3d4e5f6g7h8" },
               new Insured() { InsuredId = 2, Email = "zobakova.vlasta@seznam.cz", FirstName = "Vlastimila", SurName = "Zobáková", Gender = Gender.Woman, Phone = "731 567 957", Street = "Karlova 73", Zip = "110 00", City = "Praha 1", UserId = "b2c3d4e5f6g7h8i9" },
               new Insured() { InsuredId = 3, Email = "david.uplakanek@seznam.cz", FirstName = "David", SurName = "Plaček", Gender = Gender.Man, Phone = "606 459 789", Street = "Rejskova 43", Zip = "321 00", City = "Plzeň" },
               new Insured() { InsuredId = 4, Email = "sucho.jarin@seznam.cz", FirstName = "Jaroslav", SurName = "Suchý", Gender = Gender.Man, Phone = "721 568 986", Street = "Kosmonautů 98", Zip = "530 03", City = "Pardubice" },
               new Insured() { InsuredId = 5, Email = "renatka.naruzivka@seznam.cz", FirstName = "Renata", SurName = "Náruživá", Gender = Gender.Woman, Phone = "798 251 368", Street = "Zvonková 45", Zip = "767 01", City = "Kroměříž" },
               new Insured() { InsuredId = 6, Email = "horako.jana@seznam.cz", FirstName = "Jana", SurName = "Horáková", Gender = Gender.Woman, Phone = "607 899 456", Street = "Sokolečská 93", Zip = "290 01", City = "Poděbrady" },
               new Insured() { InsuredId = 7, Email = "vlasta.otevrel@seznam.cz", FirstName = "Vlastimil", SurName = "Otevřel", Gender = Gender.Man, Phone = "732 564 789", Street = "Horní 25", Zip = "700 30", City = "Ostrava" }
               );

            builder.Entity<AssignedInsurance>().HasData
                (
                new AssignedInsurance() { AssignedInsuranceId = 1, InsuranceId = 1, InsuredId = 2, InsuranceRole = InsuranceRole.Insured, Issue = "Byt", Value = 1000000, ValidFrom = new System.DateTime(2022, 01, 01), ValidTo = new System.DateTime(2022, 12, 31) },
                new AssignedInsurance() { AssignedInsuranceId = 2, InsuranceId = 2, InsuredId = 2, InsuranceRole = InsuranceRole.Policyholder, Issue = "Do zahraničí", Value = 1000, ValidFrom = new System.DateTime(2022, 08, 01), ValidTo = new System.DateTime(2022, 08, 15) },
                new AssignedInsurance() { AssignedInsuranceId = 3, InsuranceId = 3, InsuredId = 1, InsuranceRole = InsuranceRole.Insured, Issue = "Povinné ručení", Value = 2000, ValidFrom = new System.DateTime(2022, 03, 01), ValidTo = new System.DateTime(2022, 12, 31), Paid = true },
                new AssignedInsurance() { AssignedInsuranceId = 4, InsuranceId = 4, InsuredId = 3, InsuranceRole = InsuranceRole.Insured, Issue = "Úraz", Value = 3000, ValidFrom = new System.DateTime(2022, 01, 01), ValidTo = new System.DateTime(2022, 12, 31) }
                );

            builder.Entity<AssignedInsurancesToPolicyholders>().HasData
                (
                new AssignedInsurancesToPolicyholders() { Id = 1, AssignedInsuranceId = 3, InsuredId = 2 },
                new AssignedInsurancesToPolicyholders() { Id = 2, AssignedInsuranceId = 4, InsuredId = 2 }
                );

            builder.Entity<InsuranceEvent>().HasData
                (
                new InsuranceEvent() { InsuranceEventId = 1, InsuranceId = 1, InsuredId = 2, EventDate = new System.DateTime(2022, 07, 23), EventDescription = "Byl nám vytopen byt sousedy.", AccountNumber = "1234567891234567", BankCode = "0100", Email = "zobakova.vlasta@seznam.cz", FirstName = "Vlastimila", SurName = "Zobáková", Gender = Gender.Woman, Phone = "731 567 957", Street = "Karlova 73", Zip = "110 00", City = "Praha 1" }
                );
        }
    }
}
