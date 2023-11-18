using App_Main_Web.Models;
using App_Model.Authorization;
using App_Model.UserInfo;
using App_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace App_Main_Web.Controllers
{


    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<HomeController> _logger;

        private readonly SessionRepo _sessionManager;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, SessionRepo sessionManager)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            _sessionManager = sessionManager;
        }
        //[Authorize(Policy = "SessionNotNull")]
        //[AllowAnonymous] // Allows access without session
        public IActionResult Index()
        {
           return View();

        }
        
        public IActionResult ApplicationHome(int ModuleId)
        {
           
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UnderMaintenance()
        {
            return View();
        }
        public IActionResult Unauthorize()
        {
            return View();
        }
       
    }
}