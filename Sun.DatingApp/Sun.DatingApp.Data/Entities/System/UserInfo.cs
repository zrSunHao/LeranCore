using System;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("用户信息")]
    public class UserInfo : BaseEntity
    {
        [Description("账号Id")]
        public Guid AccountId { get; set; }

        //基本信息

        [Description("姓名")]
        public string Name { get; set; }

        [Description("性别")]
        public bool Sex { get; set; }

        [Description("出生年月")]
        public DateTime Birthday { get; set; }

        [Description("职业")]
        public Guid OccupationId { get; set; }

        [Description("简介")]
        public string Intro { get; set; }

        [Description("头像Id")]
        public Guid? ProfilePictureId { get; set; }

        //联系方式

        [Description("电话号码")]
        public string PhoneNum { get; set; }

        [Description("QQ")]
        public string QQ { get; set; }

        [Description("微信")]
        public string WeChart { get; set; }

        //地理信息

        [Description("Base地址Id")]
        public Guid BaseAddressId { get; set; }

        [Description("Current地址Id")]
        public Guid CurrentAddressId { get; set; }

    }
}
