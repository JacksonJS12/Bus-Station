namespace Homies.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .Property(e => e.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(e => e.Organiser)
                .WithMany()
                .HasForeignKey(e => e.OrganiserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(h => h.IsActive)
                .HasDefaultValue(true);
        }
    }
}
