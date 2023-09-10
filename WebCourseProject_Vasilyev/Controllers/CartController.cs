using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebCourseProject_Vasilyev.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
