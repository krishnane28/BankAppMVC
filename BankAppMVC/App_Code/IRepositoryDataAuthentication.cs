using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppMVC.App_Code
{
    public interface IRepositoryDataAuthentication
    {
        #region Method for validating the user
        string isValidUser(string userName, string password);
        #endregion
    }
}
