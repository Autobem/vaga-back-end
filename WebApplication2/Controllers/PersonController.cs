using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
