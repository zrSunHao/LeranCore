using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.Entities.System
{
    public class RolePage : BaseEntity
    {
        public Guid RoleId { get; set; }

        public Guid PageId { get; set; }

        public Role Role { get; set; }
    }
}
