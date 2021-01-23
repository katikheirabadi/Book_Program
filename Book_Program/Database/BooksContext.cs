using Book_Program.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Program.Database
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }
        public DbSet<Book_Catrgiry> Book_Catrgiries { get; set; }
        public BooksContext()
        {

        }
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b => b.ToTable("Book"));
            modelBuilder.Entity<Author>(b => b.ToTable("Author"));
            modelBuilder.Entity<Publication>(b => b.ToTable("Publication"));
            modelBuilder.Entity<Category>(b => b.ToTable("Category"));
            modelBuilder.Entity<Author_Book>(b => b.ToTable("Author_Book"));
            modelBuilder.Entity<Book_Catrgiry>(b => b.ToTable("Book_Catrgiry"));
        }
    }
}
