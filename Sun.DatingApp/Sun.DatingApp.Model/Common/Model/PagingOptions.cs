using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Common.Model
{
    public class PagingOptions<T>
    {
        public virtual T Filter { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public List<PagingSort> Sort { get; set; }
    }
}
