using System.ComponentModel.DataAnnotations;

namespace InternetMoviesOnDemand.BusinessAccessLayer.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
