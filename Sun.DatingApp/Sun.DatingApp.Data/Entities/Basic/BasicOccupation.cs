using System;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.Basic
{
    [Description("工作岗位")]
    public class BasicOccupation
    {
        [Description("Id")]
        public Guid Id { get; set; }

        [Description("编码")]
        public string Code { get; set; }

        [Description("ParentId")]
        public Guid? ParentId { get; set; }

        [Description("名称")]
        public string Name { get; set; }

        [Description("父编码")]
        public string ParentCode { get; set; }

    }
}
