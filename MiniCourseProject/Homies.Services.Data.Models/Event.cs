using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Homies.Data.Models;

namespace Homies.Services.Data.Models
{
    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        [StringLength(150)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Organiser))]
        public Guid OrganiserId { get; set; }

        public virtual ApplicationUser Organiser { get; set; }
    }
}
