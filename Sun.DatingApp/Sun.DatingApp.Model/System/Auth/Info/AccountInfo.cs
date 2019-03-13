using System;

namespace Sun.DatingApp.Model.System.Auth.Info
{
    public class AccountInfo
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public Guid? RefreshToken { get; set; }
    }
}
