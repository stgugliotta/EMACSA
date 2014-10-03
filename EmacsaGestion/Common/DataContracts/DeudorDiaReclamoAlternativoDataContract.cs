using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-07-17
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_deudor_dia_reclamo
    /// Descripcion	: 
    /// </summary>
    public class DeudorDiaReclamoAlternativoDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto DeudorDiaReclamo
        /// </summary>
        public DeudorDiaReclamoAlternativoDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idDiaReclamo;

        /// <summary>
        /// 
        /// </summary>
        private int idDeudor;

        /// <summary>
        /// 
        /// </summary>
        private int idDia;

        /// <summary>
        /// 
        /// </summary>
        private string horarioDesde;

        /// <summary>
        /// 
        /// </summary>
        private string horarioHasta;

        private int idAccion;

        private int position;

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDiaReclamo
        {
            get { return this.idDiaReclamo; }
            set { this.idDiaReclamo = value; }
        }

        public int Position
        {
            get { return this.position ; }
            set { this.position = value; }
        }

        public int IdAccion
        {
            get { return this.idAccion; }
            set { this.idAccion = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDia
        {
            get { return this.idDia; }
            set { this.idDia = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string HorarioDesde
        {
            get { return this.horarioDesde; }
            set { this.horarioDesde = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>string</value>
        public string HorarioHasta
        {
            get { return this.horarioHasta; }
            set { this.horarioHasta = value; }
        }

        #endregion
    }
}
