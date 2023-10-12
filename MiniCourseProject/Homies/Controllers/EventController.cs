using Homies.Services.Data;
using Homies.Services.Data.Interfaces;
using Homies.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool eventExists = await eventService
                .ExistsByIdAsync(id);
            if (!eventExists!)
            {
                return RedirectToAction("All", "Event");
            }

            try
            {
                EventDetailsViewModel viewModel = await eventService
                    .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool houseExists = await eventService
                .ExistsByIdAsync(id);
            if (!houseExists)
            {
                //return RedirectToAction("All", "Event");

                return this.NotFound(); 
            }

            try
            {
                EventFormViewModel formModel = await eventService
                    .GetEventForEditByIdAsync(id);

                return View(formModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Join(string id)
        //{
        //    await eventService.JoinEvent
        //}
    }
}
