using System;

namespace Sun.DatingApp.Model.System.Menus.Model
{
    public class MenuListModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TagColor { get; set; }

        public string Icon { get; set; }

        public bool Active { get; set; }

        public int Order { get; set; }

        public string Intro { get; set; }
    }
}
