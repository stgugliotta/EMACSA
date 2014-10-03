using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Parsers
{
    class PutrueleV2FacturaParser : FacturaOledbExcelParser
    {
        

        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            try
            {
                if (facturaDTO.idTipoComprobante.ToUpper ().StartsWith("NC"))
                {

                    facturaDTO.idTipoComprobante = "NC";

                }
                else
                {

                    if (facturaDTO.idTipoComprobante.ToUpper().StartsWith ("FE"))
                    {
                        facturaDTO.idTipoComprobante = "FA";
                    }
                    else
                    {
                        facturaDTO.idTipoComprobante = "ND";
                    }

                }

                // El ultimo caracter de la letra es la letra A o B
                string letra = facturaDTO.letra.ToCharArray()[facturaDTO.letra.Length - 1].ToString();
                facturaDTO.letra = letra;
                
            }
            catch (Exception ex)
            {
                Console.Write(ex);
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
            return "A".Equals(facturaDTO.letra) || "B".Equals(facturaDTO.letra) || "E".Equals(facturaDTO.letra);
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
