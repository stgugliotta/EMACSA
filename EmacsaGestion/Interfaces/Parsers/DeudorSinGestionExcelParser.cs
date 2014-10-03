using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas;
using Common.DataContracts;
using System.Data.OleDb;
using System.Data;



namespace Interfaces.Parsers
{
    class DeudorSinGestionExcelParser
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
            System.Data.DataColumn column = new System.Data.DataColumn();
            string input = null;
            //excel.Columns[cCnt - 1].DataType = typeof(System.String);
            input = excel.Rows[rCnt][cCnt - 1].ToString();
            //            input = (excel.Read(range, rCnt, cCnt));
            return input;
        }

        public Dictionary<string, List<ItemHojaDSGDataContracts>> parse(string fileFullName)
        {

            Dictionary<string, List<ItemHojaDSGDataContracts>> mapResultado = new Dictionary<string, List<ItemHojaDSGDataContracts>>();

            ItemHojaDSGDataContracts deudorDTO = null;
            List<ItemHojaDSGDataContracts> listaDeudoresDTO = new List<ItemHojaDSGDataContracts>();
            List<ItemHojaDSGDataContracts> listaDeudoresErrorDTO = new List<ItemHojaDSGDataContracts>();
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

                System.Data.DataTable dtExcelCloned = dtExcel.Clone();
                foreach (DataColumn column in dtExcelCloned.Columns)
                {
                    column.DataType = typeof(System.String);
                }

                foreach (DataRow dataRow in dtExcel.Rows)
                {
                    dtExcelCloned.ImportRow(dataRow);
                }



                //System.Collections.IEnumerator enumRows = hoja.QueryTables.GetEnumerator();


                long row = 0;
                string input;
                int rCnt = 0;
                
                for (rCnt = (0); rCnt < dtExcelCloned.Rows.Count; rCnt++)
                {

                    try
                    {
                        deudorDTO = new ItemHojaDSGDataContracts();
                        int i = 1;

                        // idCliente
                        input = getColumnValue(i++, dtExcelCloned, rCnt);
                        deudorDTO.IdCliente = decimal.Parse(input);


                        // idDeudor
                        input = getColumnValue(i++, dtExcelCloned, rCnt);
                        deudorDTO.IdDeudor = input;

                        

                        // Razon Social
                        input = getColumnValue(i++, dtExcelCloned, rCnt);
                        deudorDTO.DeudorRazonSocial = input; 

                        // Domicilio
                        input = getColumnValue(i++, dtExcelCloned, rCnt);
                        deudorDTO.DeudorDomicilio = input;

                        // Localidad
                        input = getColumnValue(i++, dtExcelCloned, rCnt);
                        deudorDTO.DeudorLocalidad = input;

                        // Dia de pago
                        input = getColumnValue(i++, dtExcelCloned, rCnt);
                        deudorDTO.DeudorDia = input;

                        // Horario de pago
                        input = getColumnValue(i++, dtExcelCloned, rCnt);
                        deudorDTO.DeudorHorario = input;

                        // Observaciones
                        input = getColumnValue(i++, dtExcelCloned, rCnt);
                        deudorDTO.Observaciones = input;

                        listaDeudoresDTO.Add(deudorDTO);
                    }
                    catch (Exception e)
                    {
                        deudorDTO.error = e.Message;
                        listaDeudoresErrorDTO.Add(deudorDTO);
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
    }
}
