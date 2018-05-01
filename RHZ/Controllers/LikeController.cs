using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RHZ.Data;

namespace RHZ.Controllers
{
    [Authorize]
    public class LikeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LikeController(ApplicationDbContext c)
        {
            _context = c;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if(id != null)
            {
                var m = _context.Messages.FirstOrDefault(msg => msg.Id == id);
                if (m != null)
                {
                    var l = _context.Likes
                        .FirstOrDefault(li => li.AuthorId == User.Identity.Name
                            && li.MessageId == m.Id);
                    if (l == null)
                    {
                        _context.Likes.Add(new Like
                        {
                            AuthorId = User.Identity.Name,
                            MessageId = m.Id
                        });
                    }
                    else
                    {
                        _context.Likes.Remove(l);
                    }
                    _context.SaveChanges();
                }
            }           

            return Redirect("~/Message/Index");
        }
    }
}