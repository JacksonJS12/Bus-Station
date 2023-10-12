using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        [ForeignKey(nameof(Helper))]
        public Guid HelperId { get; set; }

        [Required]
        public virtual ApplicationUser Helper { get; set; } = null!;

        [ForeignKey(nameof(Event))]
        public Guid EventId { get; set; }

        [Required]
        public virtual Event Event { get; set; } = null!;
    }
}