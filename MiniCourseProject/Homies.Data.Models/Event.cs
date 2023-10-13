using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace Homies.Data.Models
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

        [StringLength(150, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        [Required]
        public string OrganiserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(OrganiserId))]
        public virtual IdentityUser Organiser { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();
    }
}
