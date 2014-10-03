using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Data;
using Gobbi.CoreServices.ExceptionHandling;
using System.Data.SqlClient;
using Gobbi.CoreServices.Data;
using System.Data.Common;

namespace Gobbi.CoreServices.Security.Authorization.Provider
{
    public class EvaDatabaseAuthorizationProvider : IAuthorizationProvider
    {

        #region Constructor
        public EvaDatabaseAuthorizationProvider(string providerName)
        {
            this.name = providerName;
        }
        #endregion Constructor


        #region IAuthorizationProvider Members

        private string name = null;
        public string Name
        {
            get { return name; }
        }

        ///<summary>
        /// <para> Verifica los permisos de un <see cref="IPrincipal"/> para acceder a unos recursos <paramref name="resources"/> </para>
        ///</summary>
        ///<param name="principal">Objeto Principal que representa al usuario que intenta acceder a los recursos</param>
        ///<param name="resources">Recursos pedidos.</param>
        ///<returns>Recursos autorizados</returns>
        public EvaResource[] Authorize(IPrincipal principal, string[] resourceID)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            try
            {
                db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
                dc = db.CreateConnection();
                dc.Open();

                SqlCommand command = new SqlCommand("GetAuthorizedResources", (SqlConnection)dc);

                SqlParameter paramUser = new SqlParameter();
                paramUser.ParameterName = "@username";
                paramUser.SqlDbType = SqlDbType.VarChar;
                paramUser.Size = 255;
                paramUser.Direction = ParameterDirection.Input;
                paramUser.Value = principal.Identity.Name;

                int i = 0;
                StringBuilder sb = new StringBuilder(resourceID[i++]);
                while (i < resourceID.Length)
                {
                    sb.Append(",");
                    sb.Append(resourceID[i++]);
                }
                SqlParameter paramRes = new SqlParameter();
                paramRes.ParameterName = "@resourceList";
                paramRes.SqlDbType = SqlDbType.VarChar;
                paramRes.Size = 2048;
                paramRes.Direction = ParameterDirection.Input;
                paramRes.Value = sb.ToString();

                command.Parameters.Add(paramUser);
                command.Parameters.Add(paramRes);
                command.CommandType = CommandType.StoredProcedure;
                List<EvaResource> resList = new List<EvaResource>();
                EvaResource evaResource;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    evaResource = new EvaResource();
                    evaResource.Data = dr["data"].ToString();
                    evaResource.FullName = dr["full_name"].ToString();
                    evaResource.FullPath = dr["full_path"].ToString();
                    evaResource.ResourceID = dr["resourceID"].ToString();
                    evaResource.ResourceType = (EvaResourceType)int.Parse(dr["resource_type"].ToString());
                    resList.Add(evaResource);
                }
                return resList.ToArray();
            }
            catch (EvaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException("", ex);
            }
            finally
            {
                if (dr != null && !dr.IsClosed) dr.Close();
                if (dc != null && dc.State == ConnectionState.Open) dc.Close();
            }
        }

        /// <summary>
        /// <para> Verifica los permisos de un <see cref="IPrincipal"/> para acceder a unos recursos <paramref name="resources"/> </para>
        /// </summary>
        ///<param name="principal">Objeto Principal que representa al usuario que intenta acceder a los recursos</param>
        ///<param name="resources">Recursos pedidos.</param>
        /// <param name="levels">Niveles en el arbol de recursos</param>
        ///<returns>Recursos autorizados</returns>
        public EvaResource[] Authorize(IPrincipal principal, string[] resourceID, int levels)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            try
            {
                db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
                dc = db.CreateConnection();
                dc.Open();

                SqlCommand command = new SqlCommand("GetAuthorizedResourcesHierarchical", (SqlConnection)dc);

                SqlParameter paramUser = new SqlParameter();
                paramUser.ParameterName = "@username";
                paramUser.SqlDbType = SqlDbType.VarChar;
                paramUser.Size = 255;
                paramUser.Direction = ParameterDirection.Input;
                paramUser.Value = principal.Identity.Name;

                int i = 0;
                StringBuilder sb = new StringBuilder(resourceID[i++]);
                while (i < resourceID.Length)
                {
                    sb.Append(",");
                    sb.Append(resourceID[i++]);
                }
                SqlParameter paramRes = new SqlParameter();
                paramRes.ParameterName = "@parentResourceList";
                paramRes.SqlDbType = SqlDbType.VarChar;
                paramRes.Size = 2048;
                paramRes.Direction = ParameterDirection.Input;
                paramRes.Value = sb.ToString();

                SqlParameter paramLevels = new SqlParameter();
                paramLevels.ParameterName = "@levels";
                paramLevels.SqlDbType = SqlDbType.Int;
                paramLevels.Direction = ParameterDirection.Input;
                paramLevels.Value = levels;

                command.Parameters.Add(paramUser);
                command.Parameters.Add(paramRes);
                command.Parameters.Add(paramLevels);

                command.CommandType = CommandType.StoredProcedure;                
                List<EvaResource> resList = new List<EvaResource>();
                EvaResource evaResource;
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    evaResource = new EvaResource();
                    evaResource.Data = dr["data"].ToString();
                    evaResource.FullName = dr["full_name"].ToString();
                    evaResource.FullPath = dr["full_path"].ToString();
                    evaResource.ResourceID = dr["resourceID"].ToString();
                    evaResource.ResourceType = (EvaResourceType)int.Parse(dr["resource_type"].ToString());
                    resList.Add(evaResource);
                }
                return resList.ToArray();
            }
            catch (EvaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException("", ex);
            }
            finally
            {
                if (dr != null && !dr.IsClosed) dr.Close();
                if (dc != null && dc.State == ConnectionState.Open) dc.Close();
            }
        }

        public EvaResource GetAuthorizedResource(IPrincipal principal, string resource)
        {
            string[] res = { resource };
            EvaResource[] evarec = Authorize(principal, res);
            if (evarec.Length > 0)
            {
                return evarec[0];
            }
            else
            {
                return null;
            }
        }

        //public bool SetResource(EvaResource evaResource)
        //{
        //    Database db = null;
        //    DbConnection dc = null;
        //    int res;
        //    try
        //    {
        //        db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
        //        dc = db.CreateConnection();
        //        dc.Open();

        //        SqlCommand command = new SqlCommand();
        //        command.CommandText = "InsModResource";
        //        command.Connection = (SqlConnection)dc;

        //        SqlParameter param1 = new SqlParameter();
        //        param1.ParameterName = "@resource_id";
        //        param1.SqlDbType = SqlDbType.VarChar;
        //        param1.Size = 255;
        //        param1.Direction = ParameterDirection.Input;
        //        param1.Value = evaRes.ResourceID;

        //   //@id_resource int,
        //   //@full_name varchar(1024),
        //   //@resource_type smallint,
        //   //@data varchar(1024),
        //   //@parent_id varchar(255),
        //   //@full_path varchar(1024),
        //   //@resourceID varchar(255)
        //        command.Parameters.Add(param1);
        //        command.CommandType = CommandType.StoredProcedure;
        //        res = command.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new GobbiTechnicalException("", ex);
        //    }
        //    finally
        //    {
        //        if (dc != null && dc.State == ConnectionState.Open) dc.Close();

        //    }
        //    if (res > 0)
        //        return true;
        //    return false;
        //}

        //public bool DelResource(EvaResource evaRes)
        //{
        //    Database db = null;
        //    DbConnection dc = null;
        //    int res;
        //    try
        //    {
        //        db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
        //        dc = db.CreateConnection();
        //        dc.Open();

        //        SqlCommand command = new SqlCommand();
        //        command.CommandText = "DelResource";
        //        command.Connection = (SqlConnection)dc;

        //        SqlParameter param1 = new SqlParameter();
        //        param1.ParameterName = "@resource_id";
        //        param1.SqlDbType = SqlDbType.VarChar;
        //        param1.Size = 255;
        //        param1.Direction = ParameterDirection.Input;
        //        param1.Value = evaRes.ResourceID;

        //        command.Parameters.Add(param1);
        //        command.CommandType = CommandType.StoredProcedure;
        //        res = command.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new GobbiTechnicalException("", ex);
        //    }
        //    finally
        //    {
        //        if (dc != null && dc.State == ConnectionState.Open) dc.Close();

        //    }
        //    if (res > 0)
        //        return true;
        //    return false;
        //}

        #endregion

        #region IAuthorizationProvider Members


        public List<GobbiResource> GetAllAuthorizedResource(IPrincipal principal)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}