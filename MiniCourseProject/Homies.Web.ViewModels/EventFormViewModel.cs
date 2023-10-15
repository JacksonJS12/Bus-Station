namespace Homies.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class EventFormViewModel
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        [StringLength(20, MinimumLength = 10)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 50)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public string Category { get; set; } = null!;
        public string CategoryId { get; set; } = null!;
    }
}
