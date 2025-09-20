using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppNats.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // PK
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
