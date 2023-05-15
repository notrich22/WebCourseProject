using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCourseProject_Vasilyev.LogicServices;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private ItemsLogicService itemsLogicService;
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
            return items;
        }
    }
}