using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages.SellersCRUD
{
    public class IndexModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public IndexModel(WebCourseProject_Vasilyev.Model.DBContext context)
        {
            _context = context;
        }

        public IList<Seller> Seller { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sellers != null)
            {
                Seller = await _context.Sellers.ToListAsync();
            }
        }
    }
}
