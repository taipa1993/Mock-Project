using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.Entities
{
    public class Round : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public int CVId { get; set; }
        public virtual List<UserRound> UserRounds { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string LastStatus { get; set; }
        public string NoteArchived { get; set; }
        public string Result { get; set; }
        public string FeedBackLink { get; set; }
        public string NoteOfBOD { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
