using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Gobbi.CoreServices.Security.Principal;
using Herramientas;
using Interfaces.Parsers;
using Gobbi.services;
using Gobbi.CoreServices.ExceptionHandling;
using Common.DataContracts;
using Common.Interfaces;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using GoogleMaps;


namespace Interfaces
{
    public class ImportadorInterfaces
    {



        private static bool validar(ClienteInterfaz cliente, String interfaz, String idCliente, String contentType)
        {

            return (cliente.contentType.Contains(contentType));

        }

        public static List<ImportacionFacturaDataContracts> mostrarResultados()
        {
            IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

            return interfazFacturaService.getProcessResultInterfazFacturas();
        }

        public static List<ImportacionFacturaDataContracts> mostrarResultadosPorFecha(DateTime fecha)
        {
            IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

            return interfazFacturaService.getProcessResultInterfazFacturasPorFecha(fecha);
        }

        public static List<ImportacionFacturaDataContracts> mostrarResultadosPorFechaPreview(DateTime fecha)
        {
            IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

            return interfazFacturaService.getProcessResultInterfazFacturasPorFechaPreview(fecha);
        }

        public static List<ImportacionFacturaDataContracts> mostrarResultadosPorFechaPreview(int idCliente, DateTime fecha)
        {
            IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

            return interfazFacturaService.getProcessResultInterfazFacturasPorFechaPreview(idCliente, fecha);
        }



        public static List<ImportacionFacturaDataContracts> reprocesar(String idCliente, string user)
        {

            IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");


            List<ImportacionFacturaDataContracts> resultado = interfazFacturaService.ProcessInterfazFacturasByCliente(int.Parse(idCliente), user);

            return resultado;
        }


        public static void importarDeudores(String idCliente,
                                    String fileName, byte[] archivo)
        {

            try
            {

                String pathTmpFile = IOUtils.createTemporalFile(archivo, fileName);


                DeudorExcelParser parser = new DeudorExcelParser();

                List<DeudorDTO> deudoresDTO = null;
                Dictionary<string, List<DeudorDTO>> mapDeudoresParsed = parser.parse(pathTmpFile);
                List<DeudorDTO> deudoresDTOConError = null;
                mapDeudoresParsed.TryGetValue("listaDeudoresErrorDTO", out deudoresDTOConError);
                mapDeudoresParsed.TryGetValue("listaDeudoresDTO", out deudoresDTO);

                IDeudorService deudorServices = ServiceClient<IDeudorService>.GetService("DeudorService");
                IDomicilioDeudorService domiciliodeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");
                IClienteDeudorService clienteDeudorService = ServiceClient<IClienteDeudorService>.GetService("ClienteDeudorService");

                if (deudoresDTOConError.Count == 0)
                {
                    foreach (DeudorDTO deudorDTO in deudoresDTO)
                    {
                        DeudorDataContracts d = new DeudorDataContracts();
                        try
                        {

                            
                            //if (d == null)
                            //{
                                // Inserto el nuevo deudor
                                d = new DeudorDataContracts();
                                d.AlfaNumDelCliente = deudorDTO.alfaNumericoCliente;
                                d.AnticipoGestion = deudorDTO.anticipoGestion;
                                d.Nombre = deudorDTO.nombre;
                                d.Apellido = deudorDTO.apellido;
                                d.Cuit = deudorDTO.cuit;
                                d.Email = deudorDTO.emails;
                                d.Telefono = deudorDTO.telefono;
                                d.Telefono_Aux = deudorDTO.telefonoAuxiliar;
                                d.Fax = deudorDTO.telefonoFax;
                                d.Domicilio = deudorDTO.domicilioCalle + " " + (string.IsNullOrEmpty(deudorDTO.domicilioAltura.ToString()) ? "0" : deudorDTO.domicilioAltura.ToString());
                                d.Cp = deudorDTO.cp;

                              
                                // Inserto el domicilio del deudor.
                                DomicilioDeudorDataContracts domiDeudor = new DomicilioDeudorDataContracts();
                                
                                domiDeudor.IdLocalidad = Int32.Parse(deudorDTO.localidad);
                                domiDeudor.GmLat = deudorDTO.latitud;
                                domiDeudor.GmLng = deudorDTO.longitud;
                                domiDeudor.IdProvincia = Int32.Parse(deudorDTO.provincia);
                                domiDeudor.IdDepartamento = Int32.Parse(deudorDTO.departamento);
                                domiDeudor.IdPais = 1; // Argentina por el momento;
                                domiDeudor.CalleNombre = deudorDTO.domicilioCalle;
                                domiDeudor.CalleAltura = deudorDTO.domicilioAltura;
                                domiDeudor.Cp = deudorDTO.cp;
                                domiDeudor.Piso = deudorDTO.piso;
                                domiDeudor.Depto = deudorDTO.depto;

                             
                                int idDeudor= deudorServices.Insert2(d);
                                if (idDeudor == -1)
                                {
                                    throw new Exception("El deudor ya exista en la base de datos.");
                                }
                                //d.IdDeudor = deudorServices.GetLastId().IdDeudor; // Recupero el nuevo iddeudor
                                d.IdDeudor = idDeudor;
                                domiDeudor.IdDeudor = d.IdDeudor;


                                fillGmapsData(domiDeudor);

                                
                                domiciliodeudorService.InsertNuevo(domiDeudor);


                           // }


                            // Como el deudor existe, creo la relación para este cliente.
                            ClienteDeudorDataContracts clienteDeudorDTO = new ClienteDeudorDataContracts();
                            clienteDeudorDTO.Alfanumdelcliente = deudorDTO.alfaNumericoCliente;
                            clienteDeudorDTO.IdCliente = Int32.Parse(idCliente);
                            //clienteDeudorDTO.IdCliente = deudorDTO.idCliente;
                            clienteDeudorDTO.IdDeudor = d.IdDeudor;
                            clienteDeudorService.Insert(clienteDeudorDTO);
                        }
                        catch (Exception e)
                        {
                            
                            deudorDTO.error = e.Message;
                            deudoresDTOConError.Add(deudorDTO);
                        }

                    }
                }
                if (deudoresDTOConError.Count > 0)
                {
                    writeErrors(deudoresDTOConError);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void fillGmapsData(DomicilioDeudorDataContracts domiDeudor)
        {
            IPaisService paisService = ServiceClient<IPaisService>.GetService("PaisService");
            IProvinciaService provinciaService = ServiceClient<IProvinciaService>.GetService("ProvinciaService");
            ILocalidadService localidadService = ServiceClient<ILocalidadService>.GetService("LocalidadService");

            string localidad = (localidadService.GetLocalidad(domiDeudor.IdLocalidad) == null ? "" : localidadService.GetLocalidad(domiDeudor.IdLocalidad).Nombre);
            string provincia = (provinciaService.GetProvincia(domiDeudor.IdProvincia) == null ? "" : provinciaService.GetProvincia(domiDeudor.IdProvincia).Nombre);
            string pais = (paisService.GetPais(domiDeudor.IdPais) == null ? "" : paisService.GetPais(domiDeudor.IdPais).Nombre);

            GoogleMapsHelper gmHelper = new GoogleMapsHelper();

            if (!gmHelper.isInternetConnectionAvailable())
            {

                return;
            }

            GeocodeResponse geoResponse = gmHelper.getGeocodeResponse(domiDeudor.CalleNombre + "+" + domiDeudor.CalleAltura + "," + localidad + "," + provincia + "," + pais);

            if (geoResponse == null)
            {
                return;
            }
            try
            {
                domiDeudor.GmFormattedAddress = geoResponse.results[0].formatted_address;
                domiDeudor.GmLat = geoResponse.results[0].geometry.location.lat;
                domiDeudor.GmLng = geoResponse.results[0].geometry.location.lng;
            }
            catch (Exception ex) {
                Console.Write(ex);
            }

        }


        private static void writeErrors(List<DeudorDTO> deudoresDTOConError)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", "ImportDeudores_Error.xls"));
            HttpContext.Current.Response.ContentType = "application/ms-excel";


            Table table = new Table();
            List<TableCell> celdasB = new List<TableCell>();
            TableRow tr = null;
            TableCell td = null;

            TableHeaderRow trh = new TableHeaderRow();
            TableHeaderCell tdh;

            tdh = new TableHeaderCell();
            tdh.Text = "Alfanumero";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Razón Social";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Cuit";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Domicilio";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Altura";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Piso";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Depto";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Id Localidad";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Id Partido";
            trh.Cells.Add(tdh);


            //tdh = new TableHeaderCell();
            //tdh.Text = "Id Provincia";
            //trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Cp";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Telefono";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Telefono Auxiliar";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Fax";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Email";
            trh.Cells.Add(tdh);

            tdh = new TableHeaderCell();
            tdh.Text = "Anticipo Gestion";
            trh.Cells.Add(tdh);

          
            table.Rows.Add(trh);

            foreach (DeudorDTO derr in deudoresDTOConError)
            {
                tr = new TableRow();


                td = new TableCell();
                td.Text = derr.alfaNumericoCliente;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.nombre;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.cuit;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.domicilioCalle;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.domicilioAltura.ToString();
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.piso.ToString();
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.depto;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.localidad;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.departamento;
                tr.Cells.Add(td);

                //td = new TableCell();
                //td.Text = derr.provincia;
                //tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.cp;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.telefono;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.telefonoAuxiliar;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.telefonoFax;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.emails;
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = derr.anticipoGestion.ToString();
                tr.Cells.Add(td);


                td = new TableCell();
                td.Text = derr.error;
                tr.Cells.Add(td);

                table.Rows.Add(tr);

            }

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            table.RenderControl(htw);

            //  render the htmlwriter into the response
            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.End();

        }



        public static void importarDeudoresSinGestion(String idCliente, int nroHoja,
                             String fileName, byte[] archivo)
        {

            try
            {

                if (fileName == null || !fileName.ToLower().EndsWith(".xls")) 
                {
                    throw new Exception("Está intentando importar un archivo cuyo contenido no coincide con los permitidos (xls).");
                }

                String pathTmpFile = IOUtils.createTemporalFile(archivo, fileName);


                DeudorSinGestionExcelParser parser = new DeudorSinGestionExcelParser();

                List<ItemHojaDSGDataContracts> deudoresDTO = null;
                Dictionary<string, List<ItemHojaDSGDataContracts>> mapDeudoresParsed = parser.parse(pathTmpFile);
                List<ItemHojaDSGDataContracts> deudoresDTOConError = null;
                mapDeudoresParsed.TryGetValue("listaDeudoresErrorDTO", out deudoresDTOConError);
                mapDeudoresParsed.TryGetValue("listaDeudoresDTO", out deudoresDTO);

                IItemHojaDSGService itemHojaDSGServices = ServiceClient<IItemHojaDSGService>.GetService("ItemHojaDSGService");

                IDomicilioDeudorService domiciliodeudorService = ServiceClient<IDomicilioDeudorService>.GetService("DomicilioDeudorService");

                IDeudorService deudorService = ServiceClient<IDeudorService>.GetService("DeudorService");
                ICobradorService cobradorService = ServiceClient<ICobradorService>.GetService("CobradorService");
                DeudorDataContracts ddc1 = null;
                foreach (ItemHojaDSGDataContracts deudorDTO in deudoresDTO)
                {
                    try
                    {
                        //ddc = deudorService.GetAllDeudorsPorAlfaNum(deudorDTO.IdDeudor, deudorDTO.IdCliente)[0];
                        ddc1 = deudorService.GetAllDeudorsPorAlfaNumAndIdCliente(deudorDTO.IdDeudor, Decimal.ToInt32( deudorDTO.IdCliente))[0];
                        deudorDTO.IdHoja = nroHoja;
                        deudorDTO.IdCliente = deudorDTO.IdCliente;
                        
                        //deudorDTO.AlfaNumDelCliente = ddc.AlfaNumDelCliente;
                        //deudorDTO.DeudorDomicilio = ddc.Domicilio_Deudor.CalleNombre + " " + ddc.Domicilio_Deudor.CalleAltura;//deudorDTO.DeudorDomicilio;
                        //deudorDTO.DeudorLocalidad = ddc.Localidad; //deudorDTO.DeudorLocalidad;

                        //deudorDTO.Cobrador = cobradorService.GetCobradorByDomicilio()
                        itemHojaDSGServices.Insert(deudorDTO);
                    }
                    catch (Exception e)
                    {
                        deudorDTO.error = e.Message;
                        deudoresDTOConError.Add(deudorDTO);
                    }

                }
                if (deudoresDTOConError.Count > 0)
                {
                    writeErrorsDSG(deudoresDTOConError);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        private static void writeErrorsDSG(List<ItemHojaDSGDataContracts> deudoresDTOConError)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader(
                    "content-disposition", string.Format("attachment; filename={0}", "ImportDeudoresSinGestion_Error.xls"));
                HttpContext.Current.Response.ContentType = "application/ms-excel";


                Table table = new Table();
                List<TableCell> celdasB = new List<TableCell>();
                TableRow tr = null;
                TableCell td = null;

                TableHeaderRow trh = new TableHeaderRow();

                TableHeaderCell tdh = new TableHeaderCell();
                tdh.Text = "Codigo";
                trh.Cells.Add(tdh);

                tdh = new TableHeaderCell();
                tdh.Text = "Razon Social";
                trh.Cells.Add(tdh);

                tdh = new TableHeaderCell();
                tdh.Text = "Domicilio";
                trh.Cells.Add(tdh);

                tdh = new TableHeaderCell();
                tdh.Text = "Localidad";
                trh.Cells.Add(tdh);

                tdh = new TableHeaderCell();
                tdh.Text = "Día de Pago";
                trh.Cells.Add(tdh);

                tdh = new TableHeaderCell();
                tdh.Text = "Horario";
                trh.Cells.Add(tdh);

                tdh = new TableHeaderCell();
                tdh.Text = "Observaciones";
                trh.Cells.Add(tdh);

                tdh = new TableHeaderCell();
                tdh.Text = "ERROR";
                trh.Cells.Add(tdh);


                table.Rows.Add(trh);

                foreach (ItemHojaDSGDataContracts derr in deudoresDTOConError)
                {
                    tr = new TableRow();

                    td = new TableCell();
                    td.Text = derr.IdDeudor;
                    tr.Cells.Add(td);

                    td = new TableCell();
                    td.Text = derr.DeudorRazonSocial;
                    tr.Cells.Add(td);

                    td = new TableCell();
                    td.Text = derr.DeudorDomicilio;
                    tr.Cells.Add(td);

                    td = new TableCell();
                    td.Text = derr.DeudorLocalidad;
                    tr.Cells.Add(td);

                    td = new TableCell();
                    td.Text = derr.DeudorDia;
                    tr.Cells.Add(td);

                    td = new TableCell();
                    td.Text = derr.DeudorHorario;
                    tr.Cells.Add(td);

                    td = new TableCell();
                    td.Text = derr.Observaciones;
                    tr.Cells.Add(td);

                    td = new TableCell();
                    td.Text = derr.error;
                    tr.Cells.Add(td);

                    table.Rows.Add(tr);

                }

                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                // 29/07/2013 Ver work around http://support.microsoft.com/kb/312629/en-us
                HttpContext.Current.Response.End();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
            }

        }


        public static List<ImportacionFacturaDataContracts> importar(String interfaz, String idCliente, String contentType,
                                    String fileName, byte[] archivo)
        {

            ConfigurationInterfaz config = ConfigurationLoader.loadConfiguration();
            ClienteInterfaz cliente = null;

            try
            {
                cliente = searchClienteConfiguration(config, idCliente);
            }
            catch (Exception ex) {
                decimal decIdCliente = Decimal.Parse(idCliente);
                cliente = searchClienteConfiguration(config, "default");
                if (decIdCliente < 0)
                {
                    cliente.id =  (decIdCliente * -1).ToString(); // lo pasamos a positivo
                }
                else
                {
                    cliente.id = idCliente;
                }
            }

            if (!validar(cliente, interfaz, idCliente, contentType))
            {
                throw new Exception("Está intentando importar un archivo cuyo contenido (" + contentType + ") no coincide con los permitidos (" + cliente.contentType + ") para el cliente ");
            }

            try
            {

                String pathTmpFile = IOUtils.createTemporalFile(archivo, fileName);


                Parser parser = FacturaParserBuilder.getInstance().build(cliente.parser);

                List<FacturaDTO> facturasDTO = parser.parse(pathTmpFile, cliente);

                IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

                short j = 0;
                DateTime fecProceso = System.DateTime.Now;
                interfazFacturaService.DeleteLastImport(int.Parse(cliente.id));
                foreach (FacturaDTO facturaDTO in facturasDTO)
                {


                    InterfazFacturaDataContracts ifacturaDataContract = new InterfazFacturaDataContracts();
                    ifacturaDataContract.CantidadP = facturaDTO.cantidadP;
                    ifacturaDataContract.Emision = facturaDTO.emision;
                    ifacturaDataContract.Estado = facturaDTO.estado;
                    ifacturaDataContract.FechaEmision = facturaDTO.fechaEmision;
                    ifacturaDataContract.FechaProceso = fecProceso;
                    ifacturaDataContract.FechaVencimiento = facturaDTO.fechaVencimiento;
                    ifacturaDataContract.IdCliente = facturaDTO.idCliente;
                    ifacturaDataContract.IdDeudor = facturaDTO.idDeudor;
                    ifacturaDataContract.IdMoneda = facturaDTO.idMoneda;
                    ifacturaDataContract.IdTipoComprobante = facturaDTO.idTipoComprobante;
                    ifacturaDataContract.Importe = facturaDTO.importe;
                    ifacturaDataContract.Saldo = facturaDTO.saldo;
                    ifacturaDataContract.Letra = facturaDTO.letra;
                    ifacturaDataContract.Linea = j++;
                    ifacturaDataContract.NroComprobante = facturaDTO.nroComprobante;
                    ifacturaDataContract.NumeroPag = 0; // TODO: Por el momento porque se desconoce significado.
                    ifacturaDataContract.Observaciones = facturaDTO.observaciones;


                    interfazFacturaService.Insert(ifacturaDataContract);

                }

                //List<ImportacionFacturaDataContracts> resultado = interfazFacturaService.ProcessInterfazFacturasByCliente(int.Parse(idCliente), "emacsa_user");
                List<ImportacionFacturaDataContracts> resultado = interfazFacturaService.ProcessInterfazFacturasByCliente(int.Parse(cliente.id), "emacsa_user");

                System.Console.Write(resultado);

                return resultado;
                //return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public static List<ImportacionFacturaDataContracts> importarPreview(String interfaz, String idCliente, String contentType,
                            String fileName, byte[] archivo)
        {

            ConfigurationInterfaz config = ConfigurationLoader.loadConfiguration();
            ClienteInterfaz cliente = null;

            try
            {
                cliente = searchClienteConfiguration(config, idCliente);
            }
            catch (Exception ex)
            {
                decimal decIdCliente = Decimal.Parse(idCliente);
                cliente = searchClienteConfiguration(config, "default");
                if (decIdCliente < 0)
                {
                    cliente.id = (decIdCliente * -1).ToString(); // lo pasamos a positivo
                }
                else
                {
                    cliente.id = idCliente;
                }
            }

            if (!validar(cliente, interfaz, idCliente, contentType))
            {
                throw new Exception("Está intentando importar un archivo cuyo contenido (" + contentType + ") no coincide con los permitidos (" + cliente.contentType + ") para el cliente ");
            }

            try
            {

                String pathTmpFile = IOUtils.createTemporalFile(archivo, fileName);


                Parser parser = FacturaParserBuilder.getInstance().build(cliente.parser);

                List<FacturaDTO> facturasDTO = parser.parse(pathTmpFile, cliente);

                IInterfazFacturaService interfazFacturaService = ServiceClient<IInterfazFacturaService>.GetService("InterfazFacturaService");

                short j = 0;
                DateTime fecProceso = System.DateTime.Now;

                interfazFacturaService.TruncateTablePreview();
                interfazFacturaService.DeleteLastImportPreview(int.Parse(cliente.id));

                foreach (FacturaDTO facturaDTO in facturasDTO)
                {


                    InterfazFacturaDataContracts ifacturaDataContract = new InterfazFacturaDataContracts();
                    ifacturaDataContract.CantidadP = facturaDTO.cantidadP;
                    ifacturaDataContract.Emision = facturaDTO.emision;
                    ifacturaDataContract.Estado = facturaDTO.estado;
                    ifacturaDataContract.FechaEmision = facturaDTO.fechaEmision;
                    ifacturaDataContract.FechaProceso = fecProceso;
                    ifacturaDataContract.FechaVencimiento = facturaDTO.fechaVencimiento;
                    ifacturaDataContract.IdCliente = facturaDTO.idCliente;
                    ifacturaDataContract.IdDeudor = facturaDTO.idDeudor;
                    ifacturaDataContract.IdMoneda = facturaDTO.idMoneda;
                    ifacturaDataContract.IdTipoComprobante = facturaDTO.idTipoComprobante;
                    ifacturaDataContract.Importe = facturaDTO.importe;
                    ifacturaDataContract.Saldo = facturaDTO.saldo;
                    ifacturaDataContract.Letra = facturaDTO.letra;
                    ifacturaDataContract.Linea = j++;
                    ifacturaDataContract.NroComprobante = facturaDTO.nroComprobante;
                    ifacturaDataContract.NumeroPag = 0; // TODO: Por el momento porque se desconoce significado.
                    ifacturaDataContract.Observaciones = facturaDTO.observaciones;


                    interfazFacturaService.InsertPreview(ifacturaDataContract);

                }

                //List<ImportacionFacturaDataContracts> resultado = interfazFacturaService.ProcessInterfazFacturasByCliente(int.Parse(idCliente), "emacsa_user");
                List<ImportacionFacturaDataContracts> resultado = interfazFacturaService.ProcessInterfazFacturasByClientePreview(int.Parse(cliente.id), "emacsa_user");

                System.Console.Write(resultado);

                return resultado;
                //return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }


        private static ClienteInterfaz searchClienteConfiguration(ConfigurationInterfaz config, String idCliente)
        {

            foreach (FacturaInterfaz fac in config.interfacesFactura)
            {

                foreach (ClienteInterfaz cli in fac.clientes)
                {
                    if (cli.id.ToString().Equals(idCliente))
                    {
                        return cli;
                    }
                }
            }

            throw new Exception("No se pudo encontrar el cliente dentro de la configuración de interfaces del sistema.");
        }
    }


}
