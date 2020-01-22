using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.BusinessObject
{
    public class UserFilter
    {
        public UserFilter()
        {
            Keyword = "";
            Role = "";
        }
        public string Keyword { get; set; }
        public string Role { get; set; }
    }
}
