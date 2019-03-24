using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Common.Model
{
    public class AuthorizationRolePermission
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool Active { get; set; }
    }
}
