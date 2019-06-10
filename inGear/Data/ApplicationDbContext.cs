using System;
using System.Collections.Generic;
using System.Text;
using inGear.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inGear.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gear> Inventory { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Order>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Order>()
                .Property(b => b.ReturnDate)
                .HasDefaultValueSql("DATEADD(day, 7, DateCreated)");

            modelBuilder.Entity<PaymentType>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                StreetAddress = "123 Broadway Ave",
                City = "Nashville",
                State = "TN",
                ZipCode = "37201",
                Phone = "555-555-5555",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")

            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser test = new ApplicationUser
            {
                FirstName = "Test",
                LastName = "User",
                StreetAddress = "321 Brasher Ave",
                City = "Nashville",
                State = "TN",
                ZipCode = "37206",
                Phone = "555-555-5555",
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            test.PasswordHash = passwordHash2.HashPassword(test, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(test);

            ////////////////////////////////////////////
            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType()
                {
                    PaymentTypeId = 1,
                    UserId = user.Id,
                    CardType = "American Express",
                    AccountNumber = "86753095551212",
                    ExpiryDate = "11/2022"

                },
                new PaymentType()
                {
                    PaymentTypeId = 2,
                    UserId = user.Id,
                    CardType = "Discover",
                    AccountNumber = "4102948572991"
                },
                new PaymentType()
                {
                    PaymentTypeId = 3,
                    UserId = test.Id,
                    CardType = "VISA",
                    AccountNumber = "8374958468590"
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    Label = "Electric Guitars"
                },
                new Category()
                {
                    CategoryId = 2,
                    Label = "Acoustic Guitars"
                },
                new Category()
                {
                    CategoryId = 3,
                    Label = "Bass Guitars"
                },
                new Category()
                {
                    CategoryId = 4,
                    Label = "Amps"
                },
                new Category()
                {
                    CategoryId = 5,
                    Label = "Effects and Pedals"
                },
                new Category()
                {
                    CategoryId = 6,
                    Label = "Drums and Percussion"
                },
                new Category()
                {
                    CategoryId = 7,
                    Label = "Pro Audio"
                },
                new Category()
                {
                    CategoryId = 8,
                    Label = "Keyboards and Synths"
                },
                new Category()
                {
                    CategoryId = 9,
                    Label = "DJ and Lighting Gear"
                },
                new Category()
                {
                    CategoryId = 10,
                    Label = "Folk"
                },
                new Category()
                {
                    CategoryId = 11,
                    Label = "Band and Orchestra"
                },
                new Category()
                {
                    CategoryId = 12,
                    Label = "Accessories"
                },
                new Category()
                {
                    CategoryId = 13,
                    Label = "Services"
                }
            );

            modelBuilder.Entity<Gear>().HasData(
                new Gear()
                {
                    UserId = user.Id,
                    Description = "",
                    Make = "Korg",
                    Model = "Minilogue",
                    SerialNumber = "1A24B234K567",
                    ImagePath = "",
                    Value = 499.99,
                    RentalPrice = 25.00,
                    Quantity = 1,
                    CategoryId = 8,
                    Insurance = true,
                    Rentable = true,
                    Rented = false
                },
                new Gear()
                {
                    UserId = user.Id,
                    Description = "The one and only.",
                    Make = "Roland",
                    Model = "Juno 106",
                    SerialNumber = "3A24B234K567",
                    ImagePath = "",
                    Value = 1099.99,
                    RentalPrice = 75.00,
                    Quantity = 1,
                    CategoryId = 8,
                    Insurance = true,
                    Rentable = true,
                    Rented = false
                },
                new Gear()
                {
                    UserId = user.Id,
                    Description = "Everly Brothers Style",
                    Make = "Gibson",
                    Model = "J-180",
                    SerialNumber = "901A24B234K567",
                    ImagePath = "",
                    Value = 2999.99,
                    RentalPrice = 50.00,
                    Quantity = 1,
                    CategoryId = 2,
                    Insurance = true,
                    Rentable = true,
                    Rented = false
                },
                new Gear()
                {
                    UserId = test.Id,
                    Description = "",
                    Make = "Ibanez",
                    Model = "Tube Screamer",
                    SerialNumber = "331A24B234K567",
                    ImagePath = "",
                    Value = 150.99,
                    RentalPrice = 25.00,
                    Quantity = 2,
                    CategoryId = 5,
                    Insurance = true,
                    Rentable = false,
                    Rented = false
                },
                new Gear()
                {
                    UserId = test.Id,
                    Description = "Vintage. White body and sanded neck.",
                    Make = "Fender",
                    Model = "Stratocaster",
                    SerialNumber = "7771A24B234K567",
                    ImagePath = "",
                    Value = 1299.99,
                    RentalPrice = 50.00,
                    Quantity = 1,
                    CategoryId = 1,
                    Insurance = true,
                    Rentable = true,
                    Rented = false
                },
                new Gear()
                {
                    UserId = test.Id,
                    Description = "The microphone Michael Jackson used on Thriller",
                    Make = "Sony",
                    Model = "SM7",
                    SerialNumber = "SM71A24B234K567",
                    ImagePath = "",
                    Value = 399.99,
                    RentalPrice = 25.00,
                    Quantity = 1,
                    CategoryId = 7,
                    Insurance = true,
                    Rentable = true,
                    Rented = true
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    OrderId = 1,
                    UserId = user.Id,
                    PaymentTypeId = null
                }
            );

            modelBuilder.Entity<Condition>().HasData(
                new Condition()
                {
                    ConditionId = 1,
                    Label = "Poor but functioning",
                },
                new Condition()
                {
                    ConditionId = 2,
                    Label = "Fair but noticable cosmetic damage",
                },
                new Condition()
                {
                    ConditionId = 3,
                    Label = "Good with minor cosmetic damage",
                },
                new Condition()
                {
                    ConditionId = 4,
                    Label = "Excellent with no noticable cosmetic damage",
                },
                new Condition()
                {
                    ConditionId = 5,
                    Label = "Mint condition",
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order()
                {

         UserId = user.Id, 
         RenterId = test.Id,
         GearId = 2,  
       Completed = false
    }
            );

        }
    }
}
