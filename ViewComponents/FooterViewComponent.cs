using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Shop.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public class FooterModel
        {
            public string? Theme { get; set; } // can be null
            public string ClassName { get; set; } = "header"; // default class
            public string LogoUrl { get; set; } = "~/images/logo.svg"; // default logo
        }

        public Task<IViewComponentResult> InvokeAsync(
            string? theme = null,
            string? className = null
        )
        {
            var model = new FooterModel
            {
                Theme = theme,
                ClassName = className ?? "header",
                LogoUrl = theme?.ToLower() == "dark" ? "~/images/logo-light.svg" : "~/images/logo.svg"
            };

            return Task.FromResult<IViewComponentResult>(View("Default", model));
        }
    }
}
