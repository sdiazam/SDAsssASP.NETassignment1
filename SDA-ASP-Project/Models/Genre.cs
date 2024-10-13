using System.ComponentModel.DataAnnotations;

namespace SDA_ASP_Project.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        // Child ref
        public List<Manga>? Mangas { get; set; }
    }
}
