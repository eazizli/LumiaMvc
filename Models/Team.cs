using System.ComponentModel.DataAnnotations.Schema;

namespace LumiaMvc.Models
{
    public class Team
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Work { get; set; }
        public string Description { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile Images { get; set; }
    }
}
