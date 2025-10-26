using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Helpers
{
    public static class ShopHelper
    {
        private static IServiceProvider? _serviceProvider;

        // Initialize from Program.cs
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // ------------------- Category Methods -------------------

        public static List<Category> GetAllCategories()
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Categories.ToList();
        }

        public static Category? GetCategoryById(int id)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Categories.Find(id);
        }

        public static Category? GetCategoryByName(string name)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Categories.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // ------------------- Product Methods -------------------

        public static List<Product> GetAllProducts()
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Products.Include(p => p.Category).ToList();
        }

        public static Product? GetProductById(int id)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }

        public static List<Product> GetProductsByCategory(int categoryId)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToList();
        }

        public static List<Product> SearchProducts(string searchTerm)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (string.IsNullOrWhiteSpace(searchTerm))
                return db.Products.Include(p => p.Category).ToList();

            return db.Products
                .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .Include(p => p.Category)
                .ToList();
        }

        public static List<Product> GetLatestProducts(int count = 5)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Products
                .OrderByDescending(p => p.Id)
                .Include(p => p.Category)
                .Take(count)
                .ToList();
        }

        public static List<Product> GetBestsellers(int count = 8)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Products
                .OrderByDescending(p => p.Price)
                .ThenByDescending(p => p.Id)
                .Include(p => p.Category)
                .Take(count)
                .ToList();
        }

        // ------------------- Stats -------------------

        public static int GetTotalProductsCount()
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Products.Count();
        }

        public static int GetProductsCountByCategory(int categoryId)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Products.Count(p => p.CategoryId == categoryId);
        }

        public static decimal GetAveragePrice()
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return db.Products.Any() ? db.Products.Average(p => p.Price) : 0;
        }

        // ------------------- Related Products -------------------

        public static async Task<List<Product>> GetRelatedProductsAsync(Product product, int count = 4)
        {
            using var scope = _serviceProvider!.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (product == null)
                return new List<Product>();

            IQueryable<Product> query;

            // Try to get related products by category
            if (product.CategoryId.HasValue)
            {
                query = db.Products
                    .Include(p => p.Category)
                    .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id);
            }
            else
            {
                query = db.Products
                    .Include(p => p.Category)
                    .Where(p => p.Id != product.Id);
            }

            // Move to memory before randomizing
            var relatedList = await query.ToListAsync();

            // Randomize client-side (EF Core can’t translate Guid.NewGuid)
            relatedList = relatedList
                .OrderBy(_ => Guid.NewGuid())
                .Take(count)
                .ToList();

            // If not enough related products, fill with random others
            if (relatedList.Count < count)
            {
                var others = await db.Products
                    .Where(p => p.Id != product.Id)
                    .ToListAsync();

                var randomOthers = others
                    .OrderBy(_ => Guid.NewGuid())
                    .Take(count - relatedList.Count)
                    .ToList();

                relatedList.AddRange(randomOthers);
            }

            return relatedList;
        }
    }
}
