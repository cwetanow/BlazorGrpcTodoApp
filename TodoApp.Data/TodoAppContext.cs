using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace TodoApp.Data
{
    public class TodoAppContext : DbContext
    {
        public TodoAppContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>()
                .HasKey(t => t.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=./db.sqlite");
        }
    }
}
