using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Interfaces.Parsers
{
    class VitopelFacturaParser : VitopelFacturaTextPlainParser
    {
        CultureInfo culture_esAR = new CultureInfo("es-AR", true);

        public override double getImporte(Property importe, string input)
        {
            string inputImporte = input.Substring(Int16.Parse(importe.from), Int16.Parse(importe.len)).Trim();

            double importe2 = 0;
            try
            {
                //facturaDTO.importe = Double.Parse(input.Replace('.', ','), cultureEsAR);
                if (inputImporte.IndexOf(',') == -1)
                {
                    importe2 = double.Parse(inputImporte.Replace('.', ','), cultureEsAR);
                }
                else
                {
                    try
                    {
                        importe2 = double.Parse(inputImporte, cultureEsAR);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            importe2 = double.Parse(inputImporte);
                        }
                        catch (Exception eex)
                        {
                            importe2 = double.Parse(inputImporte.Replace(",", "#").Replace(".", ",").Replace("#", ""));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return importe2;
        }


        public override void applySpecificRules(FacturaDTO facturaDTO)
        {
            try
            {
                if (facturaDTO.idTipoComprobante.StartsWith ("NC"))
                {

                    facturaDTO.idTipoComprobante = "NC";

                }
                else
                {

                    if ("FACT".Equals(facturaDTO.idTipoComprobante))
                    {
                        facturaDTO.idTipoComprobante = "FA";
                    }
                    else if (facturaDTO.idTipoComprobante.StartsWith ("ND"))
                    {
                        facturaDTO.idTipoComprobante = "ND";
                    }

                }

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
            return "NC".Equals(facturaDTO.idTipoComprobante) || "FA".Equals(facturaDTO.idTipoComprobante) || "ND".Equals(facturaDTO.idTipoComprobante) ;
        }





    }
}
