using Microsoft.AspNetCore.Mvc;

namespace FoodDonation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
