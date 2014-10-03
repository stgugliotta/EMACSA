using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Parsers
{
    class OcasaFacturaParser : FacturaExcelParser
    {
        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            if (facturaDTO.importe < 0) {
                facturaDTO.idTipoComprobante = "NC";
            } else {
                facturaDTO.idTipoComprobante = "FA";
            }
        }

        public override DateTime getDateTime(string dateSubstring)
        {
            return System.DateTime.Parse(dateSubstring);
        }

        public override int getOffset()
        {
            return 1;
        }

        public override bool passes(FacturaDTO facturaDTO)
        {
            return facturaDTO.letra.Equals("A") || facturaDTO.letra.Equals("B");
        }

        public override bool passesRow(Herramientas.ExcelHandler excel, Microsoft.Office.Interop.Excel.Range range, int rCnt)
        {
            return ("EMAC".Equals(getColumnValue(excel, range, rCnt, 7)) && getColumnValue(excel, range, rCnt, 4).Length == 13);
        }
    }
}
