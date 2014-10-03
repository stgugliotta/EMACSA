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
    public class GobbiDatabaseAuthorizationProvider : IAuthorizationProvider
    {

        #region Constructor
        public GobbiDatabaseAuthorizationProvider(string providerName)
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
        public GobbiResource[] Authorize(IPrincipal principal, string[] resourceID)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            try
            {
                db = DatabaseFactory.CreateDatabase("EMACSA_NUCLEO");
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
                List<GobbiResource> resList = new List<GobbiResource>();
                GobbiResource gobbiResource;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    gobbiResource = new GobbiResource();
                    gobbiResource.Data = dr["data"].ToString();
                    gobbiResource.FullName = dr["full_name"].ToString();
                    gobbiResource.FullPath = dr["full_path"].ToString();
                    gobbiResource.ResourceID = dr["resourceID"].ToString();
                    //evaResource.ResourceType = (GobbiResourceType)int.Parse(dr["resource_type"].ToString());
                    resList.Add(gobbiResource);
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

        

        public GobbiResource GetAuthorizedResource(IPrincipal principal, string resource)
        {
            string[] res = { resource };
            GobbiResource[] gobbirec = Authorize(principal, res);
            if (gobbirec.Length > 0)
            {
                return gobbirec[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region IAuthorizationProvider Members



        public List<GobbiResource> GetAllAuthorizedResource(IPrincipal principal)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            try
            {
                db = DatabaseFactory.CreateDatabase("Gobbi");
                dc = db.CreateConnection();
                dc.Open();

                SqlCommand command = new SqlCommand("PA_SECURITY_GetAllAuthorizedResources", (SqlConnection)dc);

                SqlParameter paramUser = new SqlParameter();
                paramUser.ParameterName = "@userName";
                paramUser.SqlDbType = SqlDbType.VarChar;
                paramUser.Size = 255;
                paramUser.Direction = ParameterDirection.Input;
                paramUser.Value = principal.Identity.Name;

                command.Parameters.Add(paramUser);
                
                command.CommandType = CommandType.StoredProcedure;
                List<GobbiResource> resList = new List<GobbiResource>();
                GobbiResource gobbiResource;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    gobbiResource = new GobbiResource();
                    gobbiResource.FullPath = dr["path"].ToString();
                    resList.Add(gobbiResource);
                }
                return resList;
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

        #endregion

        #region IAuthorizationProvider Members


        EvaResource[] IAuthorizationProvider.Authorize(IPrincipal principal, string[] resourceID)
        {
            throw new NotImplementedException();
        }

        public EvaResource[] Authorize(IPrincipal principal, string[] resourceID, int levels)
        {
            throw new NotImplementedException();
        }

        EvaResource IAuthorizationProvider.GetAuthorizedResource(IPrincipal principal, string resource)
        {
            throw new NotImplementedException();
        }

        public List<GobbiResource> GetAllAuthorizedResource(IPrincipal principal, string resource)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}