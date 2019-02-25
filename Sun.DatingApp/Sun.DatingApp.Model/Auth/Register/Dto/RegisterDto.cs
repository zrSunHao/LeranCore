using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sun.DatingApp.Model.Auth.Register.Dto
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
