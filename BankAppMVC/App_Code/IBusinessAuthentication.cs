using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppMVC.App_Code
{
    public interface IBusinessAuthentication
    {
        string IsValidUser(string uname, string pwd);
    }
}
