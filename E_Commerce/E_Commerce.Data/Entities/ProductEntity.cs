using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Data.Entities
{
    [Table("Products")]
    public class ProductEntity:IBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string PictureURL { get; set; }
        public int Total { get; set; }
        public string Details { get; set; }
        [ForeignKey("CategoryEntity")]
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
