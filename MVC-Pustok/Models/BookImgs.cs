using System.ComponentModel.DataAnnotations;

namespace MVC_Pustok.Models
{
    public class BookImgs:BaseEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }    
        public bool? PosterStatus { get; set; }
    }
}
