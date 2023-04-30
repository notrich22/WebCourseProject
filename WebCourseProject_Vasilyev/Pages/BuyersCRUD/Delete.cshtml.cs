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
    public class DeleteModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public DeleteModel(WebCourseProject_Vasilyev.Model.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Buyers == null)
            {
                return NotFound();
            }
            var buyer = await _context.Buyers.FindAsync(id);

            if (buyer != null)
            {
                Buyer = buyer;
                _context.Buyers.Remove(Buyer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
