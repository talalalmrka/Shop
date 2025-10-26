using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Shop.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public class HeaderModel
        {
            public string? Theme { get; set; } // can be null
            public string ClassName { get; set; } = "fixed top-0 inset-x-0 z-20 navbar-transparent-top navbar-transparent-primary"; // default class
            public string LogoUrl { get; set; } = "~/images/logo.svg"; // default logo
        }

        public Task<IViewComponentResult> InvokeAsync(
            string? theme = null,
            string? className = null
        )
        {
            var model = new HeaderModel
            {
                Theme = theme,
                ClassName = className ?? "fixed top-0 inset-x-0 z-20 navbar-transparent-top navbar-transparent-primary",
                LogoUrl = theme?.ToLower() == "dark" ? "~/images/logo-light.svg" : "~/images/logo.svg"
            };

            return Task.FromResult<IViewComponentResult>(View("Default", model));
        }
    }
}
