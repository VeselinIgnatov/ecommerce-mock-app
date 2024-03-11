using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.BillingAddress).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.AddeddBy).IsRequired();
            builder.Property(x => x.AddedOn).IsRequired();
            builder.Property(x => x.IsAdmin).IsRequired();
        }
    }
}
