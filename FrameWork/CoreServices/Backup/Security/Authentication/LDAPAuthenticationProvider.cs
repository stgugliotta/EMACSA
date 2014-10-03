using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using ar.com.telecom.eva.CoreServices.Security.Authentication;
using ar.com.telecom.eva.CoreServices.Configuration;
using ar.com.telecom.eva.CoreServices.Security.Principal;
using ar.com.telecom.eva.CoreServices.ExceptionHandling;
using ar.com.telecom.eva.CoreServices.Logging;

namespace ar.com.telecom.eva.CoreServices.Security.Authentication.Provider
{
    class LDAPAuthenticationProvider : IAuthenticationProvider, IConfigurable
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
        /// <summary>
        /// Nombre del usuario para impersonar
        /// </summary>
        string applicationUsername;
        /// <summary>
        /// Password para impersonar
        /// </summary>
        string applicationPassword;
        /// <summary>
        /// Nombre de servidor
        /// </summary>
        string defaultServer;

        AuthenticationTypes authType;
        
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
        ///  Servidor de autenticacion
        /// </summary>
        string IAuthenticationProvider.DefaultServer
        {
            get
            {
                return defaultServer;
            }
        }

        /// <summary>
        /// Tipo de autenticación
        /// </summary>
        AuthenticationTypes IAuthenticationProvider.AuthType
        {
            get
            {
                return authType;
            }
        }
        #endregion Getters & Setters

        #region Constructor
        /// <summary>
        /// Constructor por defecto para permitir ser instanciado dinamicamente
        /// </summary>
        /// <param name="ProviderType"></param>
        public LDAPAuthenticationProvider(string ProviderType) { }
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

        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario</param>
        /// <param name="domain">Dominio</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity IAuthenticationProvider.ValidateUser(string user, string domain, string password)
        {
            return this.Validate(user, password);   
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
            try
            {
                // Realiza un split del dominio para pasarlo a formato "DC=,..."
                string[] splittedDomain = domain.Split('.');
                StringBuilder sb = new StringBuilder("LDAP://DC=");
                sb.Append(splittedDomain[0]);
                for (int x = 1; x < splittedDomain.Length; x++)
                {
                    sb.Append(",DC=");
                    sb.Append(splittedDomain[x]);
                }
                // Obtiene la entrada autenticada
                DirectoryEntry entry = new DirectoryEntry(sb.ToString(), user, password);

                // Realiza el bind al objeto AdsObject nativo para asegurar la autenticación 			
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + user + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    // Obtiene del servicio de directorio la entrada completa

                    DirectoryEntry de = result.GetDirectoryEntry();
                    // Extrae los valores de la entrada de AD para construir el objeto EvaIdentity
                    string fullName = de.InvokeGet("FullName") as string;
                    // Extraer mas valores de AD de TECO para completar el Identity

                    // Construye y retorna el objeto EvaIdentity
                    EvaIdentity evaid = new EvaIdentity();
                    return evaid;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new EvaTechnicalException("Error al autenticar usuario", e);
            }
        }


        /// <summary>
        /// Valida las credenciales de usuario
        /// </summary>
        /// <param name="user">Nombre de red del usuario</param>
        /// <param name="password">Contraseña</param>
        /// <returns>True si el usuario y contraseña son validados correctamente por el controlador de dominio</returns>
        EvaIdentity Validate(string user, string password)
        {
            try
            {

                Logger.WriteInformation("WF Core Debugging", "DefaultServer: " + defaultServer + " DefaultDomain: " + defaultDomain,"WF-CORE");
                Logger.WriteInformation("WF Core Debugging", "applicationUserName: " + applicationUsername + " applicationPassword: NONONNO", "WF-CORE");
                Logger.WriteInformation("WF Core Debugging", "authType: " + authType, "WF-CORE");
                DirectoryEntry appEntry = new DirectoryEntry(defaultServer + defaultDomain, applicationUsername, applicationPassword, authType);                
                // Realiza el bind al objeto AdsObject nativo para asegurar la autenticación 			
                object objApp = appEntry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(appEntry);
                search.SearchScope = SearchScope.Subtree;

                Logger.WriteInformation("WF Core Debugging", "User: " + user, "WF-CORE");

                search.Filter = "(&(objectClass=TelecomPerson)(cn=" + user + "))";
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    Logger.WriteInformation("WF Core Debugging", "Bingo!", "WF-CORE");
                    
                    // Obtiene del servicio de directorio la entrada completa
                    DirectoryEntry de = result.GetDirectoryEntry();
                    
                    // Impersona como el usuario
                    string uid = de.InvokeGet("uid") as string;
                    string dn = "uid = " + uid + "," + defaultDomain;
                    
                    Logger.WriteInformation("WF Core Debugging", "Dn: " + dn + "Pass: " + password, "WF-CORE");

                    DirectoryEntry userEntry = new DirectoryEntry(defaultServer + defaultDomain, dn, password, authType);

                    // Realiza el bind al objeto AdsObject nativo para asegurar la autenticación 			
                    object objUser = userEntry.NativeObject;
                                       
                    // Extrae los valores de la entrada de AD para construir el objeto EvaIdentity
                    string sn = de.InvokeGet("sn") as string;
                    string telephoneNumber = de.InvokeGet("telephoneNumber") as string;
                    string orgUnit = de.InvokeGet("ou") as string;
                    string title = de.InvokeGet("title") as string;
                    string employeeNumber = de.InvokeGet("employeeNumber") as string;
                    string givenName = de.InvokeGet("givenName") as string;
                    string employeeType = de.InvokeGet("employeeType") as string;
                    string manager = de.InvokeGet("manager") as string;
                    string departmentNumber = de.InvokeGet("departmentNumber") as string;
                    string company = de.InvokeGet("o") as string;
                    string mail = de.InvokeGet("mail") as string;
                    string businessCategory = de.InvokeGet("businessCategory") as string;
                    string tDocumentNumber = de.InvokeGet("tDocumentNumber") as string;
                    string tHireDate = de.InvokeGet("tHireDate") as string;
                    string tTituloPuesto = de.InvokeGet("tTituloPuesto") as string;

                    // Construye y retorna el objeto EvaIdentity
                    EvaIdentity evaid = new EvaIdentity(uid,uid);
                    evaid.Sn = sn;
                    evaid.TelephoneNumber = telephoneNumber;
                    evaid.OrgUnit = orgUnit;
                    evaid.Title = title;
                    evaid.EmployeeNumber = employeeNumber;
                    evaid.GivenName = givenName;
                    evaid.EmployeeType = employeeType;
                    evaid.Manager = manager;
                    evaid.DepartmentNumber = departmentNumber;
                    evaid.Company = company;
                    evaid.Mail = mail;
                    evaid.BusinessCategory = businessCategory;
                    evaid.TDocumentNumber = tDocumentNumber;
                    evaid.THireDate = tHireDate;
                    evaid.TTituloPuesto = tTituloPuesto;
                 
                    return evaid;
                }
                else
                {
                    Logger.WriteInformation("WF Core Debugging", "Sin resultados en la busqueda.", "WF-CORE");
                    return null;
                }
            }
            catch (Exception e)
            {
                Logger.WriteInformation("WF Core Debugging", "Excepcion Error al autenticar usuario: " + e.ToString(), "WF-CORE");
                
                throw new EvaTechnicalException("Error al autenticar usuario", e);
            }
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
            this.applicationUsername = config.ApplicationUsername;
            this.applicationPassword = config.ApplicationPassword;
            this.defaultServer = config.DefaultServer;
            this.authType = (AuthenticationTypes)Enum.Parse(typeof(AuthenticationTypes), config.AuthType);
        }
        #endregion
    }
}
