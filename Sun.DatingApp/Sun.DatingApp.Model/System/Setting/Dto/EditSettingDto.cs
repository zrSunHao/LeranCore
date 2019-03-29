using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.System.Setting.Dto
{
    public class EditSettingDto
    {
        public Guid? Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
