using System.ComponentModel.DataAnnotations;

namespace MVC_Pustok.Models
{
    public class Genre:BaseEntity
    {
        [MaxLength(20)]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }
    }
}
