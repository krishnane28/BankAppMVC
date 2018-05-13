using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace BankAppMVC.App_Code
{
    public class DataAbstraction //For Bridge Pattern to select the different Data Access layers belonging to different databases
    {
        #region Data Access Layer interface 
        private IDataAccess _iDataAccess = null;
        #endregion

        #region Constructors for injection 
        public DataAbstraction() : this(new DataAccessSQL())
        {

        }
        public DataAbstraction(IDataAccess iDataAccess)
        {
            _iDataAccess = iDataAccess;
        }
        #endregion

        #region Get Single Data
        public object GetSingleData(string sql, List<DbParameter> parameterList)
        {            
            try
            {
                return _iDataAccess.GetSingleData(sql, parameterList);
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
        #endregion

        #region Get Multiple Data
        public DataTable GetMultipleData(string sql, List<DbParameter> parameterList)
        {
            try
            {
                return _iDataAccess.GetMultipleData(sql, parameterList);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert or Update or Delete
        public int InsOrUpdOrDel(string sql, List<DbParameter> parameterList)
        {
            try
            {
                return _iDataAccess.InsOrUpdOrDel(sql, parameterList);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Using Stored Procedures 
        public bool UsingSP(string storedProcedure, List<DbParameter> parameterList)
        {
            try
            {
                return _iDataAccess.UsingSP(storedProcedure, parameterList);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        }
}