using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankAppMVC.App_Code
{
    public class GenericFactory<T, I> where T:I
    {
        public static I CreateInstance(params object[] args)
        {
            return (I)Activator.CreateInstance(typeof(T), args);
        }
    }
}