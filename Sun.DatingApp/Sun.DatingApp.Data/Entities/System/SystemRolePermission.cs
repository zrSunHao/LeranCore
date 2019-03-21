using System;

namespace Sun.DatingApp.Data.Entities.System
{
    public class SystemRolePermission : BaseEntity
    {
        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }

        public Guid PageId { get; set; }

        public SystemRole Role { get; set; }
    }
}
