using Homies.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Web.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public async Task<ActionResult> All()
        {
            var model = await this.eventService.GetAllEventsAsync();

            return View(model);
        }
    }
}
