using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.System.Roles.Model
{
    public class RolePermissionModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Checked { get; set; }

        public bool Active { get; set; }

        public string Icon { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public Guid PageId { get; set; }

        public List<RolePermissionModel> Children { get; set; }
    }
}
