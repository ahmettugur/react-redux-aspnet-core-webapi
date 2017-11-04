using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entity.Concrete;

namespace OnlineStore.Data.EntityFramework.Mappings
{
    public class ProductMap: IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).HasColumnName("Id");
            builder.Property(_ => _.CategoryId).HasColumnName("CategoryId");
            builder.Property(_ => _.Name).HasColumnName("Name");
            builder.Property(_ => _.Details).HasColumnName("Details");
            builder.Property(_ => _.Price).HasColumnName("Price");
            builder.Property(_ => _.StockQuantity).HasColumnName("StockQuantity");
        }
    }
}
