﻿namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidation.Category;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
