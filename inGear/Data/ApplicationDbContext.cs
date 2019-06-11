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

            

            modelBuilder.Entity<Condition>().HasData(
                new Condition()
                {
                    ConditionId = 1,
                    Label = "Poor but functioning"
                },
                new Condition()
                {
                    ConditionId = 2,
                    Label = "Fair but noticable cosmetic damage"
                },
                new Condition()
                {
                    ConditionId = 3,
                    Label = "Good with minor cosmetic damage"
                },
                new Condition()
                {
                    ConditionId = 4,
                    Label = "Excellent with no noticable cosmetic damage"
                },
                new Condition()
                {
                    ConditionId = 5,
                    Label = "Mint condition"
                }
            );
        }
    }
}
