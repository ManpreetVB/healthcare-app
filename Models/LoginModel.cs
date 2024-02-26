using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class LoginModel
    {
        [Required]
        [MinLength(3)]
        public string Email { get; set;}
        [Required]
        public string Password { get; set; }
    }
}
