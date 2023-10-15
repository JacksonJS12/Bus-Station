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