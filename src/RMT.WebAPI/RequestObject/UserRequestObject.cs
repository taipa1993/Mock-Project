using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMT.WebAPI.RequestObject
{
    public class UserRequestObject
    {
        public string Keyword { get; set; }
        public string Role { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRow { get; set; }
        public int TotalPage { get; set; }
    }
}
