using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class FunctionalException:System.Exception 
    {

        public FunctionalException(string message, Exception ex)
        { }
    }
}
