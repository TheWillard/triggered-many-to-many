using System;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public ICollection<Author> Authors { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; }

    }



    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(x => x.Books)
                .WithMany(x => x.Authors);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
