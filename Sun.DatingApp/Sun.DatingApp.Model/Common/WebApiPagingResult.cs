using System;
using System.Collections.Generic;
using System.Text;

namespace Sun.DatingApp.Model.Common
{
    public class WebApiPagingResult<T> : WebApiResult<T>
    {
        public virtual int RowsCount { get; set; }

        public WebApiPagingResult()
        {
        }

        public WebApiPagingResult(WebApiResult<T> source)
            : base(source)
        {
        }
    }
}
