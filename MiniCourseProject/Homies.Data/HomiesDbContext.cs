using Homies.Data.Configurations;
using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly bool seedDb;
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new EventParticipantEntityConfiguration());
            builder
                .ApplyConfiguration(new EventEntityConfiguration());

            if (!seedDb)
            {
                builder
                    .ApplyConfiguration(new CategorySeederEntityConfiguration());
            }
            base.OnModelCreating(builder);
        }
    }
}