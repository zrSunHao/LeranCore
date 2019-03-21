using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Common.Dto
{
    public class FileDto
    {
        public string FileName { get; set; }

        public string Url { get; set; }

        public string FileType { get; set; }

        public long FileLength { get; set; }
    }
}
