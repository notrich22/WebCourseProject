using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Model.Entity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebCourseProject_Vasilyev.Areas.Identity.Data;

namespace WebCourseProject_Vasilyev.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public ShoppingCart shoppingCart { get; set; }
        private readonly WebCourseProject_Vasilyev.Model.DBContext _context;
        public ShoppingCartModel(WebCourseProject_Vasilyev.Model.DBContext context)
        {
            _context = context;
        }
        public async Task OnGet()
        {
            var id =HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            shoppingCart = await _context.ShoppingCarts
                .Include(n => n.CartItems)
                .Include(n => n.Buyer)
                .FirstOrDefaultAsync(n => n.Buyer.UserID == id);
            if(shoppingCart== null)
            {
                var shoppingCart = new ShoppingCart();
                shoppingCart.CartItems = null;
                shoppingCart.ShippingAddress = "";
                shoppingCart.PaymentMethod = "";
                shoppingCart.Buyer = await _context.Buyers
                .FirstOrDefaultAsync(n => n.UserID == id);
                //shoppingCart.Buyer = await _context.Buyers.FirstOrDefaultAsync(n => n.Id == id);
                await _context.ShoppingCarts.AddAsync(shoppingCart);
                await _context.SaveChangesAsync();

            }
        }
    }
}
