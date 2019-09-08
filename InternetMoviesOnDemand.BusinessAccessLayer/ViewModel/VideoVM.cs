using System.ComponentModel.DataAnnotations;

namespace InternetMoviesOnDemand.BusinessAccessLayer.ViewModel
{
    public class VideoVM
    {
        public int CategoryId { get; set; }

        public int VideoId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string VideoName { get; set; }

        [Required]
        public string VideoDescription { get; set; }

        [Required]
        public string VideoSize { get; set; }

        [Required]
        public string VideoPath { get; set; }
    }
}
