using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppNats.Models
{
    public  class GroupMember
    {
        [Key]
        [Required]
        public int GroupMemberId { get; set; }

        [Required]
        [ForeignKey("Groups")]
        public int GroupId { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;


        public DateTime AddedAt = DateTime.UtcNow;

       
        public Group Groups { get; set; } = new Group();


    }
}
