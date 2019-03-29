using System;

namespace Sun.DatingApp.Model.System.Setting.Model
{
    public class SettingListModel
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
