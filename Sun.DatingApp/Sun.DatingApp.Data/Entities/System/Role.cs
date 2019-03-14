using System.Collections.Generic;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("角色")]
    public class Role:BaseEntity
    {
        [Description("角色名称")]
        public string Name { get; set; }

        [Description("简介")]
        public string Intro { get; set; }

        [Description("是否启用")]
        public bool Active { get; set; }
    }
}
