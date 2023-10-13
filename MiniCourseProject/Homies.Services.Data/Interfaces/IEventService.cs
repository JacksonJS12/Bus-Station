using Homies.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Homies.Services.Data.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();
        Task<bool> ExistsByIdAsync(string eventId);
        Task<EventDetailsViewModel> GetDetailsByIdAsync(string eventId);
        Task<EventFormViewModel> GetEventForEditByIdAsync(string userId);
        Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId);
        Task JoinEventAsync(string userId, EventFormViewModel eEvent);
        Task<EventFormViewModel> GetEventByIdAsync(string eventId);
        Task LeaveEventAsync(string userId, EventFormViewModel eevent);
    }
}
