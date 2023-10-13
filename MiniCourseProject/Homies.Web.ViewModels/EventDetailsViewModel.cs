using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Homies.Web.ViewModels
{
    public class EventDetailsViewModel : AllEventViewModel
    {
        public string End { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Organiser { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;
    }
}
/*
  <div class="card-body">
            <h3 class="card-title text-center">@Model.Name</h3>
            <p class="mb-0"><span class="fw-bold">Description: </span>@Model.Description</p>
            <p class="mb-0"><span class="fw-bold">Starting time: </span>@Model.Start</p>
            <p class="mb-0"><span class="fw-bold">Estimated ending time: </span>@Model.End</p>
            <p class="mb-0"><span class="fw-bold">Organiser: </span>@Model.Organiser</p>
            <p class="mb-0"><span class="fw-bold">Created on: </span>@Model.CreatedOn</p>
            <p class="mb-0"><span class="fw-bold">Category: </span>@Model.Category</p>
        </div>

        <a asp-controller="Event" asp-action="All" class="btn btn-warning mb-2 w-100 p-3 fw-bold">Back to All Events</a>
        @if (User.Identity.Name == Model.Organiser)
        {
            <a asp-controller="Event" asp-action="Edit" asp-route-id="@Model.Id" class="btn btn-warning mb-2 w-100 p-3 fw-bold">Edit</a>
        }

 */