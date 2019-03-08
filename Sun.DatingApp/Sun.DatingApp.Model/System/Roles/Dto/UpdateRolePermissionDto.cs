using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.System.Roles.Dto
{
    public class UpdateRolePermissionDto
    {
        public Guid RoleId { get; set; }

        public List<RolePermissionDto> Permissions { get; set; }
    }
}
