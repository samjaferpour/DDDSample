using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigs
{
    public class ProductConfigs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            // Money as Value Object
            builder.OwnsOne(x => x.Price, pr =>
            {
                pr.Property(p => p.Amount).IsRequired()
                                          .HasColumnName("Price");
                
            });

            // Category as Owned Entity
            builder.OwnsOne(x => x.Category, cat =>
            {
                cat.Property(c => c.Name).IsRequired()
                                          .HasColumnName("CategoryName");
                cat.Property(c => c.Creator).IsRequired()
                                             .HasColumnName("CategoryCreator");
            });
        }
    }
}
