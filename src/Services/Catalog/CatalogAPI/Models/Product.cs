namespace CatalogAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;

        public List<string> Category { get; set; }=new List<String>();

        public string Description { get; set; } = default!;
        public string Imagefile { get; set; }=default!;

        public decimal Price { get; set; }

    }
}
