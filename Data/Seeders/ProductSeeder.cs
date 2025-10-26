using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;

namespace Shop.Data.Seeders
{
    public class ProductSeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                // الملابس (Clothes) - Category 1
                new Product { Id = 1, Name = "فستان صيفي مريح", Description = "فستان خفيف وأنيق للصيف", Price = 120, OfferPrice = 90, OfferDate = new DateTime(2025, 12, 1), Stock = 25, ImageUrl = "/images/products/comfortable-summer-dress.jpg", CategoryId = 1 },
                new Product { Id = 2, Name = "فستان أبيض قصير", Description = "فستان أبيض أنيق للمناسبات", Price = 150, Stock = 18, ImageUrl = "/images/products/short-white-dress.jpg", CategoryId = 1 },
                new Product { Id = 3, Name = "قميص حريري", Description = "قميص حريري أنيق للنساء", Price = 180, OfferPrice = 135, OfferDate = new DateTime(2025, 12, 5), Stock = 12, ImageUrl = "/images/products/silk-blouse.jpg", CategoryId = 1 },
                new Product { Id = 4, Name = "تنورة ميدي", Description = "تنورة ميدي أنيقة ومريحة", Price = 100, Stock = 30, ImageUrl = "/images/products/midi-skirt.jpg", CategoryId = 1 },
                new Product { Id = 5, Name = "قميص مخطط", Description = "قميص قطني مخطط بألوان جميلة", Price = 80, OfferPrice = 60, OfferDate = new DateTime(2025, 12, 10), Stock = 45, ImageUrl = "/images/products/striped-tshirt.jpg", CategoryId = 1 },

                // الإكسسوارات (Accessories) - Category 2
                new Product { Id = 6, Name = "سوار ذهبي", Description = "سوار ذهبي أنيق للنساء", Price = 250, OfferPrice = 200, OfferDate = new DateTime(2025, 12, 3), Stock = 8, ImageUrl = "/images/products/gold-bangle-bracelet.jpg", CategoryId = 2 },
                new Product { Id = 7, Name = "قلادة لؤلؤ", Description = "قلادة لؤلؤ فاخرة وأنيقة", Price = 300, Stock = 5, ImageUrl = "/images/products/pearl-necklace.jpg", CategoryId = 2 },
                new Product { Id = 8, Name = "حقيبة كتف", Description = "حقيبة كتف أنيقة وعملية", Price = 200, OfferPrice = 160, OfferDate = new DateTime(2025, 12, 7), Stock = 15, ImageUrl = "/images/products/shoulder-bag.jpg", CategoryId = 2 },
                new Product { Id = 9, Name = "نظارات شمسية دائرية", Description = "نظارات شمسية دائرية أنيقة", Price = 120, Stock = 22, ImageUrl = "/images/products/round-sunglasses.jpg", CategoryId = 2 },
                new Product { Id = 10, Name = "قبعة واسعة الحواف", Description = "قبعة واسعة الحواف أنيقة للصيف", Price = 90, OfferPrice = 70, OfferDate = new DateTime(2025, 12, 15), Stock = 35, ImageUrl = "/images/products/wide-brim-hat.jpg", CategoryId = 2 },

                // الأحذية (Shoes) - Category 3
                new Product { Id = 11, Name = "كعب عالي ملون", Description = "كعب عالي ملون أنيق ومريح", Price = 180, OfferPrice = 140, OfferDate = new DateTime(2025, 12, 4), Stock = 20, ImageUrl = "/images/products/colorful-thick-heeled-shoes.jpg", CategoryId = 3 },
                new Product { Id = 12, Name = "صندل بكعب متوسط", Description = "صندل بكعب متوسط مريح للصيف", Price = 150, Stock = 15, ImageUrl = "/images/products/medium-heeled-sandals.jpg", CategoryId = 3 },
                new Product { Id = 13, Name = "حذاء مسطح أنيق", Description = "حذاء مسطح أنيق ومريح", Price = 120, Stock = 25, ImageUrl = "/images/products/elegant-flat-shoes.jpg", CategoryId = 3 },
                new Product { Id = 14, Name = "حذاء منصة", Description = "حذاء منصة عصري ومريح", Price = 160, Stock = 18, ImageUrl = "/images/products/platform-shoes.jpg", CategoryId = 3 },
                new Product { Id = 15, Name = "كعب عالي كلاسيكي", Description = "كعب عالي كلاسيكي أنيق", Price = 200, Stock = 12, ImageUrl = "/images/products/high-heels.jpg", CategoryId = 3 },

                // كاجوال (Casual) - Category 4
                new Product { Id = 16, Name = "قميص قطني ملون", Description = "قميص قطني ملون مريح للكاجوال", Price = 70, OfferPrice = 55, OfferDate = new DateTime(2025, 12, 6), Stock = 50, ImageUrl = "/images/products/colored-cotton-t-shirts.jpg", CategoryId = 4 },
                new Product { Id = 17, Name = "شورت جينز", Description = "شورت جينز مريح للصيف", Price = 90, Stock = 30, ImageUrl = "/images/products/denim-shorts.jpg", CategoryId = 4 },
                new Product { Id = 18, Name = "جينز ضيق", Description = "جينز ضيق أنيق ومريح", Price = 110, Stock = 40, ImageUrl = "/images/products/skinny-jeans.jpg", CategoryId = 4 }
            );
        }
    }
}
