using Microsoft.AspNetCore.Mvc;

namespace Shop.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public class PaginationModel
        {
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
            public string? Action { get; set; }
            public string? Controller { get; set; }
            public string? Area { get; set; }
        }

        public IViewComponentResult Invoke(
            int currentPage,
            int totalPages,
            string? action = "Index",
            string? controller = null,
            string? area = null)
        {
            controller ??= ViewContext.RouteData.Values["controller"]?.ToString();
            area ??= ViewContext.RouteData.Values["area"]?.ToString();

            var model = new PaginationModel
            {
                CurrentPage = currentPage,
                TotalPages = totalPages,
                Action = action,
                Controller = controller,
                Area = area
            };

            return View(model);
        }
    }
}
