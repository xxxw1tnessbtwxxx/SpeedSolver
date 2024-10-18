using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedSolverDatabase.Models
{
    public class InProjectMessage
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public DateTime SendedAt { get; set; } = DateTime.Now;
        public virtual Project? Project { get; set; }
        public virtual User? User { get; set; }
    }
}
