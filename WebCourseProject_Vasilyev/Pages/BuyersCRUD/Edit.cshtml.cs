using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages.BuyersCRUD
{
    public class EditModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public EditModel(WebCourseProject_Vasilyev.Model.DBContext context)
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

            var buyer =  await _context.Buyers.FirstOrDefaultAsync(m => m.Id == id);
            if (buyer == null)
            {
                return NotFound();
            }
            Buyer = buyer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Buyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(Buyer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BuyerExists(int id)
        {
          return (_context.Buyers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
