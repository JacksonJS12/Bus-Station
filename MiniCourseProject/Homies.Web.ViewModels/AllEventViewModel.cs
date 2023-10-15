using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homies.Web.ViewModels
{
    public class AllEventViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string Category { get; set; } = null!;
        public string OrganiserId { get; set; } = null!;

        public virtual IdentityUser Organiser { get; set; } = null!;
    }
}
