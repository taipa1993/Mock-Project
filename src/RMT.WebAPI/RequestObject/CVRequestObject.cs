using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMT.WebAPI.RequestObject
{
    public class CVRequestObject
    {
        public int LevelId { get; set; }
        public int PositionId { get; set; }
        public string Status { get; set; }
        public string Keyword { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
