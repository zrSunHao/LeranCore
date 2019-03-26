using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.View.System
{
    public class ViewRolePageList
    {
        public Guid RoleId { get; set; }

        public Guid PageId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string TagColor { get; set; }

        public string Icon { get; set; }

        public bool Active { get; set; }

        public string Intro { get; set; }

        public int Order { get; set; }

        public Guid MenuId { get; set; }
    }
}
