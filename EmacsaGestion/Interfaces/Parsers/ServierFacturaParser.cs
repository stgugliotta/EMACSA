using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Interfaces.Parsers
{
    class ServierFacturaParser : FacturaOledbExcelParser
    {
        CultureInfo culture_esAR = new CultureInfo("es-AR", true);

        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            try
            {
                if (facturaDTO.idTipoComprobante.ToUpper().Equals("F"))
                {

                    facturaDTO.idTipoComprobante = "FA";

                }
                else if (facturaDTO.idTipoComprobante.ToUpper().Equals("N"))
                {
                    facturaDTO.idTipoComprobante = "NC";

                }
                else if (facturaDTO.idTipoComprobante.ToUpper().Equals("D"))
                {

                    facturaDTO.idTipoComprobante = "ND";

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
            return ("FA".Equals(facturaDTO.idTipoComprobante) || "NC".Equals(facturaDTO.idTipoComprobante) || "ND".Equals(facturaDTO.idTipoComprobante)) || ("F".Equals(facturaDTO.idTipoComprobante) || "N".Equals(facturaDTO.idTipoComprobante) || "D".Equals(facturaDTO.idTipoComprobante));
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
