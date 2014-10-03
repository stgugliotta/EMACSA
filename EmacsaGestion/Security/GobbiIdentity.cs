using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;


namespace Security
{
   public class GobbiIdentity:IIdentity 
    {


        private string _userName;
        private string _password;

        #region IIdentity Members

        public string AuthenticationType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAuthenticated
        {
            get { throw new NotImplementedException(); }
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;set;
        }


        #endregion
    }
}
