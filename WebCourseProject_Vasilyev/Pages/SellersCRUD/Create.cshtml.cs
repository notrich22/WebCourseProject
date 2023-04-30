using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages.SellersCRUD
{
    public class CreateModel : PageModel
    {
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;

        public CreateModel(WebCourseProject_Vasilyev.Model.DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Seller Seller { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sellers == null || Seller == null)
            {
                return Page();
            }

            _context.Sellers.Add(Seller);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
