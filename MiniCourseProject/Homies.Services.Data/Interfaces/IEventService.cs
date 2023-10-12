using Homies.Web.ViewModels;

namespace Homies.Services.Data.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();
        Task<bool> ExistsByIdAsync(string eventId);
        Task<EventDetailsViewModel> GetDetailsByIdAsync(string eventId);
        Task<EventFormViewModel> GetEventForEditByIdAsync(string id);
    }
}
