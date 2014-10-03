using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Agenda
    /// </summary>
    public class Mail : Entity<Mail, MailDataContracts>
    {

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


        /// <summary>
        /// Constructor Standard de  Agenda
        /// </summary>
        public Mail()
        {
        }

        
    }
}
