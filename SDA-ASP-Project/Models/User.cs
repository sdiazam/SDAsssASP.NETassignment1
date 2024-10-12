namespace SDA_ASP_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        // I will try and make it in a controller so that when Manga.Favorite = true,
        // then it will be added to User.FavoriteManga if that makes sense
        public List<Manga> FavoriteManga { get; set; }
        // child ref to comments
        public List<Comment> comments { get; set; }
    }
}
