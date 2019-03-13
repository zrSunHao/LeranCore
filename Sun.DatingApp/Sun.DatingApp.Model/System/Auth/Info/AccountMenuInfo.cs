using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sun.DatingApp.Model.System.Auth.Info
{
    public class AccountMenuInfo
    {
        public string Text { get; set; }

        public bool Group { get; set; }

        public bool HideInBreadcrumb { get; set; }

        public List<AccountMenu> Children { get; set; }
    }
}
