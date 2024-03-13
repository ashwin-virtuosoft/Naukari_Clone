using Microsoft.AspNetCore.Mvc;

namespace Naukri_Clone.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult EmpLogin()
        {
            return View();
        }
        public IActionResult SeekerLogin()
        {
            return View();
        }
    }
}
