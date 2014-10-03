using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Interfaces.Parsers
{
    class MasisaFacturaParser : FacturaOledbExcelParser
    {
        CultureInfo culture_esAR = new CultureInfo("es-AR", true);

        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            try
            {
                if (facturaDTO.idTipoComprobante.ToUpper().Equals("DR") || facturaDTO.idTipoComprobante.ToUpper().Equals("DE"))
                {

                    facturaDTO.idTipoComprobante = "FA";

                }
                else if (facturaDTO.idTipoComprobante.ToUpper().Equals("DD"))
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
            return ("FA".Equals(facturaDTO.idTipoComprobante) || "ND".Equals(facturaDTO.idTipoComprobante)) || ("DD".Equals(facturaDTO.idTipoComprobante) || "DR".Equals(facturaDTO.idTipoComprobante) || "DE".Equals(facturaDTO.idTipoComprobante));
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
