using App_Model.Authorization;
using App_Model.UserInfo;
using App_Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace App_Main_Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SessionRepo _sessionManager;

        public LoginController(IUnitOfWork unitOfWork, SessionRepo sessionManager, IServiceProvider serviceProvider)
        {
            _unitOfWork = unitOfWork;
            //_sessionManager = sessionManager;
            _sessionManager = serviceProvider.GetRequiredService<SessionRepo>();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AppLogin()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AppLogin(UserInfo obj)
        {
            var data = _unitOfWork.LoginRepo.Login(obj.UserId, obj.UserPassword);
            if(data != null)
            {

                return RedirectToAction("Index", "Home");
            }

            return View();

        }
        public IActionResult AppLogout() {
            _sessionManager.RemoveAllSessionVlaue();
            return RedirectToAction("AppLogin", "Login");
        }
    }
}
