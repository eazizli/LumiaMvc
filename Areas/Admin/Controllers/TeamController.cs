
using LumiaMvc.DataContext;
using LumiaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LumiaMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly LumiaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamController(LumiaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<Team> teams = await _context.Teams.ToListAsync();

            return View(teams);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string guid=Guid.NewGuid().ToString();
            string newfile = guid + team.Images.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath,"assets","img","team",newfile);
            using (FileStream filestream = new FileStream(path, FileMode.CreateNew))
            {
                await team.Images.CopyToAsync(filestream);
            }
            Team newteam = new Team();
            {
                newteam.ImageName = newfile;
                newteam.Name = team.Name;
                newteam.Description = team.Description;
                newteam.Work = team.Work;
            }
            _context.Teams.Add(newteam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }
        public async Task<IActionResult> Update(int id)
        {
            Team team = await _context.Teams.FindAsync(id);
            return View(team);
        }
        [HttpPost]
      
        public async Task<IActionResult>Update(int id,Team team)
        {
            Team teams = await _context.Teams.FindAsync(id);
            teams.Name=team.Name;
            teams.Description=team.Description;
            if (!ModelState.IsValid) 
            {
                return View();
            }
            string guid =Guid.NewGuid().ToString();
            string newfile = guid + team.Images.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "img", "team", newfile);
            using (FileStream filestream = new FileStream(path, FileMode.Create))
            {
                await team.Images.CopyToAsync(filestream);
            }
            teams.ImageName = newfile;
            teams.Work = team.Work;
            _context.Teams.Update(teams);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            Team teams= await _context.Teams.FindAsync(id);
            if (teams == null)
            {
                return NotFound();
            }
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "img", "team");
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Teams.Remove(teams);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Team teams=await _context.Teams.FindAsync(id);
            return View(teams);
        }
    }
}
