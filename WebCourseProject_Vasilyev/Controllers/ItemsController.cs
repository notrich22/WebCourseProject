using static WebCourseProject_Vasilyev.Records;
using WebCourseProject_Vasilyev.LogicServices;
using WebCourseProject_Vasilyev.Model.Entity;

namespace WebCourseProject_Vasilyev.Controllers
{
    public class ItemsController
    {
        private ItemsLogicService _logicService;
        public ItemsController(ItemsLogicService logicService)
        {
            _logicService = logicService;
        }
        //Create
        public async Task AddItemAsync(HttpContext context)
        {
            ItemInfo ItemInfo = await context.Request.ReadFromJsonAsync<ItemInfo>();
            Item Item = new Item();
            Item.PhotoPath = ItemInfo.photoPath;
            Item.Name = ItemInfo.Name;
            Item.Price = ItemInfo.Price;
            Item.InStock = ItemInfo.inStock;
            await context.Response.WriteAsJsonAsync(await _logicService.AddItemAsync(Item, ItemInfo.sellerId));
        }
        //Read
        public async Task GetItemsAsync(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(await _logicService.GetItemsAsync());
        }
        public async Task GetItemAsync(HttpContext context)
        {
            IdInfo idinfo = await context.Request.ReadFromJsonAsync<IdInfo>();
            await context.Response.WriteAsJsonAsync(await _logicService.GetItemAsync(idinfo.id));
        }
        //Update


        //Delete
        public async Task DeleteItemAsync(HttpContext context)
        {
            IdInfo idinfo = await context.Request.ReadFromJsonAsync<IdInfo>();
            await context.Response.WriteAsJsonAsync(await _logicService.DeleteItem(idinfo.id));
        }
    }
}
