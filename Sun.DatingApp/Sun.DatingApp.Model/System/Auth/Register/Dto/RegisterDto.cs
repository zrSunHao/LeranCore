using System.ComponentModel.DataAnnotations;

namespace Sun.DatingApp.Model.System.Auth.Register.Dto
{
    public class RegisterDto
    {
        //电话号码
        [Required]
        public string Mobile { get; set; }

        //邮箱
        [Required]
        public string Email { get; set; }

        //密码
        [Required]
        public string Password { get; set; }

        //验证码
        public string Captcha { get; set; }
    }
}
