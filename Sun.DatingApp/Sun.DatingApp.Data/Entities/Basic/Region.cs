using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Data.Entities.Basic
{
    [Description("地区")]
    public class Region
    {
        [Description("Id")]
        public Guid Id { get; set; }

        [Description("地区Code")]
        public int RegionCode { get; set; }

        [Description("名称")]
        public string Name { get; set; }

        [Description("简称")]
        public string ShortName { get; set; }

        [Description("父Id")]
        public Guid? ParentId { get; set; }

        [Description("父Code")]
        public int? ParentCode { get; set; }

        [Description("层级")]
        public int LayerLevel { get; set; }

        [Description("城市编码")]
        public string CityCode { get; set; }

        [Description("邮政编码")]
        public string ZipCode { get; set; }

        [Description("合并名称")]
        public string MergerName { get; set; }

        [Description("经度")]
        public float Lng { get; set; }

        [Description("纬度")]
        public float Lat { get; set; }

        [Description("拼音")]
        public string PinYin { get; set; }



        #region 索引

        [Description("父")]
        public virtual Region Parent { get; set; }

        [Description("子")]
        public virtual ICollection<Region> Children { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }

        #endregion

    }
}
