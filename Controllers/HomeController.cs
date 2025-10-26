using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Helpers;
using Shop.Models;
using Shop.Data;

namespace Shop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var categories = ShopHelper.GetAllCategories();
        return View(new { categories });
    }
    public async Task<IActionResult> Categories(int page = 1, int perPage = 10)
    {

        // Start the query (IQueryable)
        var query = _context.Categories.OrderByDescending(p => p.Id);

        // Get total items asynchronously
        int totalItems = await query.CountAsync();

        // Get paginated items asynchronously
        var categories = await query
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .ToListAsync();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / perPage);

        return View(categories);
    }

    // Products
    public async Task<IActionResult> Products(
    int page = 1,
    int perPage = 10,
    int? categoryId = null,
    string? search = null
    )
    {
        // Ensure valid pagination parameters
        if (page < 1) page = 1;
        if (perPage < 1) perPage = 10;

        // Base query
        var query = _context.Products
            .Include(p => p.Category)
            .AsQueryable();

        string pageTitle = "المنتجات";

        // Filter by category
        if (categoryId.HasValue)
        {
            var category = await _context.Categories.FindAsync(categoryId.Value);
            if (category != null)
            {
                query = query.Where(p => p.CategoryId == category.Id);
                pageTitle = $"منتجات القسم {category.Name}";
                ViewBag.Category = category; // Optional: pass full category object
            }
        }

        // Filter by search term
        if (!string.IsNullOrWhiteSpace(search))
        {
            string term = search.Trim().ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(term) ||
                (p.Description != null && p.Description.ToLower().Contains(term))
            );

            pageTitle = $"نتائج البحث عن \"{search}\"";
        }

        // Total count for pagination
        int totalItems = await query.CountAsync();

        // Apply ordering + pagination
        var products = await query
            .OrderByDescending(p => p.Id)
            .Skip((page - 1) * perPage)
            .Take(perPage)
            .ToListAsync();

        // Pagination & filters
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / perPage);
        ViewBag.PerPage = perPage;
        ViewBag.Search = search;
        ViewBag.CategoryId = categoryId;
        ViewBag.PageTitle = pageTitle;

        return View(products);
    }
    public async Task<IActionResult> Product(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound();

        var related = await ShopHelper.GetRelatedProductsAsync(product, 4);

        ViewData["Title"] = product.Name;
        ViewData["RelatedProducts"] = related;

        return View(product);
    }
    public IActionResult AddToCart(int id)
    {
        var product = ShopHelper.GetProductById(id);
        if (product != null)
        {
            CartHelper.AddToCart(product);
        }
        return RedirectToAction("Cart");
    }

    public IActionResult Cart()
    {
        return View(CartHelper.GetCartItems());
    }
    public IActionResult Remove(int id)
    {
        CartHelper.RemoveFromCart(id);
        return RedirectToAction("Cart");
    }

    public IActionResult UpdateCartQuantity(int id, int quantity)
    {
        CartHelper.UpdateQuantity(id, quantity);
        return RedirectToAction("Cart");
    }

    public IActionResult ClearCart()
    {
        CartHelper.ClearCart();
        return RedirectToAction("Cart");
    }
    public IActionResult Checkout()
    {
        var cartItems = CartHelper.GetCartItems();
        if (!cartItems.Any())
        {
            TempData["Message"] = "سلة التسوق فارغة.";
            return RedirectToAction("Cart");
        }

        return View(cartItems);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout(string name, string email, string address)
    {
        var cartItems = CartHelper.GetCartItems();
        if (!cartItems.Any())
            return RedirectToAction("Cart");

        // هنا فقط للتجربة: يمكن حفظ الطلب في قاعدة البيانات لاحقًا

        // تمرير بيانات الطلب إلى صفحة النجاح
        var orderData = new OrderViewModel
        {
            CustomerName = name,
            Email = email,
            Address = address,
            Items = cartItems,
            Total = cartItems.Sum(c => c.Product.Price * c.Quantity)
        };

        // تفريغ السلة بعد إنشاء الطلب
        CartHelper.ClearCart();

        return RedirectToAction("OrderSuccess", orderData);
    }

    public IActionResult OrderSuccess(OrderViewModel order)
    {
        return View(order);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
