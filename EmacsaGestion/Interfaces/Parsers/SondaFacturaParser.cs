using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Interfaces.Parsers
{
    class SondaFacturaParser : FacturaOledbExcelParser
    {
        CultureInfo culture_esAR = new CultureInfo("es-AR", true);

        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            if("ND".Equals(facturaDTO.idTipoComprobante.Substring(0,2))) {
                facturaDTO.idTipoComprobante = "ND";
            } else if ("Fa".Equals(facturaDTO.idTipoComprobante.Substring(0,2)) || "FC".Equals(facturaDTO.idTipoComprobante.Substring(0,2))) {
                facturaDTO.idTipoComprobante = "FA";
            }

            if ("U$S".Equals(facturaDTO.idMoneda.Trim()))
            {
                facturaDTO.idMoneda = "DO";
            }
            else if ("$".Equals(facturaDTO.idMoneda.Trim()))
            {
                facturaDTO.idMoneda = "PE";
            }
        }

        public override DateTime getDateTime(string dateSubstring)
        {
            //return System.DateTime.Parse(dateSubstring);
            return System.DateTime.Parse(dateSubstring, culture_esAR, DateTimeStyles.NoCurrentDateDefault);
        }

        public override int getOffset()
        {
            return 6;
        }

        public override bool passes(FacturaDTO facturaDTO)
        {
            return facturaDTO.idTipoComprobante.Equals("FA") || facturaDTO.idTipoComprobante.Equals("ND") || facturaDTO.idTipoComprobante.Equals("NC");
        }

        public override bool passesRow(System.Data.DataTable excel, int rCnt)
        {
            return true;
        }

        public override Boolean shouldProcessRow(System.Data.DataTable excel, int rCnt)
        {
            try
            {
                if (getColumnValue(excel, rCnt, 1).ToLower().Equals("clirut")) {
                    _linesNotReaded = 0;
                    return false;
                }
                
                if (getColumnValue(excel, rCnt, 1) == "" && getColumnValue(excel, rCnt, 2) == ""
                    && getColumnValue(excel, rCnt, 3) == "")
                {
                    _linesNotReaded++;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return false;

        }

        public override Boolean shouldContinueReading()
        {
            return !(_linesNotReaded >= 5);
        }


    }
}
