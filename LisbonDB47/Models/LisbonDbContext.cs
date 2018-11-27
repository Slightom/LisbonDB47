using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisbonDB47.Models
{
    public class LisbonDbContext : DbContext
    {
        public LisbonDbContext(DbContextOptions<LisbonDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Poi> Pois { get; set; }
        public DbSet<UserPoi> UserPois { get; set; }
        public DbSet<Path> Paths { get; set; }
        public DbSet<PathPoi> PathPois { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
