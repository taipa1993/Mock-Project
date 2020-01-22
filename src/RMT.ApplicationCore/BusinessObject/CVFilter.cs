using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.BusinessObject
{
    public class CVFilter
    {
        public CVFilter()
        {
            LevelId = 0;
            PositionId = 0;
            Status = "";
            Keyword = "";
        }
        public int LevelId { get; set; }
        public int PositionId { get; set; }
        public string Status { get; set; }
        public string Keyword { get; set; }
    }
}
