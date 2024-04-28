using MVC_Pustok.Models;

namespace MVC_Pustok.ViewModels
{
    public class HomeViewModel
    {
        public List<Feature>  Features { get; set; }
        public List<Slider> Sliders { get; set; }   
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set; }
        public List<Book> DiscountedBooks { get; set; }
    }
}
