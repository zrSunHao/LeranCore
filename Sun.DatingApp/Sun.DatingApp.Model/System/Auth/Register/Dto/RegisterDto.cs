using System.ComponentModel.DataAnnotations;

namespace Sun.DatingApp.Model.System.Auth.Register.Dto
{
    public class RegisterDto
    {
        //姓名
        [Required]
        public string UserName { get; set; }

        //邮箱
        [Required]
        public string Email { get; set; }

        //密码
        [Required]
        public string Password { get; set; }
    }
}
