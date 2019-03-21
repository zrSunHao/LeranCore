using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Data.Entities.System
{
    public class AccountAvatar : BaseEntity
    {
        public Guid AccountId { get; set; }

        public string FileName { get; set; }

        public string Url { get; set; }

        public string FileType { get; set; }

        public long FileLength { get; set; }

    }
}
