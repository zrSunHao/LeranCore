using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.System.Auth.Info
{
    public class AccountMenu
    {
        public string Text { get; set; }

        public string Icon { get; set; }

        public bool ShortcutRoot { get; set; }

        public List<AccountPage> Children { get; set; }
    }
}
