using System;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("账号")]
    public class Account: BaseEntity
    {
        [Description("邮件")]
        public string Email { get; set; }

        [Description("昵称")]
        public string Nickname { get; set; }

        [Description("手机号码")]
        public string Mobile { get; set; }

        [Description("角色Id")]
        public Guid RoleId { get; set; }

        [Description("头像")]
        public string Avatar { get; set; }

        [Description("密码")]
        public byte[] PasswordHash { get; set; }

        [Description("密码盐")]
        public byte[] PasswordSalt { get; set; }

        [Description("刷新Token")]
        public Guid? RefreshToken { get; set; }

        [Description("是否激活")]
        public bool Active { get; set; }

        [Description("最近登录时间")]
        public DateTime? LatestLoginAt { get; set; }

        [Description("是否禁用")]
        public bool Forbiden { get; set; }

        [Description("锁定到期时间")]
        public DateTime? LockoutEndAt { get; set; }

        [Description("登陆失败次数")]
        public int AccessFailedCount { get; set; }

    }
}
