using LumiaMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LumiaMvc.DataContext
{
    public class LumiaDbContext:IdentityDbContext<AppUser>
    {
        public LumiaDbContext(DbContextOptions<LumiaDbContext> opt):base(opt)
        {

        }
      public  DbSet<Team>  Teams { get; set; }  
    }
}
