using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Interfaces.Parsers
{
    class DimagrafFacturaParser : FacturaOledbExcelParser
    {
        CultureInfo culture_esAR = new CultureInfo("es-AR", true);

        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            try
            {
                if (facturaDTO.idTipoComprobante.ToUpper().Equals("RV"))
                {

                    facturaDTO.idTipoComprobante = "FA";

                }
                else if (facturaDTO.idTipoComprobante.ToUpper().Equals("DG"))
                {
                    facturaDTO.idTipoComprobante = "ND";

                }
                else if (facturaDTO.idTipoComprobante.ToUpper().Equals("DB"))
                {

                    facturaDTO.idTipoComprobante = "NC";

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }

        public override DateTime getDateTime(string dateSubstring)
        {


            return System.DateTime.Parse(dateSubstring, culture_esAR, DateTimeStyles.NoCurrentDateDefault);
        }

        public override int getOffset()
        {
            return 10;
        }

        public override bool passes(FacturaDTO facturaDTO)
        {
            Boolean bPasses1 = false;
            Boolean bEliminar1 = false;
            Boolean bEliminar2 = false;

            bPasses1 = ("FA".Equals(facturaDTO.idTipoComprobante) || "NC".Equals(facturaDTO.idTipoComprobante) || "ND".Equals(facturaDTO.idTipoComprobante)) || ("RV".Equals(facturaDTO.idTipoComprobante) || "DG".Equals(facturaDTO.idTipoComprobante) || "DB".Equals(facturaDTO.idTipoComprobante));

          //  bEliminar1 = (("FA".Equals(facturaDTO.idTipoComprobante) || "RV".Equals(facturaDTO.idTipoComprobante)) && facturaDTO.saldo < 10.0f);

            //  bEliminar2 = (facturaDTO.nroComprobante != null && facturaDTO.nroComprobante.IndexOf('+') != -1);

            return bPasses1 ;//&& !bEliminar1 && !bEliminar2;
        }

        public override bool passesRow(System.Data.DataTable excel, int rCnt)
        {
            return true;
        }

        public override Boolean shouldProcessRow(System.Data.DataTable excel, int rCnt)
        {
            if (getColumnValue(excel, rCnt, 1) == "" && getColumnValue(excel, rCnt, 2) == ""
                 && getColumnValue(excel, rCnt, 3) == "")
            {
                _linesNotReaded++;
                return false;
            }

            return true;
        }

    }
}
