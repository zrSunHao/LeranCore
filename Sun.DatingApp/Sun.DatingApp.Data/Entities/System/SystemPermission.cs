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

        [Description("权重")]//数值越大，权重越大
        public int Weight { get; set; }
    }
}
