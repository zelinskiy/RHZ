using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RHZ.Data
{
    public class Like
    {
        [ForeignKey("ApplicationUser")]
        public string AuthorId { get; set; }

        [ForeignKey("Message")]
        public int MessageId { get; set; }
    }
}
