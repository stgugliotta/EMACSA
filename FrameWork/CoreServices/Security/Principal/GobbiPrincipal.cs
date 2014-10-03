using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;


namespace Gobbi.CoreServices.Security.Principal
{
    public class GobbiPrincipal:IPrincipal 
    {

        #region Attributes
        private string[] _roles;
        private GobbiIdentity _identity;
        private IList<string> _permissions;
        #endregion

        public GobbiPrincipal(GobbiIdentity identity):this(identity,null)
        {

           
        }


        public GobbiPrincipal(GobbiIdentity identity, string[] roles)
        {

            this._identity = identity;
            this._roles = roles;
        }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get { return this._identity; }
          
        }

        bool IPrincipal.IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IList<string> Permissions
        {
            get{return this._permissions;}
            set{ this._permissions=value;}

        }
        #endregion
    }
}
