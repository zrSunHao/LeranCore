using System;
using System.Collections.Generic;

namespace Sun.DatingApp.Model.System.Roles.Dto
{
    public class EditRolePermissionDto
    {
        public Guid RoleId { get; set; }

        public List<RolePermissionAndPageIdDto> PermissionAndPageIds { get; set; }

        public List<Guid> PageIds { get; set; }
    }
}
