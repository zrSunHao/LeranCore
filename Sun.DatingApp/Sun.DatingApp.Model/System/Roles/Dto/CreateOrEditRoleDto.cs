using System;

namespace Sun.DatingApp.Model.System.Roles.Dto
{
    public class CreateOrEditRoleDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Intro { get; set; }
    }
}
