using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Roles.Model
{
    public class RoleListModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
