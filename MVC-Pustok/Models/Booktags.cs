namespace MVC_Pustok.Models
{
    public class Booktags:BaseEntity
    {
        public int BookId { get; set; }
        public int TagId { get; set; }

        public Tag Tag { get; set; }    
        public Book Book { get; set; }
    }
}
