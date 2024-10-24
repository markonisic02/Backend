using Microsoft.EntityFrameworkCore;
using praksaBack.Models;

namespace praksaBack.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(p => p.Games).WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.SetNull);  // Set null on delete }
        }
    }
}