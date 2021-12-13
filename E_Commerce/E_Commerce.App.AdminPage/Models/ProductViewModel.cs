using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.App.AdminPage.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Picture")]
        public IFormFile ProductImg { get; set; }
        public string PictureLink { get; set; }
        [Display(Name = "Picture")]
        public string PictureURL { get; set; }
        public int Total { get; set; }
        public string Details { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        public SelectList CategoryList { get; set; }
    }
}
