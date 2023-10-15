using Homies.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Homies.Services.Data.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();
        Task<bool> ExistsByIdAsync(string eventId);
        Task<EventDetailsViewModel> GetDetailsByIdAsync(string eventId);
        Task<AddEventViewModel> GetEventForEditByIdAsync(string eventId);
        Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId);
        Task JoinEventAsync(string userId, EventFormViewModel eEvent);
        Task<EventFormViewModel> GetEventByIdAsync(string eventId);
        Task LeaveEventAsync(string userId, EventFormViewModel eEvent);
        Task<AddEventViewModel> GetNewAddEventViewModelAsync();
        Task AddEventAsync(AddEventViewModel mode, string userId);
        Task EditEventAsync(AddEventViewModel model, string userId);
    }
}
