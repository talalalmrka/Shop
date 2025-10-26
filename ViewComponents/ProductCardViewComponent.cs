using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.ViewComponents
{
    public class ProductCardViewComponent : ViewComponent
    {
        // Inner model specific to the component
        public class ProductCardModel
        {
            public string? ClassName { get; set; }
            public Product Product { get; set; } = default!;
        }

        // Async invoke method with proper parameter binding
        public Task<IViewComponentResult> InvokeAsync(Product product, string? className = null)
        {
            var model = new ProductCardModel
            {
                Product = product,
                ClassName = className
            };

            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
