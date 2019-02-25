using Sun.DatingApp.Data.Entities.Basic;
using System;
using System.ComponentModel;

namespace Sun.DatingApp.Data.Entities.System
{
    [Description("头像")]
    public class ProfilePicture : BaseEntity
    {
        [Description("文件名称")]
        public string FileName { get; set; }

        [Description("文件类型")]
        public string FileType { get; set; }

        [Description("文件链接")]
        public string Url { get; set; }

        [Description("文件长度")]
        public string FileLength { get; set; }


        [Description("用户Id")]
        public Guid UserId { get; set; }


    }
}
