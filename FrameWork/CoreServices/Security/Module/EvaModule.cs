using System;
using System.Data.SqlClient;
using Gobbi.CoreServices.Data;
using System.Data.Common;
using System.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Gobbi.CoreServices.Security.Module;

namespace Gobbi.CoreServices.Security.Module
{
    public class EvaModule
    {
        private int id_module = 0;
        private string module_name = "";
        private string module_description = "";

        #region Constructor

        public EvaModule(string moduleName)
        {
            if (moduleName!="" && moduleName!=null)
            {
                /*
                 * Almaceno el valor en la propiedad correspondiente
                 */
                module_name = moduleName;

                /*
                 * Cargo el objeto.
                 */
                load();
            }
        }

        public EvaModule()
        {
            
        }

        #endregion

        #region Properties

        public int moduleId
        {
            get { return id_module; }
            set { id_module = value; }
        }

        public string moduleName
        {
            get { return module_name; }
            set { module_name = value; }
        }

        public string moduleDescription
        {
            get { return module_description; }
        }

        #endregion

        #region Private Methods

        /*
         * Método que obtiene la información del modulo desde la
         * DB y la carga en el objeto.
         */
        private void load()
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
                command.CommandText = "PA_EVA_GetModuleData";
                command.Connection = (SqlConnection)dc;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@module";
                param.SqlDbType = SqlDbType.VarChar;
                param.Direction = ParameterDirection.Input;
                param.Value = module_name;

                command.Parameters.Add(param);
                command.CommandType = CommandType.StoredProcedure;
                dr = command.ExecuteReader();
                
                if (dr.Read())
                {
                    id_module = Convert.ToInt32(dr.GetValue(0));
                    module_description = dr.GetValue(1).ToString();
                }
            }
            catch (Exception ex)
            {
                throw new GobbiTechnicalException("Falla al obtener los datos del modulo.", ex);
            }
        }

        #endregion

        #region Public Methods

        /*
         * Permite saber cual es el estado actual de un modulo.
         */
        public ModuleStatus GetModuleCurrentStatus(string sModuleName)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;

            if (module_name!="" || (sModuleName!=null && sModuleName!=""))
            {
                try
                {
                    db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
                    dc = db.CreateConnection();
                    dc.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "PA_EVA_GetModuleCurrentStatus";
                    command.Connection = (SqlConnection)dc;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@module";
                    param.SqlDbType = SqlDbType.VarChar;
                    param.Direction = ParameterDirection.Input;
                    param.Value = (sModuleName != null && sModuleName != "") ? sModuleName:module_name;

                    command.Parameters.Add(param);
                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();
                    
                    ModuleStatus status = new ModuleStatus();

                    if (dr.Read())
                    {
                        status.Idstatus = Convert.ToInt32(dr["id_status"]);
                        status.statusName = dr["nombre"].ToString();
                        status.description = dr["descripcion"].ToString();
                        status.registrationDate = dr["fecha_registro"].ToString();
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
                    throw new GobbiTechnicalException("Error al obtener recurso", ex);
                }
                finally
                {
                    if (dr != null && !dr.IsClosed) dr.Close();
                    if (dc != null && dc.State == ConnectionState.Open) dc.Close();
                }   
            }
            else
            {
                return null;
            }
        }

        /*
         * Sobrecarga del método GetModuleCurrentStatus para poder
         * funcionar sin parametros.
         */
        public ModuleStatus GetModuleCurrentStatus()
        {
            return this.GetModuleCurrentStatus(null);
        }

        /*
         * Metodo que permite levantar desde la DB los datos
         * del modulo. Se debe indicar que modulo se desea
         * cargar.
         */
        public void initializate (string moduleName)
        {
            if (moduleName != "" && moduleName != null)
            {
                /*
                 * Almaceno el valor en la propiedad correspondiente
                 */
                module_name = moduleName;

                /*
                 * Cargo el objeto.
                 */
                load();
            }
        }

        /*
         * Método que permite indicar que estado se debe setear
         * al modulo actual.
         */
        public void setModuleStatus(ModuleStatus moduleStatus)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            
            /*
             * Verifico que tengo el nombre del modulo, caso contrario
             * no puedo seguir operando.
             */
            if (module_name!="" && module_name!=null && moduleStatus!=null && moduleStatus.Idstatus!=null)
            {
                try
                {
                    db = DatabaseFactory.CreateDatabase("EvaSecurityDatabase");
                    dc = db.CreateConnection();
                    dc.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "PA_EVA_SetModuleCurrentStatus";
                    command.Connection = (SqlConnection)dc;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@module";
                    param.SqlDbType = SqlDbType.VarChar;
                    param.Direction = ParameterDirection.Input;
                    param.Value = module_name;

                    command.Parameters.Add(param);

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@id_status";
                    param2.SqlDbType = SqlDbType.Int;
                    param2.Direction = ParameterDirection.Input;
                    param2.Value = moduleStatus.Idstatus;

                    command.Parameters.Add(param2);

                    command.CommandType = CommandType.StoredProcedure;
                    dr = command.ExecuteReader();
                }
                catch(Exception ex)
                {
                    throw new GobbiTechnicalException("No se ha podido cambiar el estado del modulo.", ex);
                }
                finally
                {
                    if (dr != null && !dr.IsClosed) dr.Close();
                    if (dc != null && dc.State == ConnectionState.Open) dc.Close();
                }
            }
            else
            {
                if (module_name!="" && module_name!=null)
                {
                    throw new GobbiTechnicalException("No se especifica un estado a asignar.", null);
                }
                else
                {
                    throw new GobbiTechnicalException("No se indica modulo al cual aplicar el cambio de estado.", null);
                }
                
            }
        }

        #endregion
    }
}
