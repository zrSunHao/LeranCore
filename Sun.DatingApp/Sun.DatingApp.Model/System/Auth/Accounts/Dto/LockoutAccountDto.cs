using System;
using System.ComponentModel.DataAnnotations;

namespace Sun.DatingApp.Model.System.Auth.Accounts.Dto
{
    public class LockoutAccountDto
    {
        public Guid Id { get; set; }

        public DateTime LockoutEndAt { get; set; }
    }
}
