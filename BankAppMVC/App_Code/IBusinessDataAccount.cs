using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppMVC.App_Code
{
    public interface IBusinessDataAccount
    {
        bool TransferFromChkgToSav(string chkAcctNum, string savAcctNum, double amt);
        double GetCheckingBalance(string chkAcctNum);
        double GetSavingBalance(string savAcctNum);
        DataTable GetTransferHistory(string chkAcctNum);
    }
}
