using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.View.System
{
    public class ViewAuthorizationRolePermission
    {
        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }

        public string PermissionName { get; set; }

        public string PermissionCode { get; set; }

        public bool PermissionActive { get; set; }

        public int PermissionRank { get; set; }

    }
}
