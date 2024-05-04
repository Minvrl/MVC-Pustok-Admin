using MVC_Pustok.Attributes.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Pustok.Models
{
    public class Book:BaseEntity
    {
        [MaxLength(50)]
        [MinLength(10)]
        public string Name {get; set;}
        [MaxLength(300)]
        public string Desc { get; set;}
        [Column(TypeName = "money")]
        public decimal CostPrice { get; set;}
        [Column(TypeName = "money")]
        public decimal SalePrice { get; set; }
        public int DiscountPerc { get; set;}
        public bool StockStatus { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public Genre? Genre { get; set; }
        public Author? Author { get; set; }
        [NotMapped]
        [MaxfileSize(2 * 1024 * 1024)]
        [AllowedFileTypes("image/png", "image/jpeg")]
        public IFormFile? PosterFile { get; set; }
        [NotMapped]
        [MaxfileSize(2 * 1024 * 1024)]
        [AllowedFileTypes("image/png", "image/jpeg")]
        public IFormFile? HoverFile { get; set; }
        [NotMapped]
        [MaxfileSize(2 * 1024 * 1024)]
        [AllowedFileTypes("image/png", "image/jpeg")]
        public List<IFormFile>? ImageFiles { get; set; } = new List<IFormFile>();
        public List<BookImgs>? BookImages { get; set; } = new List<BookImgs>();
        public List<Booktags> BookTags { get; set; } = new List<Booktags>();
        [NotMapped]
        public List<int>? TagIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int>? BookImageIds { get; set; } = new List<int>();

    }
}
