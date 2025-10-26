// Models/Product.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? OfferPrice { get; set; }

        public DateTime? OfferDate { get; set; }

        public int Stock { get; set; }

        // رابط الصورة
        public string ImageUrl { get; set; } = "";

        // علاقة بفئة
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // خصائص محسوبة
        [NotMapped]
        public string PriceLabel => Price + " ر.س";

        [NotMapped]
        public bool HasCategory => CategoryId.HasValue && Category != null;

        [NotMapped]
        public string CategoryName => Category?.Name ?? "";
        public decimal ActualPrice => HasOffer ? OfferPrice!.Value : Price;

        [NotMapped]
        public string ActualPriceLabel => ActualPrice + " ر.س";

        [NotMapped]
        public bool HasOffer => OfferPrice.HasValue && OfferDate.HasValue && DateTime.Now <= OfferDate.Value;

        [NotMapped]
        public bool OutOfStock => Stock <= 0;
    }
}
