using RecurringServiceExample.RecurringService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecurringServiceExample.Helper
{
    public class AuthenticationHelper
    {
        private static string merchantNumber = System.Configuration.ConfigurationManager.AppSettings["merchantNumber"];
        private static string password = System.Configuration.ConfigurationManager.AppSettings["password"];

        public static authentication GetAuthentication()
        {
            authentication auth = new authentication
            {
                merchantnumber = merchantNumber,
                password = password
            };

            return auth;
        }
    }
}