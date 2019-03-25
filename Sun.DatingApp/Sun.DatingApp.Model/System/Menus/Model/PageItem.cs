using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.System.Menus.Model
{
    public class PageItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string TagColor { get; set; }

        public bool Active { get; set; }

        public Guid RoleId { get; set; }

        public int Order { get; set; }
    }
}
