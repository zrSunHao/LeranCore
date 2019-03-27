using System;

namespace Sun.DatingApp.Model.System.Auth.Accounts.Dto
{
    public class AccountListQueryDto
    {
        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Role { get; set; }

        public bool? Active { get; set; }
    }
}
