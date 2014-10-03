using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Parsers
{
    class StymFacturaParser : FacturaExcelParser
    {
        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            if (facturaDTO.idTipoComprobante.ToUpper() == "FA") {
                facturaDTO.idTipoComprobante = "FA";
            }
            else if (facturaDTO.idTipoComprobante.ToUpper() == "CR")
            {
                facturaDTO.idTipoComprobante = "NC";
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
            return (facturaDTO.idTipoComprobante.Equals("FA") || facturaDTO.idTipoComprobante.Equals("NC")) && facturaDTO.letra != null && !"".Equals(facturaDTO.letra.Trim());
        }

        public override bool passesRow(Herramientas.ExcelHandler excel, Microsoft.Office.Interop.Excel.Range range, int rCnt)
        {
            return true;
        }
    }
}
