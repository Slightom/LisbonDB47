using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisbonDB47.Models
{
    public class UserPoi
    {
        public int UserPoiID { get; set; }
        public bool Private { get; set; }
        public int PoiID { get; set; }
        public int UserID { get; set; }
        public DateTime DateCreated { get; set; }


        public Poi Poi { get; set; }
        public User User { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
