using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Permissions.Model
{
    public class PermissionTreeModel
    {
        public Guid Key { get; set; }

        public string Title { get; set; }

        public bool IsLeaf { get; set; }

        public string Icon { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public Guid? ParentKey { get; set; } 

        public List<PermissionTreeModel> Children { get; set; }
    }
}
