using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RHZ.Data;

namespace RHZ.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(RHZ.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ApplicationUser> Users;

        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}
