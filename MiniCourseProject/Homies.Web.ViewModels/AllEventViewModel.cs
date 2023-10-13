using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homies.Web.ViewModels
{
    public class AllEventViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Start { get; set; }

        public string Category { get; set; } = null!;
        public string OrganiserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(OrganiserId))]
        public virtual IdentityUser Organiser { get; set; } = null!;
    }
}
