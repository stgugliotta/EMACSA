using System;
using System.Collections.Generic;
using System.Text;
using Gobbi.CoreServices.Security.Authentication;
using Gobbi.CoreServices.Configuration;
using Gobbi.CoreServices.Security.Principal;
using Gobbi.CoreServices.ExceptionHandling;
using System.DirectoryServices;
using System.Data;
using Gobbi.CoreServices.ExceptionHandling;
using System.Data.SqlClient;
using Gobbi.CoreServices.Data;
using System.Data.Common;

namespace Gobbi.CoreServices.Security.Authentication.Provider
{
    class MOCAuthenticationProvider : IAuthenticationProvider, IConfigurable
    {

        #region Campos privados
        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        string providerName;
        /// <summary>
        /// Dominio por defecto
        /// </summary>
        string defaultDomain;
        #endregion Campos privados

        #region Getters & Setters
        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        string IAuthenticationProvider.Name
        {
            get
            {
                return providerName;
            }
        }

        /// <summary>
        /// Dominio por defecto
        /// </summary>
        string IAuthenticationProvider.DefaultDomain
        {
            get
            {
                return defaultDomain;
            }
        }


        /// <summary>
        ///  Servidor de aplcacion
        /// </summary>
        string IAuthenticationProvider.DefaultServer
        {
            get
            {
                throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
            }
        }

        AuthenticationTypes IAuthenticationProvider.AuthType
        {
            get
            {
                throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
            }
        }
        #endregion Getters & Setters

        #region Constructor
        /// <summary>
        /// Constructor por defecto para permitir ser instanciado dinamicamente
        /// </summary>
        /// <param name="ProviderType"></param>
        public MOCAuthenticationProvider(string ProviderType) { }
        #endregion Constructor

        #region Metodos de la interfaz



        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario. El proveedor utilizará el dominio por defecto que esté configurado"</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity IAuthenticationProvider.ValidateUser(string user, string password)
        {
            return this.Validate(user, this.defaultDomain, password);
        }

        GobbiIdentity IAuthenticationProvider.ValidateUserGobbi(string user, string password)
        {
            return this.ValidateGobbi(user, password);
        }

        GobbiIdentity ValidateGobbi(string user, string password)
        {
            GobbiIdentity id = null;
            string[] userRes=GetUser(user);

            if (password == userRes[0])
            {
                id = new GobbiIdentity(user, user, int.Parse(userRes[1]), userRes[2], userRes[3]);
            }
            return id;
        }

        private string[] GetUser(string user)
        {
            Database db = null;
            DbConnection dc = null;
            SqlDataReader dr = null;
            try
            {
                db = DatabaseFactory.CreateDatabase("Gobbi");
                dc = db.CreateConnection();
                dc.Open();

                SqlCommand command = new SqlCommand("PA_SECURITY_GetDataUser", (SqlConnection)dc);

                SqlParameter paramUser = new SqlParameter();
                paramUser.ParameterName = "@userName";
                paramUser.SqlDbType = SqlDbType.VarChar;
                paramUser.Size = 255;
                paramUser.Direction = ParameterDirection.Input;
                paramUser.Value = user; 

                command.Parameters.Add(paramUser);

                command.CommandType = CommandType.StoredProcedure;
                dr = command.ExecuteReader();

                string[] pass=new string[4];
                while (dr.Read())
                {
                    
                    pass[0] = dr["password"].ToString();
                    pass[1] = dr["UserId"].ToString();
                    pass[2] = dr["email"].ToString();
                    pass[3] = dr["passwordMail"].ToString();

                    
                }
                return pass;
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
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity IAuthenticationProvider.ValidateUser(string user, string domain, string password)
        {
            return this.Validate(user, domain, password);
        }

        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity Validate(string user, string domain, string password)
        {
            EvaIdentity id = null;
            if (user == password)
            {
                id = new EvaIdentity(user, user);
            }
            return id;
        }


        ///<summary>
        /// Crea un nuevo usuario con los datos provistos. El proveedor utilizará el dominio por defecto que esté configurado. Este proveedor no implementa la funcionalidad de crear usuarios
        ///</summary>
        ///<param name="user">
        /// Nombre de usuario
        /// </param>
        ///<param name="password">
        /// Contraseña
        /// </param>
        ///<param name="email">
        ///E-mail del usuario
        /// </param>
        void IAuthenticationProvider.CreateUser(string user, string password, string email)
        {
            throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
        }

        /// <summary>
        /// Crea un nuevo usuario con los datos provistos. Este proveedor no implementa la funcionalidad de crear usuarios
        /// </summary>
        /// <param name="user">Nombre de usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <param name="email">E-mail del usuario</param>
        void IAuthenticationProvider.CreateUser(string user, string domain, string password, string email)
        {
            throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
        }

        ///<summary>
        /// Elimina un usario. El proveedor utilizará el dominio por defecto que esté configurado. Este proveedor no implementa la funcionalidad de eliminar usuarios
        ///</summary>
        ///<param name="user">
        /// Nombre de usuario a eliminar
        /// </param>
        void IAuthenticationProvider.DeleteUser(string user)
        {
            throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
        }

        /// <summary>
        /// Elimina un usario. Este proveedor no implementa la funcionalidad de eliminar usuarios
        /// </summary>
        /// <param name="user">Nombre de usuario a eliminar</param>
        /// <param name="domain">Dominio</param>
        void IAuthenticationProvider.DeleteUser(string user, string domain)
        {
            throw new NotImplementedException("Este provedor no implementa la funcionalidad requerida");
        }
        #endregion Metodos de la interfaz

        #region IConfigurable Members

        void IConfigurable.Configure(System.Configuration.ConfigurationElement element)
        {
            AuthenticationManagerConfiguration config = element as AuthenticationManagerConfiguration;
            this.defaultDomain = config.DefaultDomain;
        }

        #endregion
    }

}

