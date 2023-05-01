using FlashProductAPI_7.Db.DbModels;
using Microsoft.EntityFrameworkCore;

namespace FlashProductAPI_7.Db
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<CustomFieldValueWrapper> CustomFieldValueWrapper { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" },
                new Category { Id = 3, Name = "Category 3" }
            );
        }
    }
}
