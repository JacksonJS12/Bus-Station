namespace Homies.Web.Controllers
{
    using ViewModels;
    using Homies.Services.Data.Interfaces;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
            if (!eventExists)
            {
                return this.NotFound();
            }

            try
            {
                EventDetailsViewModel viewModel = await eventService
                    .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Join(string eventId)
        {
            var @event = await eventService.GetEventByIdAsync(eventId);
            if (@event == null)
            {
                return View("Error");
            }

            var userId = GetUserId();


            await eventService.JoinEventAsync(userId, @event);


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
        public async Task<IActionResult> Leave(string id)
        {
            var @event = await eventService.GetEventByIdAsync(id);

            if (@event == null)
            {
                return RedirectToAction("Joined", "Event");
            }

            var userId = GetUserId();

            await eventService.LeaveEventAsync(userId, @event);

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEventViewModel model = await eventService.GetNewAddEventViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string userId = GetUserId();

            await eventService.AddEventAsync(model, userId);

            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            AddEventViewModel @event = await eventService.GetEventForEditByIdAsync(id);

            if (@event == null)
            {
                return RedirectToAction("All", "Event");
            }

            return View(@event);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await eventService.EditEventAsync(model, id);

            return RedirectToAction("All", "Event");
        }
    }
}
