using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppMVC.App_Code
{
    public interface IRepositoryDataAccount
    {
        #region Methods for Bank Application
        double GetCheckingBalance(string CheckingAccountNumber);
        double GetSavingsBalance(string SavingsAccountNumber);
        bool TransferCheckingToSavings(string chkAcctNum, string savAcctNum, double amount);
        DataTable TransferHistory(string chkAccNum);
        #endregion
    }
}
