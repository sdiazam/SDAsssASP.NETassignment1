﻿using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace SDA_ASP_Project.Models
{
    public class Manga
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        public int Chapters {  get; set; }
        [Display(Name = "Cover Photo")]
        public string? CoverPhoto {  get; set; }

        // Time wont display only date
        // Code Credit: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-8.0&tabs=visual-studio
        // (for Display name and Data type
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public bool Favorite { get; set; }

        // Foreign keys referring to genres authors and artists 
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int ArtistId { get; set; }

        // Parent ref to genres
        public Genre? Genre { get; set; }

        // Child refs to comments (possibly chapters after)
        public List<Comment>? Comments { get; set; }
    }
}