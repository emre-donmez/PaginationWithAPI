using Microsoft.AspNetCore.Mvc;

namespace PaginationUI.Controllers
{
    public class NYTaxiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
