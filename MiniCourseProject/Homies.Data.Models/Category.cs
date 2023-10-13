using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
