using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAppMVC.Models
{
    public class XferChkToSavModel
    {
        public double ChkAccountBalance { get; set; }
        public double SavAccountBalance { get; set; } 
        public double Amount { get; set; }
    }
}