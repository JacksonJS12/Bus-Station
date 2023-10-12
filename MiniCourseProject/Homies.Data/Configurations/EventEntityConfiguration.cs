using Homies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homies.Data.Configurations
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .Property(e => e.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasMany(e => e.EventsParticipants)
                .WithOne(ep => ep.Event)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Organiser)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.OrganiserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
