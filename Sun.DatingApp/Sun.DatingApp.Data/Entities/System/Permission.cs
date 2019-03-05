using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.Entities.System
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public string Icon { get; set; }

        public string TagColor { get; set; }

        public bool Active { get; set; }

        public Guid? ParentId { get; set; }

        public virtual Permission Parent { get; set; }
    }
}
