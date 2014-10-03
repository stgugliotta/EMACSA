using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas;
using System.Data.OleDb;
using System.Data;



namespace Interfaces.Parsers
{
    class DeudorExcelParser
    {
        private string getColumnValue(Property propiedad, System.Data.DataTable excel, int rCnt)
        {

            string input = null;
            //input = (propiedad.col != null ? excel.Read(range, rCnt, Int32.Parse(propiedad.col)) : "");
            input = (propiedad.col != null ? excel.Rows[rCnt][Int32.Parse(propiedad.col) - 1].ToString() : "");
            return input;
        }

        public string getColumnValue(int cCnt, System.Data.DataTable excel, int rCnt)
        {

            string input = null;

            input = excel.Rows[rCnt][cCnt - 1].ToString();
            //            input = (excel.Read(range, rCnt, cCnt));
            return input;
        }

        public Dictionary<string, List<DeudorDTO>> parse(string fileFullName)
        {

            Dictionary<string, List<DeudorDTO>> mapResultado = new Dictionary<string, List<DeudorDTO>>();

            DeudorDTO deudorDTO = null;
            List<DeudorDTO> listaDeudoresDTO = new List<DeudorDTO>();
            List<DeudorDTO> listaDeudoresErrorDTO = new List<DeudorDTO>();
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileFullName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\""); // este va OK

                con.Open();
                System.Data.DataTable metaDataTable = null;
                metaDataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = null;
                if (metaDataTable.Rows.Count >= 1 && metaDataTable.Rows[0].ItemArray.Length > 3)
                {
                    if (metaDataTable.Rows[0][3].ToString().Trim().Equals("TABLE"))
                    {
                        sheetName = metaDataTable.Rows[0][2].ToString().Trim().Replace("$", "").Replace("'", "");
                    }
                }


                OleDbDataAdapter da = new OleDbDataAdapter("select * from [Deudores$]", con);

                System.Data.DataTable dtExcel = new System.Data.DataTable();
                try
                {
                    da.Fill(dtExcel);
                }
                catch (Exception ex)
                {
                    da = new OleDbDataAdapter("select * from [" + sheetName + "$]", con);
                    da.Fill(dtExcel);
                }

                //System.Collections.IEnumerator enumRows = hoja.QueryTables.GetEnumerator();


                long row = 0;
                string input,inputCodigo, inputRazonSocial;
                int rCnt = 0;

                StringBuilder _inputParameters=new StringBuilder(); 

                for (rCnt = (0); rCnt < dtExcel.Rows.Count; rCnt++)
                {

                                       
                        deudorDTO = new DeudorDTO();
                        int i = 1;

                        input = getColumnValue(i++, dtExcel, rCnt, "cliente");

                        if (!string.IsNullOrEmpty(input))
                        { 
                        
                        

                        // Alfanumérico del cliente
                        //input = getColumnValue(i++, dtExcel, rCnt);
                        input = getColumnValue(i++, dtExcel, rCnt,"razon social");
                        deudorDTO.nombre = input;
                        if (string.IsNullOrEmpty(input))_inputParameters.Append("(*)No se encontro la columna razon social; ");
                        
                        
                    try
                    {


                        
                        // Alfanumérico del cliente
                        //input = getColumnValue(i++, dtExcel, rCnt);
                        input = getColumnValue(i++, dtExcel, rCnt,"alfanumero");
                        deudorDTO.alfaNumericoCliente = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("(*)No se encontro la columna alfanumero; ");

                        
                        deudorDTO.apellido = string.Empty;

                        // Cuit
                        input = getColumnValue(i++, dtExcel, rCnt,"cuit");
                        deudorDTO.cuit = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("no se encontro la columna cuit; ");

                        // Domicilio calle
                        input = getColumnValue(i++, dtExcel, rCnt,"domicilio");
                        deudorDTO.domicilioCalle = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("(*)No se encontro la columna domicilio; ");

                        // Domicilio altura
                        input = getColumnValue(i++, dtExcel, rCnt,"altura");
                        deudorDTO.domicilioAltura = (string.IsNullOrEmpty(input)?0: int.Parse(getColumnValue(i++, dtExcel, rCnt,"altura")));
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("(*)No se encontro la columna altura; ");

                        // Domicilio piso
                        input = getColumnValue(i++, dtExcel, rCnt, "piso");
                        if (!string.IsNullOrEmpty(input))
                        {
                            try
                            {
                                if (input.Length > 0)
                                {
                                    deudorDTO.piso = Int32.Parse(input);
                                }
                            }
                            catch (Exception)
                            {

                                _inputParameters.Append("piso no tiene un formato valido; ");
                            }
                           
                            

                        }
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("No se encontro la columna piso; ");

                        // Domicilio depto
                        input = getColumnValue(i++, dtExcel, rCnt, "depto");
                        deudorDTO.depto = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("No se encontro la columna depto; ");

                        // Localidad
                        input = getColumnValue(i++, dtExcel, rCnt, "id localidad");
                        deudorDTO.localidad = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("(*)No se encontro la columna id localidad; ");

                        // Partido
                        input = getColumnValue(i++, dtExcel, rCnt, "id partido");
                        deudorDTO.departamento = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("(*)No se encontro la columna id partido; ");

                        // Provincia
                        input = getColumnValue(i++, dtExcel, rCnt, "id provincia");
                        deudorDTO.provincia = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("(*)No se encontro la columna id provincia; ");

                        // CP
                        input = getColumnValue(i++, dtExcel, rCnt, "cp");
                        deudorDTO.cp = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("No se encontro la columna cp; ");

                        // Teléfono
                        input = getColumnValue(i++, dtExcel, rCnt, "telefono");
                        deudorDTO.telefono = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("(*)No se encontro la columna telefono; ");

                        // Teléfono Aux
                        input = getColumnValue(i++, dtExcel, rCnt, "telefono auxiliar");
                        deudorDTO.telefonoAuxiliar = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("No se encontro la columna telefono auxiliar; ");

                        // Fax
                        input = getColumnValue(i++, dtExcel, rCnt, "fax");
                        deudorDTO.telefonoFax = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("No se encontro la columna fax; ");

                        // 	E-mail
                        input = getColumnValue(i++, dtExcel, rCnt, "email");
                        deudorDTO.emails = input;
                        if (string.IsNullOrEmpty(input)) _inputParameters.Append("No se encontro la columna email; ");

                        // Anticipo de Gestión
                        input = getColumnValue(i++, dtExcel, rCnt, "anticipo gestion");
                        if (string.IsNullOrEmpty(input))
                        {
                            input = "0";
                        }
                        deudorDTO.anticipoGestion = short.Parse(input);
                        if (input.Equals("0")) _inputParameters.Append("No se encontro la columna anticipo gestion; ");


                        //// Longitud
                        //input = getColumnValue(i++, dtExcel, rCnt);
                        //if (input.Length > 0)
                        //{
                        //    deudorDTO.longitud = long.Parse(input);
                        //}

                        //// Latitud
                        //input = getColumnValue(i++, dtExcel, rCnt);
                        //if (input.Length > 0)
                        //{
                        //    deudorDTO.latitud = long.Parse(input);
                        //}
                        if (_inputParameters.Length > 0)
                        {
                            if (_inputParameters.ToString().Contains("(*)"))
                            {
                                throw new Exception(_inputParameters.ToString());
                            }
                            else
                            {

                                deudorDTO.error = _inputParameters.ToString();
                            }
                        }

                        listaDeudoresDTO.Add(deudorDTO);

                        _inputParameters.Length=0;
                    }
                    catch (Exception e)
                    {
                        deudorDTO.error = "Se han encontrado errores. Las columnas precedidas por (*) son obligatorias y deben ser cargadas. " + e.Message;
                        listaDeudoresErrorDTO.Add(deudorDTO);
                        _inputParameters.Length = 0;
                    }
                }
                }


                mapResultado.Add("listaDeudoresDTO", listaDeudoresDTO);
                mapResultado.Add("listaDeudoresErrorDTO", listaDeudoresErrorDTO);

                return mapResultado;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw e;

            }

            return null;
        }



        public string getColumnValue(int cCnt, System.Data.DataTable excel, int rCnt, string headerName)
        {

            string input = null;
            try
            {
                input = excel.Rows[rCnt][getColumnPositionByHeaderName(excel, headerName) - 1].ToString();
            }
            catch (Exception)
            {
                
            }
            
            //            input = (excel.Read(range, rCnt, cCnt));
            return input;
        }

        private int getColumnPositionByHeaderName(DataTable  dtExcel,string headerName)
        { 
        
        
            int position = 0;

            foreach (DataColumn  item in dtExcel.Columns)
            {
                position++;
                if (item.ColumnName.ToLower() == headerName.ToLower())
                {
                    return position;
                }
            }

            return -1;
        
        
        
        }
    }
}
