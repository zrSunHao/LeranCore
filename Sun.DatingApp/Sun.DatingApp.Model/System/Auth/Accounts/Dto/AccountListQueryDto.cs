using System;

namespace Sun.DatingApp.Model.System.Auth.Accounts.Dto
{
    public class AccountListQueryDto
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

        public bool? Active { get; set; }

        public DateTime? LatestLoginAtStart { get; set; }
        public DateTime? LatestLoginAtEnd { get; set; }

        public DateTime? CreatedAtStart { get; set; }
        public DateTime? CreatedAtEnd { get; set; }
    }
}
