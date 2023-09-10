using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebCourseProject_Vasilyev.LogicServices;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ItemsLogicService itemsLogicService;
        private List<Item> items;
        public IndexModel(ILogger<IndexModel> logger, ItemsLogicService itemsLogicService)
        {
            _logger = logger;
            this.itemsLogicService = itemsLogicService;
        }
        public async Task<IActionResult> OnPostAsync(string searchTerm)
        {
            // Получаем список товаров из базы данных
            this.items = await itemsLogicService.GetItemsAsync();

            // Фильтруем список товаров, чтобы показывать только те, 
            // у которых в имени содержится строка поиска
            if (!string.IsNullOrEmpty(searchTerm))
            {
                items = items.Where(i => i.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            // Возвращаем список товаров на страницу Index
            return Page();
        }

        public async Task OnGet()
        {
            this.items = await itemsLogicService.GetItemsAsync();
        }
        public async Task<List<Item>> GetItemsAsync()
        {
            this.items = await itemsLogicService.GetItemsAsync();
            return items;
        }

        public async Task OnPostAddToCart(int itemId)
        {
            // Обработка запроса
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                using (var context = new DBContext())
                { 
                    var shoppingCart = await context.ShoppingCarts
                        .Include(n=>n.Buyer)
                        .Include(n=>n.CartItems)
                        .FirstOrDefaultAsync(n=>n.Buyer.UserID == userId);
                    if (shoppingCart == null)
                    {
                        var newShoppingCart = new ShoppingCart();
                        newShoppingCart.CartItems = null;
                        newShoppingCart.ShippingAddress = "";
                        newShoppingCart.PaymentMethod = "";
                        newShoppingCart.Buyer = await context.Buyers
                            .FirstOrDefaultAsync(n => n.UserID == userId);
                        //shoppingCart.Buyer = await _context.Buyers.FirstOrDefaultAsync(n => n.Id == id);
                        await context.ShoppingCarts.AddAsync(shoppingCart);
                        await context.SaveChangesAsync();

                    }
                    foreach (var item in shoppingCart.CartItems) {
                        Console.WriteLine(item.Id + ";q:" + item.Quantity);
                    }
                    var component = await context.ShoppingCartComponents
                        .Include(n => n.item)
                        .FirstOrDefaultAsync(n => n.item.Id == itemId);

                    if (component != null)
                    {
                        component.Quantity += 1;
                        await context.SaveChangesAsync();
                        return;
                    }
                    else
                    {
                        var newComp = new ShoppingCartComponent();
                        newComp.Quantity = 1;
                        newComp.item = await context.Items.FirstOrDefaultAsync(item => item.Id == itemId);
                        shoppingCart.CartItems.Add(newComp);
                        await context.ShoppingCartComponents.AddAsync(newComp);
                        await context.SaveChangesAsync();
                        return;
                    }

                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

    }
}