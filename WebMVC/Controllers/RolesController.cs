using Domain.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<Role> _roleManager;

        public RolesController(RoleManager<Role> roleManager)
        {
            this._roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var role = _roleManager.Roles;
            return View(await role.ToListAsync());
        }
    }
}
