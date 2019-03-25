using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.System.Roles.Model
{
    public class RolePageModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TagColor { get; set; }

        public string Icon { get; set; }

        public bool Checked { get; set; }

        public bool Active { get; set; }

        public string MenuName { get; set; }

        public string MenuTagColor { get; set; }

        public string MenuIcon { get; set; }

        

        public List<RolePermissionModel> Permissions { get; set; }
    }
}
