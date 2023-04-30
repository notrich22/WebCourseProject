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
    public class DeleteModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public DeleteModel(WebCourseProject_Vasilyev.Model.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sellers == null)
            {
                return NotFound();
            }
            var seller = await _context.Sellers.FindAsync(id);

            if (seller != null)
            {
                Seller = seller;
                _context.Sellers.Remove(Seller);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
