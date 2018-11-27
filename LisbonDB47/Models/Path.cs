using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisbonDB47.Models
{
    public class Path
    {
        public int PathID { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
        public ICollection<PathPoi> PathPois { get; set; }
    }
}
