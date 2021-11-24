using System;
namespace Catalog.API.Entities
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
