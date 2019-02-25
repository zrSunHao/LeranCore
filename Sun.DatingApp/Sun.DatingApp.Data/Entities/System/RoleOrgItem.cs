using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.Entities.System
{
    public class RoleOrgItem : BaseEntity
    {
        public Guid OrganizationId { get; set; }

        public Guid RoleId { get; set; }


        public virtual Role Role { get; set; }
    }
}
