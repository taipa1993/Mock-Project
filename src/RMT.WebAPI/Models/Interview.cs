using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMT.WebAPI.Models
{
    public class Interview
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CVId { get; set; }
        public List<int> InterviewerIds { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string LastStatus { get; set; }
        public string NoteArchived { get; set; }
        public string FeedBackLink { get; set; }
        public string NoteOfBOD { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
