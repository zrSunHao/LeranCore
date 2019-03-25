using System;
using System.Collections.Generic;
using Sun.DatingApp.Model.System.Menus.Model;

namespace Sun.DatingApp.Model.System.Roles.Model
{
    public class RoleListModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public string Intro { get; set; }

        public string PageNames { get; set; }
    }
}
