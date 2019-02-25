using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.Auth.Login.Model
{
    public class AccessDataModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string Pic { get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}
