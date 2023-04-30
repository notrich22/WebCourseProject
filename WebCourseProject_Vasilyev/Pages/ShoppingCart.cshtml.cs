using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Model.Entity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebCourseProject_Vasilyev.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public ShoppingCart shoppingCart { get; set; }
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ShoppingCartModel(WebCourseProject_Vasilyev.Model.DBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async void OnGet()
        {
            shoppingCart = await _context.ShoppingCarts
                .Include(n => n.CartItems)
                .Include(n => n.Buyer)
                .FirstOrDefaultAsync(n => n.Buyer.UserID == "5b0ef355-abaf-4cce-abf8-c47f061aaa7c");
        }
    }
}
