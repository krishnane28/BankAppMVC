using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BankAppMVC.App_Code
{
    public class RepositoryAbstraction
    {
        #region Repository Layer Interfaces
        IRepositoryDataAccount _iRepositoryDataAccount = null;
        IRepositoryDataAuthentication _iRepositoryDataAuthentication = null;
        #endregion

        #region Constructor for Injection
        public RepositoryAbstraction()
        {
            _iRepositoryDataAccount = GenericFactory<RepositorySQL, IRepositoryDataAccount>.CreateInstance();
            _iRepositoryDataAuthentication = GenericFactory<RepositorySQL, IRepositoryDataAuthentication>.CreateInstance();
        }
        #endregion

        #region Bank Application Methods
        public string isValidUser(string userName, string password)
        {
            return _iRepositoryDataAuthentication.isValidUser(userName, password);
        }

        public double GetCheckingBalance(string CheckingAccountNumber)
        {
            return _iRepositoryDataAccount.GetCheckingBalance(CheckingAccountNumber);
        }

        public double GetSavingsBalance(string SavingsAccountNumber)
        {
            return _iRepositoryDataAccount.GetSavingsBalance(SavingsAccountNumber);
        }

        public bool TransferCheckingToSavings(string chkAcctNum, string savAcctNum, double amount)
        {
            return _iRepositoryDataAccount.TransferCheckingToSavings(chkAcctNum, savAcctNum, amount);
        }

        public DataTable TransferHistory(string chkAccNum)
        {
            return _iRepositoryDataAccount.TransferHistory(chkAccNum);
        }
        #endregion

    }
}