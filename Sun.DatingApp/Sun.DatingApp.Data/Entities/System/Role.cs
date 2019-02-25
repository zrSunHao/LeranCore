using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("角色")]
    public class Role:BaseEntity
    {
        [Description("角色名称")]
        public string Name { get; set; }

        [Description("角色编码")]
        public string Code { get; set; }

        [Description("简介")]
        public string Intro { get; set; }


        #region 索引

        [Description("账号")]
        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        #endregion

    }
}
