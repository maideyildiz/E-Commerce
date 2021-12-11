namespace E_Commerce.App.AdminPage.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public int Total { get; set; }
        public string Details { get; set; }
        public int CategoryId { get; set; }
    }
}
