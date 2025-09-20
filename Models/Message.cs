using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppNats.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string? Text { get; set; }
        public DateTime SendAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
