using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Gobbi.CoreServices.Data;
using System.Data.Common;
using System.Data;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Security.Authorization
{
    //public enum EvaResourceType
    //{
    //    Application = 1,
    //    Module = 2,
    //    SelectionTab = 3,
    //    View = 4,
    //    TreeNode = 5,
    //    Other = 6
    //}

    public class GobbiResource
    {
        private string resourceID;
        private string data;
        private string fullPath;
        private GobbiResource parent;
        private string fullName;

        private bool parentLoaded;


        public GobbiResource()
        {
            parentLoaded = false;
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        //public GobbiResourceType ResourceType
        //{
        //    get { return resourceType; }
        //    set { resourceType = value; }
        //}

        public string Data
        {
            get { return data; }
            set { data = value; }
        }

        public string FullPath
        {
            get { return fullPath; }
            set { fullPath = value; }
        }


        public GobbiResource Parent
        {
            get 
            {
                if (!parentLoaded)
                {
                    parentLoaded = true;
                   // parent = GetParent();
                }
                return parent;
            }
        }

        public string ResourceID
        {
            get { return resourceID; }
            set { resourceID = value; }
        }

       
    }
}
