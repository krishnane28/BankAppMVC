using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BankAppMVC.App_Code
{
    //This data access class is for SQL server i.e. Microsoft SQL server
    public class DataAccessSQL : IDataAccess 
    {
        #region Connection String for SQL Server
        private string ConnectionString = ConfigurationManager.ConnectionStrings["BankMVC"].ConnectionString;
        #endregion

        #region Get Single Data
        public object GetSingleData(string sql, List<DbParameter> parameterList)
        {
            object obj = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                foreach(SqlParameter sqlParameterList in parameterList)
                {
                    command.Parameters.Add(sqlParameterList);
                }
                obj = command.ExecuteScalar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return obj;
        }
        #endregion

        #region Get Multiple Data
        public DataTable GetMultipleData(string sql, List<DbParameter> parameterList)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sql, connection);
                foreach (SqlParameter sqlParameterList in parameterList)
                {
                    command.Parameters.Add(sqlParameterList);
                }
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
        #endregion

        #region Insert or Update or Delete
        public int InsOrUpdOrDel(string sql, List<DbParameter> parameterList)
        {
            int rowsModified = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                foreach (SqlParameter sqlParameterList in parameterList)
                {
                    command.Parameters.Add(sqlParameterList);
                }
                rowsModified = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return rowsModified;
        }
        #endregion

        #region Using Stored Procedures
        public bool UsingSP(string storedProcedure, List<DbParameter> parameterList)
        {
            bool TransferResult = false;
            int rowsModified = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;                
                foreach(SqlParameter sqlParameter in parameterList)
                {
                    command.Parameters.Add(sqlParameter);
                }
                rowsModified = command.ExecuteNonQuery();
                if(rowsModified == 3)
                {
                    TransferResult = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return TransferResult;
        }
        #endregion
    }
}