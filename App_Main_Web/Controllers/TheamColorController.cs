using App_Service;
using Microsoft.AspNetCore.Mvc;

namespace App_Main_Web.Controllers
{
    public class TheamColorController : Controller
    {
        private readonly SessionRepo _sessionManager;

        public TheamColorController(SessionRepo sessionManager)
        {
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TheamColorChange(string ColorClassName)
        {
            _sessionManager.RemoveSessionValue("_TheamColor");
            _sessionManager.SetSessionSingleValue<string>("_TheamColor", ColorClassName);
            return Json(new { message = "Theam Color Set" });
        }
        [HttpGet]
        public IActionResult TheamHeaderColor(string ColorClassName)
        {
            _sessionManager.RemoveSessionValue("_TheamHeaderColor");
            _sessionManager.SetSessionSingleValue<object>("_TheamHeaderColor", ColorClassName);
            return Json(new { message = "Theam Header Color Set" });
        }
    }
}
