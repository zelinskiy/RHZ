using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RHZ.Data;

namespace RHZ.Pages.Message
{
    public class IndexModel : PageModel
    {
        private readonly RHZ.Data.ApplicationDbContext _context;

        public IndexModel(RHZ.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Data.Message> Message { get;set; }

        public async Task OnGetAsync()
        {
            Message = await _context.Messages
                .Include(m => m.Author)
                .ToListAsync();
            foreach(var m in Message)
            {
                m.Likes = _context.Likes
                    .Count(l => l.MessageId == m.Id);
            }
        }
    }
}
