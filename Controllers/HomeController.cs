using LumiaMvc.DataContext;
using LumiaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LumiaMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly LumiaDbContext _context;

        public HomeController(LumiaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Team> teams = await _context.Teams.ToListAsync();
            return View(teams);
        }
    }
}
