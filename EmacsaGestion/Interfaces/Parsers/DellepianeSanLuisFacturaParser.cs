using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Interfaces.Parsers
{
    class DellepianeSanLuisFacturaParser : FacturaOledbExcelParser
    {
        CultureInfo culture_esAR = new CultureInfo("es-AR", true);

        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            try
            {
                if (facturaDTO.importe < 0)
                {

                    facturaDTO.idTipoComprobante = "NC";

                }
                else
                {

                    facturaDTO.idTipoComprobante = "FA";

                }

                // reemplazo de codigos especiales de cliente:
                //Diarco: Al codigo 0054765T, reemplazarlo por 54765
                
                if (facturaDTO.idDeudor.Equals("0054765T"))
                {
                    facturaDTO.idDeudor = "54765";
                }

                //Makro - Al codigo 0058726C, reemplazarlo por 0058726S
                if (facturaDTO.idDeudor.Equals("0058726C"))
                {
                    facturaDTO.idDeudor = "0058726S";
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
            return "FA".Equals(facturaDTO.idTipoComprobante);
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
