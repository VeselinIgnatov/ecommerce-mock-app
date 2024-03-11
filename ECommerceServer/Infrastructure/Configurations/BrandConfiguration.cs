using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.AddeddBy).IsRequired();
            builder.Property(x => x.AddedOn).IsRequired();

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Brand);

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Brands);
        }
    }
}
