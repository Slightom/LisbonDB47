using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisbonDB47.Models
{
    public class Poi
    {
        public int PoiID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public ICollection<UserPoi> UserPois { get; set; }
        public ICollection<PathPoi> PathPois { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
