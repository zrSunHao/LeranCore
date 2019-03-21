using System;

namespace Sun.DatingApp.Data.Entities.System
{
    public class SystemPage : BaseEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string TagColor { get; set; }

        public string Icon { get; set; }

        public bool Active { get; set; }

        public string Intro { get; set; }

        public Guid MenuId { get; set; }
    }
}
