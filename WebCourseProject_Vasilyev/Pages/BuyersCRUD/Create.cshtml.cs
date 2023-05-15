using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages.BuyersCRUD
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
        public Buyer Buyer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Buyers == null || Buyer == null)
            {
                return Page();
            }

            _context.Buyers.Add(Buyer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
