using System;

namespace Sun.DatingApp.Model.System.Permissions.Dto
{
    public class PermissionEditDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Intro { get; set; }

        public string Icon { get; set; }

        public string TagColor { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsModule { get; set; }
    }
}
