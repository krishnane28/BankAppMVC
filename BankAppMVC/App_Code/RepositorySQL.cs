using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BankAppMVC.App_Code
{
    public class RepositorySQL : IRepositoryDataAuthentication, IRepositoryDataAccount // This repository for SQL Server 
    {
        #region Data Abstraction reference
        private DataAbstraction dataAbstraction = null;
        #endregion

        #region Constructor for injection 
        public RepositorySQL() : this(new DataAbstraction())
        {

        }
        public RepositorySQL(DataAbstraction dataAbs)
        {
            dataAbstraction = dataAbs;
        }
        #endregion

        #region IRepositoryDataAuthentication Methods implementation
        public string isValidUser(string userName, string password)
        {
            string result = null;
            try
            {
                string sql = "select CheckingAccountNum from dbo.Users where Username=@uname and Password=@pwd";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter parameterUsername = new SqlParameter("@uname", SqlDbType.VarChar, 50);
                parameterUsername.Value = userName;
                parameterList.Add(parameterUsername);
                SqlParameter parameterPassword = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
                parameterPassword.Value = password;
                parameterList.Add(parameterPassword);
                object obj = dataAbstraction.GetSingleData(sql, parameterList);
                if(obj != null)
                {
                    result = obj.ToString();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region IRepositoryDataAccount Methods implementation 

        #region Get Balance from Checking Account
        public double GetCheckingBalance(string CheckingAccountNumber)
        {
            double Balance = 0.0;
            try
            {
                string sql = "select Balance from dbo.CheckingAccounts where CheckingAccountNumber=@chkaccnumber";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter ChkAccNumber = new SqlParameter("@chkaccnumber", SqlDbType.VarChar, 50);
                ChkAccNumber.Value = CheckingAccountNumber;
                parameterList.Add(ChkAccNumber);
                object obj = dataAbstraction.GetSingleData(sql, parameterList);
                if(obj != null)
                {
                    Balance = double.Parse(obj.ToString());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Balance;
        }
        #endregion

        #region Get Balance from Savings Account
        public double GetSavingsBalance(string SavingsAccountNumber)
        {
            double Balance = 0.0;
            try
            {
                string sql = "select Balance from dbo.SavingAccounts where SavingAccountNumber=@savaccnumber";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter SavAccNumber = new SqlParameter("@savaccnumber", SqlDbType.VarChar, 50);
                SavAccNumber.Value = SavingsAccountNumber;
                parameterList.Add(SavAccNumber);
                object obj = dataAbstraction.GetSingleData(sql, parameterList);
                if (obj != null)
                {
                    Balance = double.Parse(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Balance;
        }
        #endregion

        #region Transfer from Checking account to Savings account
        public bool TransferCheckingToSavings(string chkAcctNum, string savAcctNum, double amount)
        {
            try
            {
                string storedProcedure = "dbo.SPXferChkToSav";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter parameterChkAcctNum = new SqlParameter("@ChkAcctNum", SqlDbType.VarChar, 50);
                parameterChkAcctNum.Value = chkAcctNum;
                parameterList.Add(parameterChkAcctNum);
                SqlParameter parameterSavAcctNum = new SqlParameter("@SavAcctNum", SqlDbType.VarChar, 50);
                parameterSavAcctNum.Value = savAcctNum;
                parameterList.Add(parameterSavAcctNum);
                SqlParameter parameterAmount = new SqlParameter("@amt", SqlDbType.Money);
                parameterAmount.Value = amount;
                parameterList.Add(parameterAmount);
                return dataAbstraction.UsingSP(storedProcedure, parameterList);
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }
        #endregion

        #region Transfer History
        public DataTable TransferHistory(string chkAccNum)
        {
            DataTable dataTable = null;
            try
            {
                string sql = "select * from dbo.TransferHistory where CheckingAccountNumber=@chkAcctNum";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter parameterChkAccNum = new SqlParameter("@chkAcctNum", SqlDbType.VarChar, 50);
                parameterChkAccNum.Value = chkAccNum;
                parameterList.Add(parameterChkAccNum);
                dataTable = dataAbstraction.GetMultipleData(sql, parameterList);
                return dataTable;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
    }
}