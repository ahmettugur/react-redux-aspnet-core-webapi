using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entity.Concrete;


namespace OnlineStore.Data.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.UserId);

            builder.Property(_ => _.UserId).HasColumnName("UserId");
            builder.Property(_ => _.FullName).HasColumnName("FullName");
            builder.Property(_ => _.Password).HasColumnName("Password");
            builder.Property(_ => _.Email).HasColumnName("Email");
        }
    }
}
