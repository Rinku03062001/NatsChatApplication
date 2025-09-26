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

        // for 1-to-1 chats
        public int ReceiverId { get; set; }

        // for group chats
        public int? GroupId { get; set; }

        public string? Text { get; set; }
        public DateTime SendAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
