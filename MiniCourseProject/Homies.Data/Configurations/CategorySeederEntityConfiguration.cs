using Homies.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homies.Data.Configurations
{
    public class CategorySeederEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasData(GenerateCategories());

            builder
                .HasMany(c => c.Events)
                .WithOne(e => e.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category>categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Animals"
            };

            category = new Category()
            {
                Id = 2,
                Name = "Fun"
            };

            category = new Category()
            {
                Id = 3,
                Name = "Discussion"
            };

            category = new Category()
            {
                Id = 4,
                Name = "Work"
            };

            return categories.ToArray();

        }
    }
}
