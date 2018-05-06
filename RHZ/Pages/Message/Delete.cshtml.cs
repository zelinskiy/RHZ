using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RHZ.Data;
using Microsoft.AspNetCore.Authorization;

namespace RHZ.Pages.Message
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly RHZ.Data.ApplicationDbContext _context;

        public DeleteModel(RHZ.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }           

            Message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id 
                    && m.Author.UserName== User.Identity.Name);

            if (Message != null)
            {
                _context.Messages.Remove(Message);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
