using System;

namespace Sun.DatingApp.Model.System.Auth.Accounts.Model
{
    public class AccountListModel
    {
        public  Guid Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public Guid RoleId { get; set; }

        public bool Active { get; set; }

        public DateTime? LatestLoginAt { get; set; }

        public DateTime? LockoutEndAt { get; set; }

        public int AccessFailedCount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
