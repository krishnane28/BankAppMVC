using BankAppMVC.Models;
using BankAppMVC.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BankAppMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            ViewBag.Title = "My Bank Application";
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel Model, string ReturnUrl)
        {
            if(Model.Username == null || Model.Password == null)
            {
               // ModelState.AddModelError("Empty", "Username or Password Cannot be empty");
                ViewBag.Message = "Username or Password cannot be empty";
                return View();
            }
            else
            {
                IBusinessAuthentication _IBusinessAuthentication = GenericFactory<BusinessLayer, IBusinessAuthentication>.CreateInstance();
                string CheckingAccountNumber = _IBusinessAuthentication.IsValidUser(Model.Username, Model.Password);
                if (CheckingAccountNumber == null)
                {
                    ViewBag.Message = "Invalid User";
                    //ModelState.AddModelError("Valid", "Username or Password is not valid");                   
                    return View();
                }
                else
                {                    
                    FormsAuthentication.SetAuthCookie(CheckingAccountNumber, false);
                    if(ReturnUrl == "/" | ReturnUrl == null)
                    {
                      return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }                                                             
                }
            }                      
        }
    }
}