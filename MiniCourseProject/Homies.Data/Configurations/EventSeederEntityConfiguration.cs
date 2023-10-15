namespace Homies.Data.Configurations
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventSeederEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(this.GenerateEvents());
        }

        private Event[] GenerateEvents()
        {
            ICollection<Event> events = new HashSet<Event>();

            Event @event;

            @event = new Event()
            {
                Id = Guid.Parse("adedd079-eb04-4617-9cd4-1a1573b275ea"),
                Name = "Garden Cleaning",
                Description =
                    "Bring together gardeners of all ages from your community to organize a garden or local green space cleanup! ",
                Start = DateTime.Parse("2023-06-01 9:00"),
                End = DateTime.Parse("2023-06-11 11:00"),
                OrganiserId = "de4034a1-7c83-4272-b3cc-fb7e58a7ac8a",
                CategoryId = 4
            };
            events.Add(@event);

            @event = new Event()
            {

                Id = Guid.Parse("d9e905c5-8b0b-43ea-b7d8-2685d0e62417"),
                Name = "Fun Dog Day",
                Description = "We know that the best things in life are furry." +
                              " That’s why A Doggy Day Out has been making tails wag since 2016. ",
                Start = DateTime.Parse("2023-06-11 10:00"),
                End = DateTime.Parse("2023-06-11 12:00"),
                OrganiserId = "de4034a1-7c83-4272-b3cc-fb7e58a7ac8a",
                CategoryId = 1
            };
            events.Add(@event);

            @event = new Event()
            {

                Id = Guid.Parse("723d86de-3d9a-44cf-8d41-4d7df6ec57d6"),
                Name = "Cultural Food Fest",
                Description = "Enjoy the taste of world's kitchen in your local park.",
                Start = DateTime.Parse("2023-10-13 13:00"),
                End = DateTime.Parse("2023-10-15 12:00"),
                OrganiserId = "f372d108-000b-4823-85f8-4b852cafda67",
                CategoryId = 3
            };
            events.Add(@event);

            @event = new Event()
            {

                Id = Guid.Parse("7406248b-1808-4e40-b1c2-858679230269"),
                Name = "Charity Concert",
                Description = "Local teen bands hosting a concert to help their teacher pay for his cancer treatment.",
                Start = DateTime.Parse("2023-11-16 18:00"),
                End = DateTime.Parse("2023-11-16 22:00"),
                OrganiserId = "de4034a1-7c83-4272-b3cc-fb7e58a7ac8a",
                CategoryId = 2
            };
            events.Add(@event);

            return events.ToArray();
        }
    }
}
