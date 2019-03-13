using System;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("组织")]
    public class Organization :BaseEntity
    {
        [Description("描述")]
        public string Name { get; set; }

        [Description("备注")]
        public string Remark { get; set; }

        [Description("父Id")]
        public Guid? ParentId { get; set; }

    }
}
