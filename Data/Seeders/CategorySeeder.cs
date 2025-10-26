using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System.Linq;

namespace Shop.Data.Seeders
{
    public class CategorySeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1, // يجب تحديد الـ ID
                    Name = "الملابس",
                    Description = "قسم الملابس",
                    ImageUrl = "/images/categories/clothes.jpg"
                },
                new Category
                {
                    Id = 2, // يجب تحديد الـ ID
                    Name = "الإكسسوارات",
                    Description = "قسم الإكسسوارات",
                    ImageUrl = "/images/categories/accessories.jpg"
                },
                new Category
                {
                    Id = 3, // يجب تحديد الـ ID
                    Name = "الأحذية",
                    Description = "قسم الأحذية",
                    ImageUrl = "/images/categories/high-heels.jpg"
                },
                new Category
                {
                    Id = 4, // يجب تحديد الـ ID
                    Name = "كاجوال",
                    Description = "قسم الملابس الكاجوال",
                    ImageUrl = "/images/categories/casual.jpg"
                },
                new Category
                {
                    Id = 5, // يجب تحديد الـ ID
                    Name = "الملابس الشتوية",
                    Description = "قسم الملابس الشتوية",
                    ImageUrl = "/images/categories/winter.jpg"
                }
            );
        }
    }
}
