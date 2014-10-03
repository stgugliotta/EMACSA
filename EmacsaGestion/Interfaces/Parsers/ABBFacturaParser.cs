using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Interfaces.Parsers
{
    class ABBFacturaParser : FacturaOledbExcelParser
    {
        CultureInfo culture_esAR = new CultureInfo("es-AR", true);
        

        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            try
            {
                if ("RG".Equals(facturaDTO.idTipoComprobante))
                {

                    facturaDTO.idTipoComprobante = "NC";

                }
                else
                {

                    if ("RV".Equals(facturaDTO.idTipoComprobante) || "RF".Equals(facturaDTO.idTipoComprobante))
                    {
                        facturaDTO.idTipoComprobante = "FA";
                    }
                    else if ("RD".Equals(facturaDTO.idTipoComprobante))
                    {
                        facturaDTO.idTipoComprobante = "ND";
                    }

                }

                if (facturaDTO.idMoneda != null && "ARS".Equals(facturaDTO.idMoneda.ToUpper()))
                {
                    facturaDTO.idMoneda = "PE";
                }
                else if (facturaDTO.idMoneda != null && "USD".Equals(facturaDTO.idMoneda.ToUpper()))
                {
                    facturaDTO.idMoneda = "DO";
                }
                else if (facturaDTO.idMoneda != null && "EUR".Equals(facturaDTO.idMoneda.ToUpper()))
                {
                    facturaDTO.idMoneda = "EU";
                }

                double tipoCambio = facturaDTO.importeMonedaLocal / facturaDTO.importe;
                double saldoEnMoneda = facturaDTO.saldo / tipoCambio;
                saldoEnMoneda  = Math.Round(saldoEnMoneda, 2);

                facturaDTO.saldo = saldoEnMoneda;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }

        public override DateTime getDateTime(string dateSubstring)
        {
            return System.DateTime.Parse(dateSubstring);
            //return System.DateTime.Parse(dateSubstring, culture_esAR, DateTimeStyles.NoCurrentDateDefault);
        }

        public override int getOffset()
        {
            return 0;
        }

        public override bool passes(FacturaDTO facturaDTO)
        {
            return "NC".Equals(facturaDTO.idTipoComprobante) || "FA".Equals(facturaDTO.idTipoComprobante) || "FD".Equals(facturaDTO.idTipoComprobante) ;
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
            catch (Exception e) {
                Console.Write(e);
            }

            return false;
        }




    }
}
