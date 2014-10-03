using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.DataContracts
{
    public class BusquedaDataContracts
    {

        private bool _radioDeudor=false;
        private bool _radioDescription = false;
        private bool _radioCliente = false;
        private bool _radioAVencer = false;
        private bool _radioAnalista = false;
        private DataTable _results;
        private List<object> _parameters=new List<object>();
        private int _numPage;

        public bool RadioDeudor
        {
            get { return _radioDeudor; }
            set { _radioDeudor = value; }
        }

        public bool RadioDescription
        {
            get { return _radioDescription; }
            set { _radioDescription = value; }
        }

        public bool RadioCliente
        {
            get { return _radioCliente; }
            set { _radioCliente = value; }
        }

        public bool RadioAVencer
        {
            get { return _radioAVencer; }
            set { _radioAVencer = value; }
        }

        public bool RadioAnalista
        {
            get { return _radioAnalista; }
            set { _radioAnalista = value; }
        }

        public DataTable Results
        {
            get { return _results; }
            set { _results = value; }
        }

        public int NumPage
        {
            get { return _numPage; }
            set { _numPage = value; }
        }

        public List<object> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
