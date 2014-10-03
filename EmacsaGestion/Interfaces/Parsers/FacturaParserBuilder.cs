using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Parsers
{
    class FacturaParserBuilder
    {

        private static FacturaParserBuilder _instance;

        public static FacturaParserBuilder getInstance() {

            if (_instance == null) {
                _instance = new FacturaParserBuilder();
            }

            return _instance;
        }

        public Parser build(String parserName)
        {

            Parser parser = null;

            try
            {
                System.Type oType = System.Type.GetType(parserName, true);

                parser = (Parser)System.Activator.CreateInstance(oType);

                return parser;
            }
            catch (TypeLoadException e)
            {
                throw new InvalidOperationException("Type could " +
                    "not be created. Check innerException " +
                    "for details", e);
            }

            
        }


    }
}
