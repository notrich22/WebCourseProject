using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebCourseProject_Vasilyev.Areas.Identity.Data;
using WebCourseProject_Vasilyev.LogicServices;
using WebCourseProject_Vasilyev.Model;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Pages
{
    public class ItemPageModel : PageModel
    {
		private readonly ILogger<IndexModel> _logger;
		private ItemsLogicService itemsLogicService;
        public Item item { get; set; }
        public ItemPageModel(ILogger<IndexModel> logger, ItemsLogicService itemsLogicService)
        {
			_logger = logger;
			this.itemsLogicService = itemsLogicService;
		}
		public async Task<IActionResult> OnGet(int id)
        {
            this.item = await itemsLogicService.GetItemAsync(id);
            return Page();
        }
    }
}
