using Homies.Data;
using Homies.Services.Data.Interfaces;
using Homies.Web.ViewModels;
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
                    Start = $"{e.Start}",
                    Category = $"{e.Category}"

                }).ToArrayAsync();
        }
    }
}
