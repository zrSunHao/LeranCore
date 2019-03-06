using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.Entities.System
{
    public class RolePermission : BaseEntity
    {
        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }

        public string IsModule { get; set; }

        public Role Role { get; set; }
    }
}
