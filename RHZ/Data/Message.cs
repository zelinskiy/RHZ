using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RHZ.Data
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual ApplicationUser Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int Likes;
    }
}
