using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entity.Concrete;

namespace OnlineStore.Data.EntityFramework.Mappings
{
    public class UserRoleMap: IEntityTypeConfiguration<UserRole>
    {

        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).HasColumnName("Id");
            builder.Property(_ => _.RoleId).HasColumnName("RoleId");
            builder.Property(_ => _.UserId).HasColumnName("UserId");
        }
    }
}
