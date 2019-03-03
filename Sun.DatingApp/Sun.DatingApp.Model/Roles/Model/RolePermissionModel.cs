using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Roles.Model
{
    public class RolePermissionModel
    {
        public Guid Key { get; set; }

        public string Title { get; set; }

        public bool IsLeaf { get; set; }

        public bool IsExpanded { get; set; }

        public bool IsChecked { get; set; }

        public string Icon { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public Guid? ParentKey { get; set; }

        public List<RolePermissionModel> Children { get; set; }
    }
}
