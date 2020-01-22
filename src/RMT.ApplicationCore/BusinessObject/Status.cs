using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.BusinessObject
{
    public class Status
    {
        public Status()
        {
            Index = 0;
        }
        public Status(string name, int index, string statusOf)
        {
            Name = name;
            Index = index;
            StatusOf = statusOf;
        }

        public string Name { get; set; }
        public int Index { get; set; }
        public string StatusOf { get; set; }
    }
}
