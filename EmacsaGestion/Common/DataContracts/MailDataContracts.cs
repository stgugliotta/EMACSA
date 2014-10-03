using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-02-26
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_agenda
    /// Descripcion	: 
    /// </summary>
    public class MailDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto Agenda
        /// </summary>
        public MailDataContracts()
        {
        }

        private int _idMail;

        public int IdMail
        {
            get { return _idMail; }
            set { _idMail = value; }
        }
        private int _idCliente;

        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _contacto;

        public string Contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }



        #endregion

    }
}