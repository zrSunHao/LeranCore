using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Roles.Dto
{
    public class UpdateRolePermissionDto
    {
        public Guid RoleId { get; set; }

        public List<RolePermissionDto> Permissions { get; set; }
    }
}
