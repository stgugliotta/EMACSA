using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Interfaces.Parsers
{
    class TycoFacturaParser : FacturaTextPlainParser

    {


        public override DateTime getDateTime(string dateSubstring)
        {

            string d = dateSubstring.Substring(0, 2);
            string m = dateSubstring.Substring(2, 2);
            string a = dateSubstring.Substring(4, 2);

            string fecha = d + "/" + m + "/" + a;

            return System.DateTime.Parse(fecha);
        }

        public override int getOffset() {
            return 13;
        }


        public  override void applySpecificRules(FacturaDTO facturaDTO)
        {


            switch (facturaDTO.idTipoComprobante) {
                case "FACT":
                    facturaDTO.idTipoComprobante = "FA";
                    break;
                case "CRED":
                    facturaDTO.idTipoComprobante = "NC";
                    break;
                case "DEBI":
                    facturaDTO.idTipoComprobante = "ND";
                    break;
            }
            switch (facturaDTO.idMoneda)
            {
                case "USD":
                    facturaDTO.idMoneda = "DO";
    				break;
                case "PES":
                    facturaDTO.idMoneda = "PE";
                    break;
                case "EUR":
                    facturaDTO.idMoneda = "EU";
                    break;
            }

            if (facturaDTO.idDeudor != null) {
                try
                {
                    char[] charsToTrim = { '0' };
                    facturaDTO.idDeudor = facturaDTO.idDeudor.TrimStart(charsToTrim);
                    
                }
                catch (Exception ex) { 

                }
            }
            
        }

        public override double getImporte(Property importe, string input)
        {
            string importeLeido = input.Substring(Int16.Parse(importe.from), Int16.Parse(importe.len));

            if (importeLeido.EndsWith("-")) { 
                importeLeido = "-" + importeLeido.Replace('-',' ').Trim();
            }

            return Double.Parse(importeLeido.Trim().Replace('.', ','));
        }

        public override bool passes(FacturaDTO facturaDTO)
        {
            return (
                (facturaDTO.idTipoComprobante.ToUpper().Equals("FA") || facturaDTO.idTipoComprobante.ToUpper().Equals("ND") || facturaDTO.idTipoComprobante.ToUpper().Equals("NC") ) 
			    &&  (facturaDTO.letra.ToUpper().Equals("A") || facturaDTO.letra.ToUpper().Equals("B") || facturaDTO.letra.ToUpper().Equals("C") || facturaDTO.letra.ToUpper().Equals("E") ));
        }
    }
}
