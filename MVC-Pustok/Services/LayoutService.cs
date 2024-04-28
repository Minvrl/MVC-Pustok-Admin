using Microsoft.EntityFrameworkCore;
using MVC_Pustok.Data;
using MVC_Pustok.Models;

namespace MVC_Pustok.Services
{
    public class LayoutService
    {
        private AppDbContext _context;
        public LayoutService(AppDbContext context)
        {
            _context = context; 
        }
        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public Dictionary<String, String> GetSettings()
        {
            return _context.Settings.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
