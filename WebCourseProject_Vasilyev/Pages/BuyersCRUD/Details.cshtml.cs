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
    public class DetailsModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public DetailsModel(WebCourseProject_Vasilyev.Model.DBContext context)
        {
            _context = context;
        }

      public Buyer Buyer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Buyers == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyers.FirstOrDefaultAsync(m => m.Id == id);
            if (buyer == null)
            {
                return NotFound();
            }
            else 
            {
                Buyer = buyer;
            }
            return Page();
        }
    }
}
