using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid? UpdatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool Deleted { get; set; }

        public Guid? DeletedById { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
