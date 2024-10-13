
using System.ComponentModel.DataAnnotations;

namespace SDA_ASP_Project.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // child ref to mangas
        public List<Manga> mangas { get; set; }
    }
}
