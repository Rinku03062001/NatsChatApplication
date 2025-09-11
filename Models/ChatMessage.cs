using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppNats.Models
{
    public class ChatMessage
    {
        public string? Type { get; set; } // "message" or "status"
        public string? FileName { get; set; } // Optional, for file messages
        public byte[] Data { get; set; } = Array.Empty<byte>();// Optional, for file messages
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public string UserName { get; set; } = string.Empty;
    }
}
