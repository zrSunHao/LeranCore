using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.Entities.System
{
    public class SystemSetting : BaseEntity
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
