using System.Collections.Generic;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("角色")]
    public class SystemRole:BaseEntity
    {
        [Description("角色名称")]
        public string Name { get; set; }

        [Description("简介")]
        public string Intro { get; set; }

        [Description("是否启用")]
        public bool Active { get; set; }

        [Description("等级")]//数值越小权重越大
        public int Rank { get; set; }
    }
}
