// Models/Category.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        // رابط صورة الفئة
        public string ImageUrl { get; set; } = "";

        // قائمة المنتجات المرتبطة
        public ICollection<Product>? Products { get; set; } = new List<Product>();
    }
}
