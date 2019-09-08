using System.ComponentModel.DataAnnotations;

namespace InternetMoviesOnDemand.BusinessAccessLayer.ViewModel
{
    public class UserVM
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
