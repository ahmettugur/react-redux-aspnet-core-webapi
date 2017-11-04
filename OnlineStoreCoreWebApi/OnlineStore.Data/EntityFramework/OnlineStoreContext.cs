using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineStore.Data.EntityFramework.Mappings;
using OnlineStore.Entity.Concrete;
using System.IO;

namespace OnlineStore.Data.EntityFramework
{
    public class OnlineStoreContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string connectionString = Configuration.GetConnectionString("OnlineStoreContext");

            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().ToTable("Products", schema: "dbo");
            modelBuilder.Entity<Category>().ToTable("Categories", schema: "dbo");
            modelBuilder.Entity<User>().ToTable("Users", schema: "dbo");
            modelBuilder.Entity<Role>().ToTable("Roles", schema: "dbo");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles", schema: "dbo");

            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
