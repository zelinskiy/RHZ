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
    public class DetailsModel : PageModel
    {
        private readonly RHZ.Data.ApplicationDbContext _context;

        public DetailsModel(RHZ.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Data.Message Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Message = await _context.Messages.SingleOrDefaultAsync(m => m.Id == id);

            if (Message == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
