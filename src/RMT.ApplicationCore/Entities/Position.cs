using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.Entities
{
    public class Position : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
