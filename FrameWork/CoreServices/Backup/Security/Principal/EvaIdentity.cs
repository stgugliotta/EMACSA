using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace ar.com.telecom.eva.CoreServices.Security.Principal
{
    /// <summary>
    /// Reppresenta la identidad de un usuario
    /// </summary>
    public class EvaIdentity : IIdentity
    {
        #region Attributes

        private string name;
        private string fullName;
        /// <summary>
        /// Telefono
        /// </summary>
        private string telephoneNumber;
        /// <summary>
        ///  Apellido
        /// </summary>
        private string sn;
        /// <summary>
        /// Departamento
        /// </summary>
        private string orgUnit;
        /// <summary>
        /// Cargo
        /// </summary>
        private string title;
        /// <summary>
        /// Legajo
        /// </summary>
        private string employeeNumber;
        /// <summary>
        /// Nombre
        /// </summary>
        private string givenName;
        /// <summary>
        /// Clase de empleado
        /// </summary>
        private string employeeType; 
        /// <summary>
        /// DN del usuario al que reporta
        /// </summary>
        private string manager;
        /// <summary>
        /// Codigo de la estructura
        /// </summary>
        private string departmentNumber;
        /// <summary>
        /// Compañia
        /// </summary>
        private string company;
        /// <summary>
        /// Direccion de correo electronico
        /// </summary>
        private string mail;
        /// <summary>
        /// Esquema funcional
        /// </summary>
        private string businessCategory;
        /// <summary>
        /// numero de documento
        /// </summary>
        private string tDocumentNumber;
        /// <summary>
        /// fecha de contratacion
        /// </summary>
        private string tHireDate;
        /// <summary>
        /// descripcion del puesto
        /// </summary>
        private string tTituloPuesto;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="name">Nombre del usuario</param>
        public EvaIdentity(string name, string fullname)
        {
            this.name = name;
            this.fullName = fullname;
        }
        public EvaIdentity()
        {
        }

        #endregion Constructor

        #region Properties

        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Sn
        {
            get { return sn; }
            set { sn = value; }
        }
        public string TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }
        public string OrgUnit
        {
            get { return orgUnit; }
            set { orgUnit = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        public string GivenName
        {
            get { return givenName; }
            set { givenName = value; }
        }

        public string EmployeeType
        {
            get { return employeeType; }
            set { employeeType = value; }
        }

        public string Manager
        {
            get { return manager; }
            set { manager = value; }
        }

        public string DepartmentNumber
        {
            get { return departmentNumber; }
            set { departmentNumber = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string BusinessCategory
        {
            get { return businessCategory; }
            set { businessCategory = value; }
        }

        public string TDocumentNumber
        {
            get { return tDocumentNumber; }
            set { tDocumentNumber = value; }
        }

        public string THireDate
        {
            get { return tHireDate; }
            set { tHireDate = value; }
        }

        public string TTituloPuesto
        {
            get { return tTituloPuesto; }
            set { tTituloPuesto = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        /// <summary>
        /// Indica el tipo de autenticación
        /// </summary>
        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        /// <summary>
        /// <see langword="true"/> si se encuentra autenticado.
        /// </summary>
        public bool IsAuthenticated
        {
            get { return true; }
        }
        #endregion
    }
}
