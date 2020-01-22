using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.BusinessObject
{
    public class Page
    {
        public Page()
        {
            CurrentPage = 1;
            PageSize = 10;
            TotalPage = 0;
            TotalRow = 0;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRow { get; set; }
        public int TotalPage { get; set; }
    }
}
