using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppNats.Models
{
    public class FileMessage
    {
        [Key]
        public int FileId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; } // Can be a user or a group
        public int? GroupId { get; set; }
        public string FileName { get; set; }
        public string FileData { get; set; } // Base64 encoded string
        public string MessageType { get; set; } = "file"; // To differentiate between text and file messages
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
