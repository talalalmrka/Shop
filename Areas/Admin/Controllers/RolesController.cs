using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : AdminBaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // عرض جميع الأدوار
        public async Task<IActionResult> Index(int page = 1, int perPage = 10)
        {
            // IQueryable for roles
            var query = _roleManager.Roles.OrderBy(r => r.Name);

            // Total roles for pagination
            int totalItems = await query.CountAsync();

            // Get only the current page
            var roles = query
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToList();

            // Pass pagination info to view
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / perPage);

            return View(roles);
        }

        // ========================
        // CREATE
        // GET
        [HttpGet]
        public IActionResult Create()
        {
            var model = new RoleViewModel();
            return View("Edit", model); // نفس View
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Edit", model);

            if (await _roleManager.RoleExistsAsync(model.Name!))
            {
                ModelState.AddModelError("", "الدور موجود بالفعل");
                return View("Edit", model);
            }

            var role = new IdentityRole(model.Name!);
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View("Edit", model);
            }

            return RedirectToAction(nameof(Index));
        }

        // ========================
        // EDIT
        // GET
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!
            };

            return View("Edit", model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Edit", model);

            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null) return NotFound();

            role.Name = model.Name!;
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return View("Edit", model);
            }

            return RedirectToAction(nameof(Index));
        }

        // ========================
        // DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                TempData["Error"] = string.Join(", ", result.Errors.Select(e => e.Description));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
