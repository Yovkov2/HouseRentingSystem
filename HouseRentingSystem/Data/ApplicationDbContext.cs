using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<IdentityUser>
    {
        // 1) declare fields to hold your seed‐objects
        private IdentityUser AgentUser { get; set; } = null!;
        private IdentityUser GuestUser { get; set; } = null!;

        private Agent Agent { get; set; } = null!;
        private Category CottageCategory { get; set; } = null!;
        private Category SingleCategory { get; set; } = null!;
        private Category DuplexCategory { get; set; } = null!;

        private House FirstHouse { get; set; } = null!;
        private House SecondHouse { get; set; } = null!;
        private House ThirdHouse { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 2) prepare all of our objects
            this.PrepareSeedData();

            // 3) register them with HasData()
            builder.Entity<IdentityUser>().HasData(this.AgentUser, this.GuestUser);
            builder.Entity<Agent>().HasData(this.Agent);
            builder.Entity<Category>().HasData(
                this.CottageCategory,
                this.SingleCategory,
                this.DuplexCategory
            );
            builder.Entity<House>().HasData(
                this.FirstHouse,
                this.SecondHouse,
                this.ThirdHouse
            );
        }

        private void PrepareSeedData()
        {
            // -- create users --
            var hasher = new PasswordHasher<IdentityUser>();
            this.AgentUser = new IdentityUser
            {
                Id = "agent-id-0001",
                UserName = "agent@rent.com",
                NormalizedUserName = "AGENT@RENT.COM",
                Email = "agent@rent.com",
                NormalizedEmail = "AGENT@RENT.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Agent123!")
            };
            this.GuestUser = new IdentityUser
            {
                Id = "guest-id-0001",
                UserName = "guest@rent.com",
                NormalizedUserName = "GUEST@RENT.COM",
                Email = "guest@rent.com",
                NormalizedEmail = "GUEST@RENT.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Guest123!")
            };

            // -- agent record --
            this.Agent = new Agent
            {
                Id = 1,
                PhoneNumber = "0123456789",
                UserId = this.AgentUser.Id
            };

            // -- categories --
            this.CottageCategory = new Category { Id = 1, Name = "Cozy Cottage" };
            this.SingleCategory = new Category { Id = 2, Name = "Single House" };
            this.DuplexCategory = new Category { Id = 3, Name = "Duplex" };

            // -- houses --
            this.FirstHouse = new House
            {
                Id = 1,
                Title = "Sunny Cottage by the Lake",
                Address = "123 Lakeview Drive, Countryside, CO 80000",
                Description = "A beautiful sunny cottage by the lake, perfect for summer getaways.",
                ImageUrl = "https://example.com/images/house1.jpg",
                PricePerMonth = 1200,
                CategoryId = this.CottageCategory.Id,
                AgentId = this.Agent.Id,
                RenterId = null
            };
            this.SecondHouse = new House
            {
                Id = 2,
                Title = "Modern Single Family Home",
                Address = "456 Maple Street, Suburbia, CA 90000",
                Description = "Spacious modern single-family home, close to schools and parks.",
                ImageUrl = "https://example.com/images/house2.jpg",
                PricePerMonth = 1600,
                CategoryId = this.SingleCategory.Id,
                AgentId = this.Agent.Id,
                RenterId = null
            };
            this.ThirdHouse = new House
            {
                Id = 3,
                Title = "Downtown Duplex Apartment",
                Address = "789 City Center Blvd, Metropolis, NY 10001",
                Description = "Two-bedroom duplex in the heart of the city, perfect for commuters.",
                ImageUrl = "https://example.com/images/house3.jpg",
                PricePerMonth = 2000,
                CategoryId = this.DuplexCategory.Id,
                AgentId = this.Agent.Id,
                RenterId = null
            };
        }
    }
}