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

namespace WebCourseProject_Vasilyev.Pages.SellersCRUD
{
    public class EditModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public EditModel(WebCourseProject_Vasilyev.Model.DBContext context)
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

            var seller =  await _context.Sellers.FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }
            Seller = seller;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Seller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(Seller.Id))
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

        private bool SellerExists(int id)
        {
          return (_context.Sellers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
