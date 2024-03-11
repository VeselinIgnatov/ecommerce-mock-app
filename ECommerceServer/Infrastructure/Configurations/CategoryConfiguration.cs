using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.AddeddBy).IsRequired();
            builder.Property(x => x.AddedOn).IsRequired();

            builder.HasMany(x => x.Brands)
                .WithMany(x => x.Categories);

            builder.HasMany(x => x.Products)
                .WithMany(x => x.Categories);

        }
    }
}
