﻿using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    public class SystemMenu : BaseEntity
    {
        public string Name { get; set; }

        public string TagColor { get; set; }

        public string Icon { get; set; }
        
        public bool Active { get; set; }

        public string Intro { get; set; }

        [Description("排序")]
        public int Order { get; set; }
    }
}
