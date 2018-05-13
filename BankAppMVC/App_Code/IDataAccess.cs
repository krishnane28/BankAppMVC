using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppMVC.App_Code
{
    public interface IDataAccess
    {
        #region Methods for communicating with the data source
        object GetSingleData(string sql, List<DbParameter> parameterList);
        DataTable GetMultipleData(string sql, List<DbParameter> parameterList);
        int InsOrUpdOrDel(string sql, List<DbParameter> parameterList);
        bool UsingSP(string storedProcedure, List<DbParameter> parameterList);
        #endregion
    }
}
