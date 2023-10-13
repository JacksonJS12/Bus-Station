using Homies.Data;
using Homies.Data.Models;
using Homies.Services.Data.Interfaces;
using Homies.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services.Data
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await this.dbContext
                .Events
                .Select(e => new AllEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("dd/MM/yyyy HH:mm tt"),
                    OrganiserId = e.OrganiserId,
                    Organiser = e.Organiser,
                    Category = e.Category.Name,

                }).ToArrayAsync();
        }

        public async Task<bool> ExistsByIdAsync(string eventId)
        {
            bool result = await dbContext
                .Events
                .Where(e => e.IsActive)
                .AnyAsync(e => e.Id.ToString() == eventId);

            return result;
        }

        public async Task<EventDetailsViewModel> GetDetailsByIdAsync(string eventId)
        {
            Event eEvent = await dbContext
                .Events
                .Include(e => e.Organiser)
                .Include(e => e.Category)
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == eventId);

            return new EventDetailsViewModel
            {
                Id = eEvent.Id,
                Name = eEvent.Name,
                Description = eEvent.Description,
                Start = eEvent.Start.ToString("dd/MM/yyyy HH:mm tt"),
                End = eEvent.End.ToString("dd/MM/yyyy HH:mm tt"),
                Organiser = eEvent.Organiser.UserName,
                CreatedOn = eEvent.CreatedOn.ToString("dd/MM/yyyy HH:mm tt"),
                Category = eEvent.Category.Name
            };
        }

        public async Task<EventFormViewModel> GetEventForEditByIdAsync(string eventId)
        {
            Event eEvent = await dbContext
                .Events
                .Include(e => e.Category)
                .Where(e => e.IsActive)
                .FirstAsync(e => e.Id.ToString() == eventId);

            return new EventFormViewModel()
            {
                Id = eEvent.Id,
                Name = eEvent.Name,
                Description = eEvent.Description,
                Start = eEvent.Start,
                End = eEvent.End,
                Category = eEvent.Category.Name
            };
        }

        public async Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await dbContext
                .EventParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(e => new AllEventViewModel
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    Start = e.Event.Start.ToString("dd/MM/yyyy HH:mm tt"),
                    Category = e.Event.Category.Name,
                    OrganiserId = e.Event.OrganiserId,
                    Organiser = e.Event.Organiser
                }).ToListAsync();
        }

        public async Task JoinEventAsync(string userId, EventFormViewModel eEvent)
        {
            bool alderyAdded = await dbContext
                .EventParticipants
                .AnyAsync(ep => ep.HelperId == userId && ep.EventId == eEvent.Id);

            if (!alderyAdded)
            {
                EventParticipant eventParticipant = new EventParticipant()
                {
                    EventId = eEvent.Id,
                    HelperId = userId
                };

                await dbContext.EventParticipants.AddAsync(eventParticipant);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<EventFormViewModel> GetEventByIdAsync(string eventId)
        {
           
            return await dbContext
                .Events
                .Where(e => e.Id == Guid.Parse(eventId))
                .Select(e => new EventFormViewModel 
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Start = e.Start,
                End = e.End,
                Category = e.Category.Name
            }).FirstOrDefaultAsync();
        }

        public async Task LeaveEventAsync(string userId, EventFormViewModel eevent)
        {
            var eventParticipant = await dbContext.EventParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == userId && ep.EventId == eevent.Id);

            if (eventParticipant != null)
            {
                dbContext.EventParticipants.Remove(eventParticipant);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
