using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Forma_Pago
    /// </summary>
    public class FormaPago : Entity<FormaPago, FormaPagoDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  FormaPago
        /// </summary>
        public FormaPago()
        {
        }
        public FormaPago(int idFormaPago,string descripcion)
        {
            this.idFormaPago = idFormaPago;
            this.descripcion = descripcion;
        }
        #endregion

        #region A T T R I B U T E S
        private int idFormaPago;
        private string descripcion;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdFormaPago
        {
            get { return this.idFormaPago; }
            set { this.idFormaPago = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }


        #endregion
    }
}
