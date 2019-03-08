using System.ComponentModel.DataAnnotations;

namespace Sun.DatingApp.Model.System.Auth.Login.Dto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
