using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Menus.Model
{
    public class MenuListModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TagColor { get; set; }

        public string Icon { get; set; }

        public bool Active { get; set; }

        public string Intro { get; set; }
    }
}
