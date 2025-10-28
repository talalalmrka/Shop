using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : AdminBaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // ========================
        // INDEX - عرض جميع المستخدمين مع الأدوار
        public async Task<IActionResult> Index(int page = 1, int perPage = 10)
        {
            // Query users as IQueryable (no ToList yet)
            var query = _userManager.Users.OrderBy(u => u.UserName);

            // Total items for pagination
            int totalItems = await query.CountAsync();

            // Paginate users
            var users = await query
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            // Map to view model
            var model = new List<UserViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                model.Add(new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    SelectedRole = roles.FirstOrDefault() ?? "—"
                });
            }

            // Pass pagination info
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / perPage);

            return View(model);
        }


        // ========================
        // CREATE
        // GET
        [HttpGet]
        public IActionResult Create()
        {
            var model = new UserViewModel
            {
                Roles = _roleManager.Roles.Select(r => r.Name!).ToList()
            };
            return View("Edit", model); // نفس View
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = _roleManager.Roles.Select(r => r.Name!).ToList();
                return View("Edit", model);
            }

            var newUser = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(newUser, model.Password!);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                model.Roles = _roleManager.Roles.Select(r => r.Name!).ToList();
                return View("Edit", model);
            }

            if (!string.IsNullOrEmpty(model.SelectedRole))
                await _userManager.AddToRoleAsync(newUser, model.SelectedRole);

            return RedirectToAction(nameof(Index));
        }

        // ========================
        // EDIT
        // GET
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                SelectedRole = userRoles.FirstOrDefault() ?? "",
                Roles = _roleManager.Roles.Select(r => r.Name!).ToList()
            };

            return View("Edit", model); // نفس View
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = _roleManager.Roles.Select(r => r.Name!).ToList();
                return View("Edit", model);
            }
            if (string.IsNullOrEmpty(model.Id))
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                    ModelState.AddModelError("", error.Description);

                model.Roles = _roleManager.Roles.Select(r => r.Name!).ToList();
                return View("Edit", model);
            }

            // إزالة كل الأدوار القديمة وإضافة الدور المحدد
            var oldRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, oldRoles);
            if (!string.IsNullOrEmpty(model.SelectedRole))
                await _userManager.AddToRoleAsync(user, model.SelectedRole);

            // تحديث كلمة المرور إذا تم إدخال قيمة جديدة
            if (!string.IsNullOrEmpty(model.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, model.Password);
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

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var deleteResult = await _userManager.DeleteAsync(user);
            if (!deleteResult.Succeeded)
            {
                TempData["Error"] = string.Join(", ", deleteResult.Errors.Select(e => e.Description));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
