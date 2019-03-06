﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Roles.Model
{
    public class RoleListPermissionModel
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public string Icon { get; set; }

        public string TagColor { get; set; }
    }
}
