namespace MVC_Pustok.Models
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public List<Booktags>? Tags { get; set; }
    }
}
