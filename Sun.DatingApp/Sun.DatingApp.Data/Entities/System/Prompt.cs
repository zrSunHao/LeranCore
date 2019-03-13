using System;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("提示")]
    public class Prompt : BaseEntity
    {
        [Description("编码")]
        public string Code { get; set; }

        [Description("组织Id")]
        public Guid OrganizationId { get; set; }

        [Description("信息")]
        public string Info { get; set; }

        [Description("上次信息")]
        public string LastInfo { get; set; }

        [Description("更新次数")]
        public int UpdateNum { get; set; }

    }
}
