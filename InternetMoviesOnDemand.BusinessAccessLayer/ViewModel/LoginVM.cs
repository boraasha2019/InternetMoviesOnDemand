using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
