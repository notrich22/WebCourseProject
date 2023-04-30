using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCourseProject_Vasilyev.LogicServices;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages
{
    public class SellerPageModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ItemsLogicService itemsLogicService;
        private List<Item> items;
        public Seller seller;
        public SellerPageModel(ILogger<IndexModel> logger, ItemsLogicService itemsLogicService)
        {
            _logger = logger;
            this.itemsLogicService = itemsLogicService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            this.items = await itemsLogicService.GetItemsBySellerAsync(id); 
            //TODO
            seller = items[0].Seller;
            return Page();
        }
        public async Task<List<Item>> GetItemsAsync()
        {
            return items;
        }
    }
}
