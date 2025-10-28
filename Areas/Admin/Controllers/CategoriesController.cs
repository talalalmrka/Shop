using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.Helpers;

using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoriesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // ========================
        // all
        public async Task<IActionResult> Index(int page = 1, int perPage = 10)
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
        // GET: Create
        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit", new Category());
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model, IFormFile? ImageFile)
        {
            // DebugHelper.dd(ImageFile);
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                var fileName = Path.GetRandomFileName() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                model.ImageUrl = "/uploads/" + fileName;
            }

            _context.Categories.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category model, IFormFile? ImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = await _context.Categories.FindAsync(model.Id);
            if (category == null) return NotFound();

            // تحديث الحقول الأخرى
            category.Name = model.Name;
            category.Description = model.Description;

            // إذا تم رفع صورة جديدة
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                var fileName = Path.GetRandomFileName() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                category.ImageUrl = "/uploads/" + fileName;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            if (!string.IsNullOrEmpty(category.ImageUrl))
            {
                var filePath = Path.Combine(_env.WebRootPath, category.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                category.ImageUrl = "";
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id });
        }
        // Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
