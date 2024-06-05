using Microsoft.EntityFrameworkCore;
using projectY.Entities;
using projectY.Models;
using Type = projectY.Models.Type;

namespace projectY.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
           Database.EnsureCreated();
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Year> Year { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookingBook> BookingBook { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        //public DbSet<oop3.Models.Film> Film { get; set; }
    }
}
