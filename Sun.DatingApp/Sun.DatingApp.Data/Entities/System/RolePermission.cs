using System;

namespace Sun.DatingApp.Data.Entities.System
{
    public class RolePermission : BaseEntity
    {
        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }

        public Guid PageId { get; set; }

        public Role Role { get; set; }
    }
}
