using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Parsers
{
    abstract class Parser
    {
        public abstract List<FacturaDTO> parse(String fileFullName, ClienteInterfaz cliente);
        public abstract DateTime getDateTime(string dateSubstring);
        public abstract int getOffset();
        public abstract void applySpecificRules(FacturaDTO facturaDTO);
        public abstract Boolean passes(FacturaDTO facturaDTO);
    }
}
