using System.Collections.Generic;

namespace Sun.DatingApp.Model.Common
{
    public class PagingOptions<T>
    {
        public virtual T Filter { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public List<PagingSort> Sort { get; set; }

        public PagingOptions()
        {
            this.PageIndex = 1;
            this.PageSize = 10;
        }
    }
}
