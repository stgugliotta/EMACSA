using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Security.Principal;
using ar.com.telecom.eva.CoreServices.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using ar.com.telecom.eva.CoreServices.Security.Role;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;

namespace ar.com.telecom.eva.CoreServices.Security.Role.Provider
{

    /// <summary>
    /// Implementación de IRoleProvider para el esquema "Custom" de base de datos
    /// </summary>
    class EvaDatabaseRoleProvider: IRoleProvider
    {
        #region Constructor
        /// <summary>
        /// Constructor por defecto para permitir ser instanciado dinamicamente
        /// </summary>
        /// <param name="ProviderType"></param>
        public EvaDatabaseRoleProvider(string ProviderType) { }
        public EvaDatabaseRoleProvider() { }
        #endregion Constructor

        #region Miembros de la clase

        /// <summary>
        /// Busca los los roles que tiene el usuario.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <returns>Una lista de roles en los cuales está incluido el usuario</returns>
        public string[] GetRoles(IPrincipal principal)
        {
            return this.GetRoles(principal, null);
        }

        /// <summary>
        /// Busca los los roles que tiene el usuario.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="module">Nombre del modulo / aplicacion</param>
        /// <returns>Una lista de roles en los cuales está incluido el usuario</returns>
        public string[] GetRoles(IPrincipal principal, string module)
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
                command.CommandText = "GetRoles";
                command.Connection = (SqlConnection)dc;

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@username";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Size = 255;
                param1.Direction = ParameterDirection.Input;
                param1.Value = principal.Identity.Name;
                command.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@module";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Size = 255;
                param2.Direction = ParameterDirection.Input;
                param2.Value = module;// != null ? module : "";
                command.Parameters.Add(param2);
                command.CommandType = CommandType.StoredProcedure;
                dr = command.ExecuteReader();
                StringBuilder retVal = new StringBuilder();
                if (dr.Read())
                {
                    retVal.Append(dr.GetValue(0).ToString().Trim());
                    while (dr.Read())
                    {
                        retVal.Append(",");
                        retVal.Append(dr.GetValue(0).ToString().Trim());
                    }
                }
                return retVal.ToString().Split(',');
            }
            catch (Exception ex)
            {
                throw new EvaTechnicalException("", ex);
            }
            finally
            {
                if( dr!=null && !dr.IsClosed )  dr.Close();
                if( dc!=null && dc.State==ConnectionState.Open ) dc.Close();
            }
        }


        /// <summary>
        /// Verifica que el usuario esté tenga alguno de los roles
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="roles">Roles a verificar</param>
        /// <returns>True si se encuentra en algún rol</returns>
        public bool IsInRole(IPrincipal principal, string[] roles)
        {
            return IsInRole(principal, roles, null);
        }

        /// <summary>
        /// Verifica que el usuario esté tenga alguno de los roles
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="roles">Roles a verificar</param>
        /// <param name="module">Nombre del modulo/aplicación</param>
        /// <returns>True si se encuentra en algún rol</returns>
        public bool IsInRole(IPrincipal principal, string[] roles, string module)
        {
            try
            {
                IRoleProvider rp = new EvaDatabaseRoleProvider();
                IList a = (IList)rp.GetRoles(principal, module);
                IList b = (IList)roles;
                foreach (string s in b)
                    if (!a.Contains(s))
                        return false;
                return true;
            }
            catch (Exception ex)
            {
                throw new EvaTechnicalException("", ex);
            }
        }

        /// <summary>
        /// Busca los roles que tiene el usuario dentro un subgrupo.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="roles">Roles a verificar</param>
        /// <returns>Una lista de roles en los cuales está incluido el usuario</returns>
        public string[] CheckRoles(IPrincipal principal, string[] roles)
        {
            return CheckRoles(principal, roles);
        }

        /// <summary>
        /// Busca los roles que tiene el usuario dentro un subgrupo.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="roles">Roles a verificar</param>
        /// <param name="module">Nombre del modulo/aplicación</param>
        /// <returns>Una lista de roles en los cuales está incluido el usuario</returns>
        public string[] CheckRoles(IPrincipal principal, string[] roles, string module)
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
                command.CommandText = "CheckRoles";
                command.Connection = (SqlConnection)dc;
                SqlParameter paramUser = new SqlParameter();
                paramUser.ParameterName = "@username";
                paramUser.SqlDbType = SqlDbType.VarChar;
                paramUser.Size = 255;
                paramUser.Direction = ParameterDirection.Input;
                paramUser.Value = principal.Identity.Name;

                int i = 0;
                StringBuilder sb = new StringBuilder(roles[i++]);
                while (i < roles.Length)
                   sb.Append("," + roles[i++]);
                SqlParameter paramRole = new SqlParameter();
                paramRole.ParameterName = "@roleList";
                paramRole.SqlDbType = SqlDbType.VarChar;
                paramRole.Size = 2048;
                paramRole.Direction = ParameterDirection.Input;
                paramRole.Value = sb.ToString();

                SqlParameter paramModule = new SqlParameter();
                paramModule.ParameterName = "@module";
                paramModule.SqlDbType = SqlDbType.VarChar;
                paramModule.Size = 255;
                paramModule.Direction = ParameterDirection.Input;
                paramModule.Value = module != null ? module : "";

                command.Parameters.Add(paramUser);
                command.Parameters.Add(paramRole);
                command.Parameters.Add(paramModule);
                command.CommandType = CommandType.StoredProcedure;
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    string retVal = dr.GetValue(0).ToString().Trim();
                    while (dr.Read())
                    {
                        retVal += "," + dr.GetValue(0).ToString().Trim();
                    }
                    dr.Close();
                    dc.Close();
                    return retVal.Split(',');
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new EvaTechnicalException("", ex);
            }
            finally
            {
                if (dr != null && !dr.IsClosed) dr.Close();
                if (dc != null && dc.State == ConnectionState.Open) dc.Close();
            }
        }

        /// <summary>
        /// Verifica si el usuario en cuestion pertenece al rol de Administrador Funcional
        /// del modulo indicado.
        /// </summary>
        /// <param name="principal">Principal del usuario que está corriendo</param>
        /// <param name="module">Nombre del modulo/aplicación</param>
        /// <returns>True si verdaderamente el usuario tiene el rol.</returns>
        public bool IsInRoleFunctionalAdmin(IPrincipal principal, string module)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            string[] lista;

            try
            {
                db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
                dc = db.CreateConnection();
                dc.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "PA_EVA_GetFunctionalAdminRole";
                command.Connection = (SqlConnection)dc;

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@module";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Size = 255;
                param1.Direction = ParameterDirection.Input;
                param1.Value = module;
                command.Parameters.Add(param1);
                
                command.CommandType = CommandType.StoredProcedure;
                dr = command.ExecuteReader();
                
                if (dr.Read())
                {
                    if (dr.GetValue(0) != DBNull.Value)
                    {
                        StringBuilder retVal = new StringBuilder();
                        
                        retVal.Append(dr.GetValue(1).ToString().Trim());

                        return IsInRole(principal, retVal.ToString().Split(','),module);
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new EvaTechnicalException("", ex);
            }
            finally
            {
                if (dr != null && !dr.IsClosed) dr.Close();
                if (dc != null && dc.State == ConnectionState.Open) dc.Close();
            }
        }

        #endregion Miembros de la clase

    }
}
