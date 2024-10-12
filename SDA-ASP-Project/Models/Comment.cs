namespace SDA_ASP_Project.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string CommentContent {get; set;}
        public DateTime PostedAt { get; set; }

        // FKs for user and manga
        public int UserId {  get; set; }
        public int MangaId { get; set; }


        // parent ref to manga and users
        public Manga? Manga { get; set; }
        public User? User { get; set; }
    }
}
