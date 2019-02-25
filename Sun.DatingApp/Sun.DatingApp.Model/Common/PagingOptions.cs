using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Common
{
    public class PagingOptions<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string SortField { get; set; }

        public string SortOrder { get; set; }

        public T Filters { get; set; }

        public PagingOptions()
        {
            this.PageIndex = 1;
            this.PageSize = 10;
            this.SortOrder = "asc";
        }
    }
}
