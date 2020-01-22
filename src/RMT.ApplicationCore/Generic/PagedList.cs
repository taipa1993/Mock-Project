using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.Generic
{
    public class PagedList<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRow { get; set; }
        public int TotalPage { get; set; }
        public IEnumerable<T> PageData { get; set; }
    }
}
