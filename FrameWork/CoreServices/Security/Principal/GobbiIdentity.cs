using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;


namespace Gobbi.CoreServices.Security.Principal
{
   public class GobbiIdentity:IIdentity 
    {


        private string _userName;
        private string _password;
        private string _name;
        private string _fullName;
        private int _id;
        private string _email;
        private string _passwordEmail;

        #region IIdentity Members


       public GobbiIdentity(string name, string userName)
        {
            this._name = name;
            this._fullName = userName;
            this._userName = userName;
        }
       public GobbiIdentity(string name, string userName,int id,string email,string passwordEmail)
       {
           this._name = name;
           this._fullName = userName;
           this._userName = userName;
           this._id = id;
           this._email = email;
           this._passwordEmail = passwordEmail;
       }

       public GobbiIdentity(string name, string userName, int id)
       {
           this._name = name;
           this._fullName = userName;
           this._userName = userName;
           this._id = id;
       }


        public GobbiIdentity()
        {
        }

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
            get{ return this._userName;}
            set { this._userName = value; }
        }

        public string Name
        {
            get{return this._userName;}
            
        }

        public int Id
        {
            get { return this._id; }

        }


        public string Password
        {
            get;set;
        }

        public string Email
        {
            get {return this._email;}
            set { this._email = value; }
        }

        public string PasswordEmail
        {
            get{return this._passwordEmail;}
            set{this._passwordEmail=value;}
        }


        #endregion
    }
}
