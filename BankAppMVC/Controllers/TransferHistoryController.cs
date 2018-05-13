using BankAppMVC.App_Code;
using BankAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BankAppMVC.Controllers
{
    public class TransferHistoryController : Controller
    {
        // GET: TransferHistory
        public ActionResult TransferHistory()
        {
            List<TransferHistoryModel> xferHistoryModel = new List<TransferHistoryModel>();
            string CheckingAccountNumber = FormsAuthentication.FormsCookieName;
            HttpCookie AuthCookie = HttpContext.Request.Cookies[CheckingAccountNumber];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(AuthCookie.Value);
            ViewBag.CheckingAccountNumber = ticket.Name;
            IBusinessDataAccount _IBusinessDataAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();
            DataTable XferHistoryDataTable = _IBusinessDataAccount.GetTransferHistory(ticket.Name);             
            foreach (DataRow rows in XferHistoryDataTable.Rows)
            {
                xferHistoryModel.Add(new TransferHistoryModel { FromAccountNum = rows["FromAccountNum"].ToString(),
                                                                ToAccountNum = rows["ToAccountNum"].ToString(),
                                                                Date = rows["Date"].ToString(), Amount = rows["Amount"].ToString(),
                                                                CheckingAccountNumber = rows["CheckingAccountNumber"].ToString()});
            }            
            return View(xferHistoryModel);
        }
    }
}