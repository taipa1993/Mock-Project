using RMT.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.ApplicationCore.Entities
{
    public class CV : BaseEntity, IAggregateRoot
    {
        public string CandidateName { get; set; }
        public DateTime? CandidateDoB { get; set; }
        public string Gender { get; set; }
        public int? LevelId { get; set; }
        public Level Level { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public string University { get; set; }
        public string Address { get; set; }
        public String Note { get; set; }
        public string ApplyPositionNote { get; set; }
        public string Status { get; set; }
        public string Path { get; set; }
        public string CVSource { get; set; }
        public float? SalaryExpect { get; set; }
        public float? SalaryOffer { get; set; }
        public DateTime InComingDate { get; set; }
        public DateTime UpdateAt { get; set; }
        public virtual List<Round> Rounds { get; set; }
    }
}
