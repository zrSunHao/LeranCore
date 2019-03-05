using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Permissions.Model
{
    public class PermissionListModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public string Icon { get; set; }

        public string TagColor { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public Guid? ParentId { get; set; } 
    }
}
