using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Shop.ViewComponents
{
    public class SectionTitleViewComponent : ViewComponent
    {
        public class SectionTitleModel
        {
            public string? Title { get; set; } = "";
            public string? ClassName { get; set; } = "header";
        }

        public Task<IViewComponentResult> InvokeAsync(
            string? title = null,
            string? className = null
        )
        {
            var model = new SectionTitleModel
            {
                Title = title,
                ClassName = className,
            };

            return Task.FromResult<IViewComponentResult>(View("Default", model));
        }
    }
}
