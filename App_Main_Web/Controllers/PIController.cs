using App_Model;
using App_Model.Authorization;
using App_Model.PIEntity;
using App_Model.ProductInfo;
using App_Service;
using App_Service.AlertMessage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace App_Main_Web.Controllers
{
    public class PIController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SessionRepo _sessionManager;

        public PIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PICreate( string PIcode)
        {
            Dropdown();
            if (PIcode is null)
            {
                return View(new PIMaster());
            }
            else
            {
                //var id = EncryptionHelper.Decrypt(Id);
                var data = _unitOfWork.PIRepo.GetByIdPIDetails(PIcode);

                return View(data);
            }
        }
        [HttpPost]
        public IActionResult PICreate(PIMaster obj)
        {
            //if(ModelState.IsValid) {
                var maxPIID = _unitOfWork.PIRepo.SelectAll().Count() + 1;
                obj.PICode = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + "000" + maxPIID.ToString();
                List<PIDetails> data = new List<PIDetails>();
                foreach(var details in obj.PIDetails)
                {
                    details.PIMasterCode = obj.PICode;
                    data.Add(details);
                }
               
                obj.PIDetails.AddRange(data);

                _unitOfWork.PIRepo.Insert(obj);
                var result = _unitOfWork.Commit();
                if (result.SUCCESS)
                {
                    ViewBag.Message = AlertMsg.SaveSuccessOK();
                    return RedirectToAction("PICreate", "PI");
                }
                else
                {
                    ViewBag.Message = AlertMsg.SaveWarningOK(result.MESSAGES);
                    return View(obj);
                }
            return View(obj);
            //  }
            //else {
            //    ViewBag.Message = AlertMsg.SaveWarningOK("model Not work");
            //    return View(obj);
            //}
            //return View(obj);
        }
        [HttpGet]
        public IActionResult GetItemInfo(int ProductId)
        {
            var data = _unitOfWork.PIRepo.ProductDetails(ProductId);
            return Json(new { data = data });
        }
        [HttpGet]
        public IActionResult GetCustomerLocation(int CustomerId)
        {
            var data = _unitOfWork.PIRepo.SelectAllCustomerLocation().Where(c=>c.CustomerId==CustomerId).ToList();
            return Json(new SelectList(data, "Id", "CustomerShipLocation"));
        }
        private void Dropdown()
        {
            ViewBag.CustomerId = new SelectList(_unitOfWork.PIRepo.SelectAllCustomer(), "Id", "CustomerName");
            ViewBag.ShipToId = new SelectList(_unitOfWork.PIRepo.SelectAllCustomerLocation(), "Id", "CustomerShipLocation");
            ViewBag.BuyerId = new SelectList(_unitOfWork.PIRepo.SelectAllBuyer(), "Id", "BuyerName");
            ViewBag.ProductList = new SelectList(_unitOfWork.PIRepo.SelectAllProduct(), "Id", "ProductName");
            ViewBag.PIList = new SelectList(_unitOfWork.PIRepo.SelectAll(), "PICode", "PICode");
        }
    }
}
