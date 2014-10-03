using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Interfaces.Parsers
{
    class ProductosAveryFacturaParser : FacturaOledbExcelParser

    {

        public override DateTime getDateTime(string dateSubstring)
        {
            return System.DateTime.Parse(dateSubstring);
        }

        public override int getOffset() {
            return -1;
        }


        public  override void applySpecificRules(FacturaDTO facturaDTO)
        {

            facturaDTO.idDeudor = facturaDTO.idDeudor.ToUpper();

            switch (facturaDTO.idTipoComprobante) { 
                case "FC":
                    facturaDTO.idTipoComprobante = "FA";

                    string emision = facturaDTO.emision;
                    string emisionRetval = "";
                    foreach (char c in emision) {
                        try {
                            Int16.Parse(c.ToString());

                             emisionRetval += c;
                        } catch (Exception e) {
                                Console.Write(c);
                        }
                        
                    }

                    facturaDTO.emision = emisionRetval;

                    break;
                case "CR":
                    facturaDTO.idTipoComprobante = "CH";
					facturaDTO.letra="R";
					facturaDTO.emision="0001";
                    
                    if (facturaDTO.nroComprobante.ToUpper().Substring(0,1).Equals ("K")) {

                        facturaDTO.nroComprobante = facturaDTO.nroComprobante.Substring(1,facturaDTO.nroComprobante.Length-1);
                    }

					break;
            }

            
        }
        public override bool passes(FacturaDTO facturaDTO)
        {

            return  (facturaDTO.idTipoComprobante.ToUpper().Equals("FA") || (facturaDTO.idTipoComprobante.ToUpper().Equals("CH") 
                            || (facturaDTO.idTipoComprobante.ToUpper().Equals("NC"))  || (facturaDTO.idTipoComprobante.ToUpper().Equals("ND")) ));

            
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
