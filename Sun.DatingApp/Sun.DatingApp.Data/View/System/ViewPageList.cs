using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.View.System
{
    public class ViewPageList
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string TagColor { get; set; }

        public string Icon { get; set; }

        public bool Active { get; set; }

        public string Intro { get; set; }

        public int Order { get; set; }

        public Guid MenuId { get; set; }

        public string MenuName { get; set; }

        public string MenuTagColor { get; set; }

        public string MenuIcon { get; set; }

        public bool MenuActive { get; set; }

        public string MenuIntro { get; set; }

        public int MenuOrder { get; set; }
    }
}
