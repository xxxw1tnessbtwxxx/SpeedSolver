using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverCore.DTO.Chat
{
    public class MessageHistoryDto
    {
        [Required]
        public MessageAuthor Author { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
