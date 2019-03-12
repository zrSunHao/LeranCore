using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.System.Auth.Accounts.Dto
{
    public class EditAccountDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }
    }
}
