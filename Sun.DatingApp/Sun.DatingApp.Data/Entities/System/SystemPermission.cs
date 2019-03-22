using System;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    public class SystemPermission : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public string Icon { get; set; }

        public string TagColor { get; set; }

        public bool Active { get; set; }

        public Guid PageId { get; set; }

        [Description("等级")]//数值越小，权重越大
        public int Rank { get; set; }
    }
}
