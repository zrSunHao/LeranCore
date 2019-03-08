using System;

namespace Sun.DatingApp.Model.System.Roles.Dto
{
    public class CreateOrUpdateRoleDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }
    }
}
