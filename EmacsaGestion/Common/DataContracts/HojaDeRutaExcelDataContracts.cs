using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataContracts
{
	/// <summary>
	/// Creado		: 2010-07-01
	/// Objeto		: EMACSA_NUCLEO.dbo.mtr_hoja
	/// Descripcion	: 
	/// </summary>
	public class HojaDeRutaExcelDataContracts
	{
	
		/// <summary>
		/// Constructor standard para el objeto Hoja
		/// </summary>
		public  HojaDeRutaExcelDataContracts() 
				{
				}


        private int _idHojaDeRuta;
        private string _usuario;
        private List<ItemHojaDataContracts> _itemsHoja;
        private List<ItemHojaDSGDataContracts> _itemsHojaDSG;
        private List<DeudorHojaDeRutaDataContracts> _deudoresDeLaHojaConGestion;
        private List<DeudorHojaDeRutaDataContracts> _deudoresDeLaHojaSinGestion;


        public int IdHojaDeRuta
        {
            get { return _idHojaDeRuta; }
            set { _idHojaDeRuta = value; }
        }

        public string UsuarioCreador
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public List<ItemHojaDataContracts > ItemsHoja
        {
        
        get{ return _itemsHoja;}
            set{ _itemsHoja = value;}
        }

        public List<ItemHojaDSGDataContracts> ItemsHojaDSG
        {

            get { return _itemsHojaDSG; }
            set { _itemsHojaDSG = value; }
        }

        public List<DeudorHojaDeRutaDataContracts> DeudoresDeLahojaConGestion
        {
            get { return _deudoresDeLaHojaConGestion; }
            set { _deudoresDeLaHojaConGestion = value; }

        }

        public List<DeudorHojaDeRutaDataContracts> DeudoresDeLahojaSinGestion
        {
            get { return _deudoresDeLaHojaSinGestion; }
            set { _deudoresDeLaHojaSinGestion = value; }

        }

	}
}
