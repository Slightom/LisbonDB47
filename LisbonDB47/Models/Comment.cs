using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisbonDB47.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public int UserPoiID { get; set; }
        public int UserID { get; set; }

        public UserPoi UserPoi { get; set; }
        public User User { get; set; }
    }
}
