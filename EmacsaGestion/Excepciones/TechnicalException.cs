using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class TechnicalException:System.Exception 
    {

        public TechnicalException(string message, Exception ex)
        { }
    }
}
