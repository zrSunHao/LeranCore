using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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



        #region 索引

        [Description("父组织")]
        public virtual Organization Parent { get; set; }

        [Description("子组织")]
        public virtual ICollection<Organization> Children { get; set; }

        [Description("提示信息")]
        public virtual ICollection<Prompt> Prompts { get; set; }

        #endregion

    }
}
