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
                    Id = e.Id.ToString(),
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
                Id = eEvent.Id.ToString(),
                Name = eEvent.Name,
                Description = eEvent.Description,
                Start = eEvent.Start.ToString("dd/MM/yyyy HH:mm tt"),
                End = eEvent.End.ToString("dd/MM/yyyy HH:mm tt"),
                Organiser = eEvent.Organiser.UserName,
                CreatedOn = eEvent.CreatedOn.ToString("dd/MM/yyyy HH:mm tt"),
                Category = eEvent.Category.Name
            };
        }

        public async Task<AddEventViewModel> GetEventForEditByIdAsync(string eventId)
        {
            var categories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return await dbContext
                .Events
                .Where(e => e.Id == Guid.Parse(eventId))
                .Select(e => new AddEventViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    Categories = categories
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await dbContext
                .EventParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(e => new AllEventViewModel
                {
                    Id = e.Event.Id.ToString(),
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

        public async Task<EventFormViewModel>? GetEventByIdAsync(string eventId)
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

        public async Task LeaveEventAsync(string userId, EventFormViewModel eEvent)
        {
            var eventParticipant = await dbContext.EventParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == userId && ep.EventId == eEvent.Id);

            if (eventParticipant != null)
            {
                dbContext.EventParticipants.Remove(eventParticipant);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddEventViewModel> GetNewAddEventViewModelAsync()
        {
            var categories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            var model = new AddEventViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task AddEventAsync(AddEventViewModel model, string userId)
        {
            Event eEvent = new Event
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                OrganiserId = userId,
                Start = model.Start,
                End = model.End
            };

            await dbContext.Events.AddAsync(eEvent);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditEventAsync(AddEventViewModel model, string eventId)
        {
            Event? eevent = await dbContext
                .Events
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id.ToString() == eventId);
            Category? category = await dbContext.Categories.FindAsync(model.CategoryId);

            eevent.Name = model.Name;
            eevent.Description = model.Description;
            eevent.Start = model.Start;
            eevent.End = model.End;
            eevent.CategoryId = model.CategoryId;
            //eevent.Category = category;



            await dbContext.SaveChangesAsync();


        }
    }
}
