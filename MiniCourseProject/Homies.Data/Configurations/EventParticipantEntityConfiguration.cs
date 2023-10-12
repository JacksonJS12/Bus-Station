using Homies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homies.Data.Configurations
{
    public class EventParticipantEntityConfiguration : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder
                .HasKey(x => new { x.HelperId, x.EventId});
        }
    }
}
