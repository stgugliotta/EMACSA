using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts
{
    public interface IPago
    {


         int IDPago { get; set; }
         DateTime FechaPago { get; set; }
         FormaPagoDataContracts FormaPago { get; set; }
         float Importe { get; set; }
         int Orden { get; set; }
    }
}
