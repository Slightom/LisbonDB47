using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisbonDB47.Models
{
    public class Like
    {
        public int LikeID { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserPoiID { get; set; }
        public int UserID { get; set; }

        public UserPoi UserPoi { get; set; }
        public User User { get; set; }
    }
}
