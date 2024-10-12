namespace SDA_ASP_Project.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // child ref to mangas
        public List<Manga> mangas { get; set; }
    }
}
