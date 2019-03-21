﻿using System;

namespace Sun.DatingApp.Data.Entities.System
{
    public class SystemPermission : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public string Icon { get; set; }

        public string TagColor { get; set; }

        public bool Active { get; set; }

        public Guid PageId { get; set; }

        public virtual SystemPage Page { get; set; }
    }
}