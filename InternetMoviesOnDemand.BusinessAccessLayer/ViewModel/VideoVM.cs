using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMoviesOnDemand.BusinessAccessLayer.ViewModel
{
    public class VideoVM
    {
        public int  CategoryId { get; set; }

        public int VideoId { get; set; }

        public string CategoryName { get; set; }

        public string VideoName { get; set; }

        public string VideoDescription { get; set; }

        public string VideoSize { get; set; }

        public string VideoPath { get; set; }
    }
}
