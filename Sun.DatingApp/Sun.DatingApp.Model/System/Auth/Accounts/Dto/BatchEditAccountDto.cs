using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.System.Auth.Accounts.Dto
{
    public class BatchEditAccountDto
    {
        public List<Guid> Ids { get; set; }

        public DateTime? LockoutEndAt { get; set; }

        public bool? Active { get; set; }
    }
}
