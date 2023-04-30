using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages.BuyersCRUD
{
    public class IndexModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public IndexModel(WebCourseProject_Vasilyev.Model.DBContext context)
        {
            _context = context;
        }

        public IList<Buyer> Buyer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Buyers != null)
            {
                Buyer = await _context.Buyers.ToListAsync();
            }
        }
    }
}
