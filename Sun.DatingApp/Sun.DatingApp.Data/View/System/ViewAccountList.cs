using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.View.System
{
    public class ViewAccountList
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Mobile { get; set; }

        public bool Active { get; set; }

        public DateTime? LatestLoginAt { get; set; }

        public bool Forbiden { get; set; }

        public DateTime? LockoutEndAt { get; set; }

        public int AccessFailedCount { get; set; }

        public Guid? RefreshToken { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public int RoleRank { get; set; }

        public string RoleActive { get; set; }

        public string AvatarUrl { get; set; }
    }
}
