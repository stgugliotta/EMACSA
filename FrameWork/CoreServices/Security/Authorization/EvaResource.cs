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
    public enum EvaResourceType
    {
        Application = 1,
        Module = 2,
        SelectionTab = 3,
        View = 4,
        TreeNode = 5,
        Other = 6
    }

    public class EvaResource
    {
        private string resourceID;
        private EvaResourceType resourceType;
        private string data;
        private string fullPath;
        private EvaResource parent;
        private string fullName;

        private bool parentLoaded;


        public EvaResource()
        {
            parentLoaded = false;
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public EvaResourceType ResourceType
        {
            get { return resourceType; }
            set { resourceType = value; }
        }

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


        public EvaResource Parent
        {
            get 
            {
                if (!parentLoaded)
                {
                    parentLoaded = true;
                    parent = GetParent();
                }
                return parent;
            }
        }

        public string ResourceID
        {
            get { return resourceID; }
            set { resourceID = value; }
        }

        private EvaResource GetParent()
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            try
            {
                db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
                dc = db.CreateConnection();
                dc.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "GetParentById";
                command.Connection = (SqlConnection)dc;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@resource_id";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 255;
                param.Direction = ParameterDirection.Input;
                param.Value = resourceID;

                command.Parameters.Add(param);
                command.CommandType = CommandType.StoredProcedure;
                dr = command.ExecuteReader();
                EvaResource evaRes= new EvaResource();
                if (dr.Read())
                { 
                    evaRes.Data = dr["data"].ToString();
                    evaRes.FullName = dr["full_name"].ToString();
                    evaRes.FullPath = dr["full_path"].ToString();
                    evaRes.ResourceID = dr["resourceID"].ToString();
                    evaRes.ResourceType = (EvaResourceType)int.Parse(dr["resource_type"].ToString());
                    return evaRes;
                }
                else
                {
                    return null;
                }                
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException("Error al obtener recurso", ex);
            }
            finally
            {
                if (dr != null && !dr.IsClosed) dr.Close();
                if (dc != null && dc.State == ConnectionState.Open) dc.Close();
            }
        }
    }
}
