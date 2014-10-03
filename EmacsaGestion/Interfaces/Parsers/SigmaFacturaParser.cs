using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Parsers
{
    class SigmaFacturaParser : FacturaOledbExcelParser
    {
        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            if (facturaDTO.importe < 0)
            {
                facturaDTO.idTipoComprobante = "NC";
            }
            else
            {
                facturaDTO.idTipoComprobante = "FA";
            }

            if (facturaDTO.idMoneda != null && "ARS".Equals(facturaDTO.idMoneda.ToUpper()))
            {
                facturaDTO.idMoneda = "PE";
            }

        }

        public override DateTime getDateTime(string dateSubstring)
        {
            return System.DateTime.Parse(dateSubstring);
        }

        public override int getOffset()
        {
            return 0;
        }

        public override bool passes(FacturaDTO facturaDTO)
        {
            return facturaDTO.letra.Equals("A") || facturaDTO.letra.Equals("B") || facturaDTO.letra.Equals("E");
        }

        public override bool passesRow(System.Data.DataTable excel, int rCnt)
        {
            return true;
        }

        public override Boolean shouldProcessRow(System.Data.DataTable excel, int rCnt)
        {
            try
            {
                if (getColumnValue(excel, rCnt, 1) == "" && getColumnValue(excel, rCnt, 2) == ""
                    && getColumnValue(excel, rCnt, 3) == "")
                {
                    _linesNotReaded++;
                    return false;
                }

                return true;
            }
            catch (Exception ex) {
                Console.Write(ex);
            }
            return false;

        }

    }
}
