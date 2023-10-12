using Homies.Web.ViewModels;

namespace Homies.Services.Data.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();
    }
}
