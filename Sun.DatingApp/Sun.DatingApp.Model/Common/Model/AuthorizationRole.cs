using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Common.Model
{
    public class AuthorizationRole
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<AuthorizationRolePermission> Perms { get; set; }
    }
}
