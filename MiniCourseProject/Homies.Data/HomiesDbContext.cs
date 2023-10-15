namespace Homies.Data
{
    using Models;
    using Configurations;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;


    public class HomiesDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly bool seedDb;
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventEntityConfiguration());
            builder.ApplyConfiguration(new EventParticipantEntityConfiguration());

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new EventSeederEntityConfiguration());
                builder.ApplyConfiguration(new CategorySeederEntityConfiguration());
            }

            base.OnModelCreating(builder);
        }
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<EventParticipant> EventParticipants { get; set; } = null!;
    }
}