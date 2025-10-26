using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.ViewComponents
{
    public class CategoryCardViewComponent : ViewComponent
    {
        // Inner model specific to the component
        public class CategoryCardModel
        {
            public string? ClassName { get; set; }
            public Category Category { get; set; } = default!;
        }

        // Async invoke method with proper parameter binding
        public Task<IViewComponentResult> InvokeAsync(Category category, string? className = null)
        {
            var model = new CategoryCardModel
            {
                Category = category,
                ClassName = className
            };

            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
