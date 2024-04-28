using Microsoft.EntityFrameworkCore;
using MVC_Pustok.Models;

namespace MVC_Pustok.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Feature> Features { get; set; }    
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookImgs> BookImages { get; set; }
        public DbSet<Booktags> BookTags { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Tag> Tags { get; set; }






    }
}
