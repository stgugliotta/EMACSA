using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
    /// <summary>
    ///  Clase Entidad de la tabla dbo.TBL_Deudor_Dia_Cobro
    /// </summary>
    public class DeudorDiaCobro : Entity<DeudorDiaCobro, DeudorDiaCobroDataContracts>
    {
        #region C O N S T R U C T O R S
        /// <summary>
        /// Constructor Standard de  DeudorDiaCobro
        /// </summary>
        public DeudorDiaCobro()
        {
        }
        #endregion

        #region A T T R I B U T E S
        private int idDiaCobro;
        private int idDeudor;
        private int idDia;
        private string horarioDesde;
        private string horarioHasta;
        #endregion

        #region P U B L I C    P R O P E R T I E S
        public int IdDiaCobro
        {
            get { return this.idDiaCobro; }
            set { this.idDiaCobro = value; }
        }

        public int IdDeudor
        {
            get { return this.idDeudor; }
            set { this.idDeudor = value; }
        }

        public int IdDia
        {
            get { return this.idDia; }
            set { this.idDia = value; }
        }

        public string HorarioDesde
        {
            get { return this.horarioDesde; }
            set { this.horarioDesde = value; }
        }

        public string HorarioHasta
        {
            get { return this.horarioHasta; }
            set { this.horarioHasta = value; }
        }


        #endregion
    }
}
