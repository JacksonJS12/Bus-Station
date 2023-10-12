using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        public string HelperId { get; set; } = null!;

        [ForeignKey(nameof(HelperId))]
        public virtual IdentityUser Helper { get; set; } = null!;

        public Guid EventId { get; set; } 

        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; } = null!;
    }
}