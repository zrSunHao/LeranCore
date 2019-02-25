﻿using System;

namespace Sun.DatingApp.Model.Auth.Accounts.Model
{
    public class AccountListModel
    {
        public  Guid Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

        public bool Active { get; set; }

        public DateTime? LatestLoginAt { get; set; }

        public DateTime? LockoutEndAt { get; set; }

        public int AccessFailedCount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
