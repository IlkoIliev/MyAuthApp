using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAuthApp.Models.Roles;

namespace MyAuthApp.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (ModelState.IsValid) 
            {
                var user = await _userManager.GetUserAsync(User);
                var roleExist = await _roleManager.RoleExistsAsync(model.Name);
                if (!roleExist) 
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Name));
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Ролята вече съществува");
            }

            return View(model);
        }


    }
}
