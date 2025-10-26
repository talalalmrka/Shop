using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Shop.ViewComponents
{
    public class NavLinkViewComponent : ViewComponent
    {
        public class NavLinkModel
        {
            public string? Label { get; set; }
            public string? Icon { get; set; }
            public string? Controller { get; set; }
            public string? Action { get; set; }
            public string ClassName { get; set; } = "nav-link"; // default class
            public bool IsActive { get; set; } = false;
            public string ActiveClass { get; set; } = "active"; // default active class
        }

        // Only one public InvokeAsync method
        public Task<IViewComponentResult> InvokeAsync(
            string? label = null,
            string? icon = null,
            string? controller = null,
            string? action = null,
            string? className = null,
            string? activeClass = null
        )
        {
            var currentController = ViewContext.RouteData.Values["controller"]?.ToString();
            var currentAction = ViewContext.RouteData.Values["action"]?.ToString();

            var model = new NavLinkModel
            {
                Label = label,
                Icon = icon,
                Controller = controller,
                Action = action,
                ClassName = className ?? "nav-link",
                ActiveClass = activeClass ?? "active",
                IsActive = string.Equals(controller, currentController, System.StringComparison.OrdinalIgnoreCase)
                           && string.Equals(action, currentAction, System.StringComparison.OrdinalIgnoreCase)
            };

            return Task.FromResult<IViewComponentResult>(View("Default", model));
        }
    }
}
