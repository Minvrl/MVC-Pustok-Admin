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
        public Genre? Genre { get; set; }
        public Author? Author { get; set; }
        public List<BookImgs> BookImages { get; set; }

    }
}
