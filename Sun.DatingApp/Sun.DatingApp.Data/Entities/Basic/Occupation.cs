using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.Entities.Basic
{
    [Description("工作岗位")]
    public class Occupation
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



        #region 索引

        [Description("用户")]
        public virtual ICollection<UserInfo> UserInfos { get; set; }

        public virtual ICollection<Occupation> Children { get; set; }

        public virtual Occupation Parent { get; set; }

        #endregion

    }
}
