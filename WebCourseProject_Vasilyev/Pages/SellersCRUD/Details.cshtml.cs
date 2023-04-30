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
    public class DetailsModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public DetailsModel(WebCourseProject_Vasilyev.Model.DBContext context)
        {
            _context = context;
        }

      public Seller Seller { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.Sellers.FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }
            else 
            {
                Seller = seller;
            }
            return Page();
        }
    }
}
