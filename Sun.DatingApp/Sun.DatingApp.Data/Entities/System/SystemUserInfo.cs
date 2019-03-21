using System;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("用户信息")]
    public class SystemUserInfo : BaseEntity
    {
        [Description("账号Id")]
        public Guid AccountId { get; set; }

        [Description("头像Id")]
        public Guid? AvatarId { get; set; }

        [Description("姓名")]
        public string Name { get; set; }

        [Description("性别")]
        public bool Sex { get; set; }

        [Description("出生年月")]
        public DateTime Birthday { get; set; }

        [Description("电话号码")]
        public string PhoneNum { get; set; }

        [Description("QQ")]
        public string QQ { get; set; }

        [Description("微信")]
        public string WeChart { get; set; }

        [Description("职业")]
        public string Occupation { get; set; }

        [Description("公司/学校")]
        public string Company { get; set; }

        [Description("地址")]
        public string Address { get; set; }

        [Description("个人简介")]
        public string Intro { get; set; }

    }
}
