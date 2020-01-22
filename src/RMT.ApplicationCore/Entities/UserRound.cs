using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.Entities
{
    public class UserRound : BaseEntity , IAggregateRoot
    {
        public int RoundId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
