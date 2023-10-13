using Homies.Data.Models;
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
        public async Task<IActionResult> Details(string eventId)
        {
            bool eventExists = await eventService
                .ExistsByIdAsync(eventId);
            if (!eventExists!)
            {
                return this.NotFound();
            }

            try
            {
                EventDetailsViewModel viewModel = await eventService
                    .GetDetailsByIdAsync(eventId);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string eventId)
        {
            //    bool houseExists = await eventService
            //        .ExistsByIdAsync(eventId);
            //    if (!houseExists)
            //    {
            return RedirectToAction("All", "Event");

            //        return this.NotFound(); 
            //    }

            //    try
            //    {
            //        EventFormViewModel formModel = await eventService
            //            .GetEventForEditByIdAsync(eventId);

            //        return View(formModel);
            //    }
            //    catch (Exception)
            //    {
            //        return View("Error");
            //    }
        }

        [HttpPost]
        public async Task<IActionResult> Join(string eventId)
        {
            var eEvent = await eventService.GetEventByIdAsync(eventId);
            if (eEvent == null)
            {
                return View("Error");
            }

            var userId = GetUserId();

            await eventService.JoinEventAsync(userId, eEvent);

            return RedirectToAction("Joined", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = GetUserId();
            var model = await this.eventService.GetJoinedEventsAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(string eventId)
        {
            var eevent = await eventService.GetEventByIdAsync(eventId);

            if (eevent == null)
            {
                return RedirectToAction("Joined", "Event");
            }

            var userId = GetUserId();

            await eventService.LeaveEventAsync(userId, eevent);

            return RedirectToAction("Joined", "Event");
        }
    }
}
