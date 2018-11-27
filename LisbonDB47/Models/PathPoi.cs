using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisbonDB47.Models
{
    public class PathPoi
    {
        public int PathPoiID { get; set; }
        public int PoiID { get; set; }
        public int PathID { get; set; }

        public Poi Poi { get; set; }
        public Path Path { get; set; }
    }
}
