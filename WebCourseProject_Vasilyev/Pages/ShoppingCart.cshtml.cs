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
        public string TotalCostsText;
        private bool showMessage;
        public async Task OnGet()
        {
            if (showMessage)
            {
                TempData["SuccessMessage"] = "Успешно куплено.";
            }
            else
            {
                TempData.Remove("SuccessMessage");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            shoppingCart = await _context.ShoppingCarts
                .Include(n => n.CartItems)
                    .ThenInclude(ci => ci.item)
                .Include(n => n.Buyer)
                .FirstOrDefaultAsync(n => n.Buyer.UserID == userId);
            if(shoppingCart== null)
            {
                var shoppingCart = new ShoppingCart();
                shoppingCart.CartItems = null;
                shoppingCart.ShippingAddress = "";
                shoppingCart.PaymentMethod = "";
                shoppingCart.Buyer = await _context.Buyers
                .FirstOrDefaultAsync(n => n.UserID == userId);
                //shoppingCart.Buyer = await _context.Buyers.FirstOrDefaultAsync(n => n.Id == id);
                await _context.ShoppingCarts.AddAsync(shoppingCart);
                await _context.SaveChangesAsync();

            }
            double total_cost = 0;
            foreach(var component in shoppingCart.CartItems)
            {
                total_cost += (double)component.item.Price * component.Quantity;
            }
            TotalCostsText = "Общая стоимость: " + total_cost + "₽";
        }
        public IActionResult OnPostBuyButtonClick()
        {
            _context.ShoppingCarts.Remove(_context.ShoppingCarts
                .Include(n => n.CartItems)
                    .ThenInclude(ci => ci.item)
                .Include(n => n.Buyer)
                .FirstOrDefault(n => n.Buyer.UserID == User.FindFirstValue(ClaimTypes.NameIdentifier)));
            _context.SaveChanges();
            showMessage = true;
            return Page();
        }
    }
}
