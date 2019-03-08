using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.System.Roles.Model
{
    public class RoleListModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public List<RoleListPermissionModel> Modules { get; set; }
    }
}
