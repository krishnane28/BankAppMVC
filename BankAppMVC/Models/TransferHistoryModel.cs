using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAppMVC.Models
{
    public class TransferHistoryModel
    {
        public string FromAccountNum { get; set; }
        public string ToAccountNum { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string CheckingAccountNumber { get; set; }
    }
}