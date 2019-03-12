using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.System.Auth.Accounts.Dto
{
    public class BatchDeleteAccountDto
    {
        public List<Guid> Ids { get; set; }
    }
}
