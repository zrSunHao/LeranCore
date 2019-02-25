using System;
using System.ComponentModel.DataAnnotations;

namespace Sun.DatingApp.Model.Auth.Accounts.Dto
{
    public class ForbiddenDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public bool Forbid { get; set; }
    }
}
