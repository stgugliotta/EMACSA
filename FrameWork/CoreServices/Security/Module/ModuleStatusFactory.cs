using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Gobbi.CoreServices.Data;
using System.Data.Common;
using System.Data;
using Gobbi.CoreServices.ExceptionHandling;

namespace Gobbi.CoreServices.Security.Module
{
    ///<summary>
    /// Retorna distintas instancias de ModuleStatus
    ///</summary>
    /// <example>
    /// Para instanciar un ModuleStatus específico: 
    /// <code>
    /// ModuleStatus oModuleStatus = ModuleStatusFactory.GetModuleStatus("En linea");
    /// ModuleStatus oModuleStatus = ModuleStatusFactory.GetModuleStatus(1);
    /// </code>
    /// </example>
    public static class ModuleStatusFactory
    {
        
        /*
         * Permite obtener un objeto ModuleStatus informando su Nombre.
         */
        public static ModuleStatus GetModuleStatus(string moduleStatusName)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            
            if (moduleStatusName!="" && moduleStatusName!=null)
            {
                try
                {
                    db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
                    dc = db.CreateConnection();
                    dc.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "PA_EVA_GetModuleStatusByName";
                    command.Connection = (SqlConnection)dc;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@name";
                    param.SqlDbType = SqlDbType.VarChar;
                    param.Direction = ParameterDirection.Input;
                    param.Value = moduleStatusName;

                    command.Parameters.Add(param);

                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();

                    ModuleStatus status = new ModuleStatus();

                    if (dr.Read())
                    {
                        status.Idstatus = Convert.ToInt32(dr["id_status"]);
                        status.statusName = dr["nombre"].ToString();
                        status.description = dr["descripcion"].ToString();
                        status.registrationDate = null;
                        status.allowAccess = Convert.ToBoolean(dr["permite_acceso"]);

                        return status;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch(Exception ex)
                {
                    throw new GobbiTechnicalException("No se ha podido obtener el estado solicitado.", ex);
                }
                finally
                {
                    if (dr != null && !dr.IsClosed) dr.Close();
                    if (dc != null && dc.State == ConnectionState.Open) dc.Close();
                }
            }
            else
            {
                throw new GobbiTechnicalException("No se ha especificado el nombre del estado deseado.", null);
            }
        }

        /*
         * Permite obtener un objeto ModuleStatus informando su ID.
         */
        public static ModuleStatus GetModuleStatus(int moduleStatusId)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;

            if (moduleStatusId != 0)
            {
                try
                {
                    db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
                    dc = db.CreateConnection();
                    dc.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "PA_EVA_GetModuleStatusById";
                    command.Connection = (SqlConnection)dc;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@id_status";
                    param.SqlDbType = SqlDbType.Int;
                    param.Direction = ParameterDirection.Input;
                    param.Value = moduleStatusId;

                    command.Parameters.Add(param);

                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();

                    ModuleStatus status = new ModuleStatus();

                    if (dr.Read())
                    {
                        status.Idstatus = Convert.ToInt32(dr["id_status"]);
                        status.statusName = dr["nombre"].ToString();
                        status.description = dr["descripcion"].ToString();
                        status.registrationDate = null;
                        status.allowAccess = Convert.ToBoolean(dr["permite_acceso"]);

                        return status;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new GobbiTechnicalException("No se ha podido obtener el estado solicitado.", ex);
                }
                finally
                {
                    if (dr != null && !dr.IsClosed) dr.Close();
                    if (dc != null && dc.State == ConnectionState.Open) dc.Close();
                }
            }
            else
            {
                throw new GobbiTechnicalException("No se ha especificado el nombre del estado deseado.", null);
            }
        }

        /*
         * Permite obtener todos los ModuleStatus que estan definidos en el sistema.
         */
        public static List<ModuleStatus> GetModuleStatuses()
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
                command.CommandText = "PA_EVA_GetModuleStatuses";
                command.Connection = (SqlConnection)dc;

                command.CommandType = CommandType.StoredProcedure;
                dr = command.ExecuteReader();

                List<ModuleStatus> lista = new List<ModuleStatus>();
                
                while (dr.Read())
                {
                    ModuleStatus status = new ModuleStatus();

                    status.Idstatus = Convert.ToInt32(dr["id_status"]);
                    status.statusName = dr["nombre"].ToString();
                    status.description = dr["descripcion"].ToString();
                    status.registrationDate = null;
                    status.allowAccess = Convert.ToBoolean(dr["permite_acceso"]);

                    lista.Add(status);
                }
                    return lista;
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException("No se ha podido obtener el estado solicitado.", ex);
            }
            finally
            {
                if (dr != null && !dr.IsClosed) dr.Close();
                if (dc != null && dc.State == ConnectionState.Open) dc.Close();
            }
        }
    }
}
