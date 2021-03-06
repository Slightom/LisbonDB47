﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LisbonDB47.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
        public int PoiID { get; set; }

        public Poi Poi { get; set; }
    }
}
