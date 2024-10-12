using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDA_ASP_Project.Models;

namespace SDA_ASP_Project.Data
{
    public class SDA_ASP_ProjectContext : DbContext
    {
        public SDA_ASP_ProjectContext (DbContextOptions<SDA_ASP_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SDA_ASP_Project.Models.Manga> Manga { get; set; } = default!;
        public DbSet<SDA_ASP_Project.Models.Genre> Genre { get; set; } = default!;
    }
}
