using System.ComponentModel.DataAnnotations;

namespace InternetMoviesOnDemand.BusinessAccessLayer.ViewModel
{
    public class LoginVM
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [MaxLength(8, ErrorMessage = "Password Max length should be 8!")]
        public string Password { get; set; }
    }
}
