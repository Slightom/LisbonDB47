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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<UserPoi> UserPois { get; set; }
        public ICollection<PathPoi> PathPois { get; set; }

        //public ICollection<Comment> Comments { get; set; }
        //public ICollection<Like> Likes { get; set; }
    }
}
