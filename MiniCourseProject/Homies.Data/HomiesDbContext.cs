using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext<IdentityUser>
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<EventParticipant>()
                .HasKey(x => new { x.HelperId, x.EventId });

            builder
                .Entity<Event>()
                .Property(e => e.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Entity<Category>()
                .HasData(
                    new Category()
                    {
                        Id = 1,
                        Name = "Animals"
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "Fun"
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Discussion"
                    },
                    new Category()
                    {
                        Id = 4,
                        Name = "Work"
                    });

            builder
                .Entity<Event>()
                .HasData(
                    new Event()
                    {
                        Id = Guid.Parse("adedd079-eb04-4617-9cd4-1a1573b275ea"),
                        Name = "Garden Cleaning",
                        Description =
                        "Bring together gardeners of all ages from your community to organize a garden or local green space cleanup! ",
                        Start = DateTime.Parse("2023-06-01 9:00"),
                        End = DateTime.Parse("2023-06-11 11:00"),
                        OrganiserId = "de4034a1-7c83-4272-b3cc-fb7e58a7ac8a",
                        CategoryId = 4
                    },
                    new Event()
                    {
                        Id = Guid.Parse("d9e905c5-8b0b-43ea-b7d8-2685d0e62417"),
                        Name = "Fun Dog Day",
                        Description = "We know that the best things in life are furry." +
                              " That’s why A Doggy Day Out has been making tails wag since 2016. ",
                        Start = DateTime.Parse("2023-06-11 10:00"),
                        End = DateTime.Parse("2023-06-11 12:00"),
                        OrganiserId = "de4034a1-7c83-4272-b3cc-fb7e58a7ac8a",
                        CategoryId = 1
                    });

            builder
                .Entity<Event>()
                .HasOne(e => e.Organiser)
                .WithMany()
                .HasForeignKey(e => e.OrganiserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<Event>()
                .Property(h => h.IsActive)
                .HasDefaultValue(true);

            base.OnModelCreating(builder);
        }
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<EventParticipant> EventParticipants { get; set; } = null!;
    }
}