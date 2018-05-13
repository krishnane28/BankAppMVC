using BankAppMVC.App_Code;
using BankAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BankAppMVC.Controllers
{
    public class XferChkToSavController : Controller
    {
        // GET: XferChkToSav
        public ActionResult XferChkToSav()
        {
            string checkingAccountNumber = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[checkingAccountNumber];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            ViewBag.CheckingAccountNumber = ticket.Name;
            string savAccountNumber = ticket.Name + "1";
            IBusinessDataAccount _IBusinessAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();
            XferChkToSavModel xferModel = new XferChkToSavModel();
            xferModel.ChkAccountBalance = _IBusinessAccount.GetCheckingBalance(ticket.Name);
            xferModel.SavAccountBalance = _IBusinessAccount.GetSavingBalance(savAccountNumber);
            return View(xferModel);
        }

        [HttpPost]
        public ActionResult XferChkToSav(XferChkToSavModel xferModel)
        {
            string checkingAccountNumber = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[checkingAccountNumber];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            ViewBag.CheckingAccountNumber = ticket.Name;
            string savAccountNumber = ticket.Name + "1";
            IBusinessDataAccount _IBusinessAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();     
            if (_IBusinessAccount.TransferFromChkgToSav(ticket.Name, savAccountNumber, xferModel.Amount))
            {
                xferModel.ChkAccountBalance = _IBusinessAccount.GetCheckingBalance(ticket.Name);
                xferModel.SavAccountBalance = _IBusinessAccount.GetSavingBalance(savAccountNumber);
                xferModel.Amount = 0.0;
                ViewBag.Message = "Transfer Successful";
            }
            else
            {
                ViewBag.Message = "Transfer Unsuccessful";
            }
            return View(xferModel);
        }
    }
}