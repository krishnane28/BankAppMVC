using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BankAppMVC.App_Code
{
    public class BusinessLayer : IBusinessAuthentication, IBusinessDataAccount
    {
        #region Repository Abstraction Object reference
        RepositoryAbstraction repositoryAbstraction = new RepositoryAbstraction();
        #endregion

        #region IBusinessAuthentication method implementation
        public string IsValidUser(string uname, string pwd)
        {            
            try
            {
                return repositoryAbstraction.isValidUser(uname, pwd);
            }
            catch(Exception ex)
            {
                throw ex;
            }          
        }
        #endregion

        #region Bank Application Methods
        public bool TransferFromChkgToSav(string chkAcctNum, string savAcctNum, double amt)
        {
            try
            {
                return repositoryAbstraction.TransferCheckingToSavings(chkAcctNum, savAcctNum, amt);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public double GetCheckingBalance(string chkAcctNum)
        {
            try
            {
                return repositoryAbstraction.GetCheckingBalance(chkAcctNum);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public double GetSavingBalance(string savAcctNum)
        {
            try
            {
                return repositoryAbstraction.GetSavingsBalance(savAcctNum);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetTransferHistory(string chkAcctNum)
        {
            try
            {
                return repositoryAbstraction.TransferHistory(chkAcctNum);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}