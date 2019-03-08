using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.System.Auth.Login.Model
{
    public class AccessDataModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string Pic { get; set; }

        public string Role { get; set; }

        public IEnumerable<string> Permissions { get; set; }

    }
}
