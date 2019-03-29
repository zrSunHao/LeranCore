using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.View.System
{
    public class ViewSettingList
    {
        public Guid Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string Creator { get; set; }

        public Guid? UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Modifier { get; set; }
    }
}
