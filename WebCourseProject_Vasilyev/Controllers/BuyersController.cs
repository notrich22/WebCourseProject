using WebCourseProject_Vasilyev.LogicServices;
using WebCourseProject_Vasilyev.Model.Entity;
using static WebCourseProject_Vasilyev.Records;

namespace WebCourseProject_Vasilyev.Controllers
{
    public class BuyersController
    {
        private BuyersLogicService _logicService;
        public BuyersController(BuyersLogicService logicService)
        {
            _logicService = logicService;
        }
        //Create
        public async Task AddBuyerAsync(HttpContext context)
        {
            BuyerInfo buyerInfo = await context.Request.ReadFromJsonAsync<BuyerInfo>();
            Buyer buyer = new Buyer();
            buyer.FirstName = buyerInfo.FirstName;
            buyer.LastName = buyerInfo.LastName;
            buyer.Purchases = null;
            buyer.OrdersCount = 0;
            await context.Response.WriteAsJsonAsync(await _logicService.AddBuyerAsync(buyer));
        }
        //Read
        public async Task GetBuyersAsync(HttpContext context)
        {
            await context.Response.WriteAsJsonAsync(await _logicService.GetBuyersAsync());
        }
        public async Task GetBuyerAsync(HttpContext context)
        {
            IdInfo idinfo = await context.Request.ReadFromJsonAsync<IdInfo>();
            await context.Response.WriteAsJsonAsync(await _logicService.GetBuyerAsync(idinfo.id));
        }
        //Update
        

        //Delete
        public async Task DeleteBuyerAsync(HttpContext context)
        {
            IdInfo idinfo = await context.Request.ReadFromJsonAsync<IdInfo>();
            await context.Response.WriteAsJsonAsync(await _logicService.DeleteBuyer(idinfo.id));
        }
    }
}
