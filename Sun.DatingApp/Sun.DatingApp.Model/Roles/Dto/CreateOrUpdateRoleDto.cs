﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Roles.Dto
{
    public class CreateOrUpdateRoleDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }
    }
}
