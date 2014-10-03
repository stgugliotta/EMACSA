using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
    /// <summary>
    /// Creado		: 2010-07-17
    /// Objeto		: EMACSA_NUCLEO.dbo.tbl_deudor_dia_cobro
    /// Descripcion	: 
    /// </summary>
    public class DeudorDiaCobroDataContracts
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor standard para el objeto DeudorDiaCobro
        /// </summary>
        public DeudorDiaCobroDataContracts()
        {
        }
        #endregion

        #region A T T R I B U T E S
        /// <summary>
        /// 
        /// </summary>
        private int idDiaCobro;

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

        #endregion

        #region P U B L I C  P R O P E R T I E S
        /// <summary>
        /// 
        /// </summary>
        /// <value>int</value>
        public int IdDiaCobro
        {
            get { return this.idDiaCobro; }
            set { this.idDiaCobro = value; }
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
