using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ar.com.telecom.eva.CoreServices.Data;
using System.Data.Common;
using System.Data;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Security.Module
{
    public class ModuleStatus
    {
        private int id_status;
        private string status_name;
        private string status_description;
        private string registration_date;
        private Boolean allow_access;
        
        #region Properties

        public int Idstatus
        {
            get { return id_status; }
            set { id_status = value; }
        }

        public string statusName
        {
            get { return status_name; }
            set { status_name = value; }
        }

        public string description
        {
            get { return status_description; }
            set { status_description = value; }
        }

        public string registrationDate
        {
            get { return registration_date; }
            set { registration_date = value; }
        }

        public Boolean allowAccess
        {
            get { return allow_access; }
            set { allow_access = value; }
        }

        #endregion
    }
}
