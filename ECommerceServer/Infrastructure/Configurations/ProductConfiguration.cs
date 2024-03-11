using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x =>x.Description).IsRequired();
            builder.Property(x => x.AddeddBy).IsRequired();
            builder.Property(x => x.AddedOn).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.BrandId).IsRequired();

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Products);
        }
    }
}
