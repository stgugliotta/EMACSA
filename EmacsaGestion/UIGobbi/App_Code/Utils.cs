using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using Gobbi.CoreServices.Caching;
using Gobbi.CoreServices.Caching.CacheManagers;
using Gobbi.services;
using Gobbi.CoreServices.Security.Principal;
using Common.DataContracts;
using Common.Interfaces;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;

/// <summary>
/// Summary DataTableUtils
/// Utilizado para traer registro distintos de un dataTable
/// </summary>
public static class Utils
{
//    #region Grilla Genericas
//    public static DataTable SelectDistinct(DataTable SourceTable, params string[] FieldNames)
//    {
//        object[] lastValues;
//        DataTable newTable;
//        DataRow[] orderedRows;

//        if (FieldNames == null || FieldNames.Length == 0)
//        {
//            throw new ArgumentNullException("FieldNames");
//        }

//        lastValues = new object[FieldNames.Length];
//        newTable = new DataTable();

//        foreach (string fieldName in FieldNames)
//        {
//            newTable.Columns.Add(fieldName, SourceTable.Columns[fieldName].DataType);
//        }

//        orderedRows = SourceTable.Select(string.Empty, string.Join(", ", FieldNames));

//        foreach (DataRow row in orderedRows)
//        {
//            if (!FieldValuesAreEqual(lastValues, row, FieldNames))
//            {
//                newTable.Rows.Add(CreateRowClone(row, newTable.NewRow(), FieldNames));

//                SetLastValues(lastValues, row, FieldNames);
//            }
//        }

//        return newTable;
//    }

//    private static bool FieldValuesAreEqual(object[] lastValues, DataRow currentRow, string[] fieldNames)
//    {
//        bool areEqual = true;

//        for (int i = 0; i < fieldNames.Length; i++)
//        {
//            if (lastValues[i] == null || !lastValues[i].Equals(currentRow[fieldNames[i]]))
//            {
//                areEqual = false;
//                break;
//            }
//        }

//        return areEqual;
//    }

//    private static DataRow CreateRowClone(DataRow sourceRow, DataRow newRow, string[] fieldNames)
//    {
//        foreach (string field in fieldNames)
//        {
//            newRow[field] = sourceRow[field];
//        }

//        return newRow;
//    }

//    private static void SetLastValues(object[] lastValues, DataRow sourceRow, string[] fieldNames)
//    {
//        for (int i = 0; i < fieldNames.Length; i++)
//        {
//            lastValues[i] = sourceRow[fieldNames[i]];
//        }
//    }
//    #endregion
//    #region llenar Objetos Cache
   
//    public static DataTable GetClienteAcuerdoServicio(long idCaso)
//    {
//        DataTable dataTable = new DataTable();
//        DataColumn[] keys = new DataColumn[1];
//        ICasoClienteService casocliente = ServiceClient<ICasoClienteService>.GetService("CasoClienteService");

//        List<CasoClienteDataContracts> clientes = casocliente.GetAllCasoClientes(idCaso);

//        DataColumn idServicio = new DataColumn("idServicio", typeof(long));
//        keys[0] = idServicio;
//        dataTable.Columns.Add(idServicio);
//        dataTable.PrimaryKey = keys;


//        dataTable.Columns.Add(new DataColumn("idCaso", typeof(long)));
//        dataTable.Columns.Add(new DataColumn("idEstado", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("IdCliente", typeof(long)));
//        dataTable.Columns.Add(new DataColumn("CodCliente", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("DenominacionCliente", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("AgenciaGestionaria", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("CategoriaCliente", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("ClienteExcluir", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("AcuerdoExcluir", typeof(short)));
//        dataTable.Columns.Add(new DataColumn("acuerdoIco", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("servicio", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("estadoServicio", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("categoriaAbono", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("fechaBaja", typeof(DateTime)));
//        dataTable.Columns.Add(new DataColumn("nroSolicitudBaja", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("idMotivobaja", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("idUsuarioSolicBaja", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("fechaIR", typeof(DateTime)));
//        dataTable.Columns.Add(new DataColumn("nroSolicitudIR", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("idUsuarioSolicIR", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("ServicioExcluir", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("EsCargaManual", typeof(short)));



//        foreach (CasoClienteDataContracts cc in clientes)
//        {
//            foreach (CasoServicioDataContracts CS in cc.ObjCasosServicios)
//            {
//                DataRow row = dataTable.NewRow();
//                row["idCaso"] = cc.ObjCaso.IdCaso;
//                row["idEstado"] = cc.ObjCaso.ObjEstadoCasoCyQ.IdEstado;
//                row["IdCliente"] = cc.IdCliente;
//                row["CodCliente"] = cc.CodCliente;
//                row["DenominacionCliente"] = cc.DenominacionCliente;
//                row["AgenciaGestionaria"] = cc.AgenciaGestionaria;
//                row["CategoriaCliente"] = cc.CategoriaCliente;
//                row["ClienteExcluir"] = cc.Excluir;

//                row["AcuerdoExcluir"] = CS.ExcluirAcuerdo;

//                row["idServicio"] = CS.IdServicio;

//                row["acuerdoIco"] = CS.AcuerdoIco;
//                row["servicio"] = CS.Servicio;
//                row["estadoServicio"] = CS.EstadoServicio;
//                row["categoriaAbono"] = CS.CategoriaAbono;
//                row["fechaBaja"] = CS.FechaBaja;
//                row["nroSolicitudBaja"] = CS.NroSolicitudBaja;
//                row["idMotivobaja"] = CS.IdMotivobaja;
//                row["idUsuarioSolicBaja"] = CS.IdUsuarioSolicBaja;
//                row["fechaIR"] = CS.FechaIR;
//                row["nroSolicitudIR"] = CS.NroSolicitudIR;
//                row["idUsuarioSolicIR"] = CS.IdUsuarioSolicIR;
//                row["ServicioExcluir"] = CS.Excluir;
//                row["EsCargaManual"] = cc.EsCargaManual;
//                dataTable.Rows.Add(row);
//            }
//        }
//        foreach (DataRow drTmp in Utils.SelectDistinct(dataTable, new string[] { "CodCliente", "AcuerdoIco" }).Rows)
//        {
//            // Acuerdo
//            if (dataTable.Select("AcuerdoIco =" + drTmp["AcuerdoIco"].ToString() + " and  AcuerdoExcluir in (1,2) and EsCargaManual = 0").Length != dataTable.Select("AcuerdoIco =" + drTmp["AcuerdoIco"].ToString() + " and ServicioExcluir=1 and EsCargaManual = 0").Length)
//            {
//                //Recorrer todos esos registro y colocarle 2 en estado cliente y Acuerdo
//                foreach (DataRow dr in dataTable.Select("AcuerdoIco =" + drTmp["AcuerdoIco"].ToString() + " and EsCargaManual = 0"))
//                {
//                    dr["AcuerdoExcluir"] = 2;
//                    dr["ClienteExcluir"] = 2;
//                }
//            }
//            else
//            {
//                foreach (DataRow dr in dataTable.Select("AcuerdoIco =" + drTmp["AcuerdoIco"].ToString() + " and EsCargaManual = 0"))
//                {
//                    dr["AcuerdoExcluir"] = dr["ServicioExcluir"];
//                }
//            }

//            //Cliente
//            if (dataTable.Select("AcuerdoIco =" + drTmp["AcuerdoIco"].ToString() + " and (AcuerdoExcluir=1 or AcuerdoExcluir=2) and EsCargaManual = 0").Length != dataTable.Select("CodCliente =" + drTmp["CodCliente"].ToString() + " and (ClienteExcluir=1 or ClienteExcluir=2) and EsCargaManual = 0").Length)
//            {
//                foreach (DataRow dr in dataTable.Select("CodCliente =" + drTmp["CodCliente"].ToString() + " and EsCargaManual = 0"))
//                {
//                    dr["ClienteExcluir"] = 2;
//                }
//            }
//            else
//            {
//                foreach (DataRow dr in dataTable.Select("CodCliente =" + drTmp["CodCliente"].ToString() + " and EsCargaManual = 0"))
//                {
//                    dr["ClienteExcluir"] = dr["AcuerdoExcluir"];
//                }
//            }

//        }
//        return dataTable;
//    }

//   public static DataTable GetClienteAcuerdoDocumento(long idCaso)
//    {
//        DataTable dataTable = new DataTable();
//        DataTable dataTableTemp = new DataTable();
//        DataColumn[] keys = new DataColumn[1];

//        DataColumn idDocumento = new DataColumn("idDocumento", typeof(long));
//        keys[0] = idDocumento;
//        dataTable.Columns.Add(idDocumento);
//        dataTable.PrimaryKey = keys;

//        dataTable.Columns.Add(new DataColumn("idCaso", typeof(long)));
//        dataTable.Columns.Add(new DataColumn("idEstado", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("IdCliente", typeof(long)));
//        dataTable.Columns.Add(new DataColumn("CodCliente", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("DenominacionCliente", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("AgenciaGestionaria", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("acuerdoIco", typeof(string)));
//        /// Datos documentos
//        dataTable.Columns.Add(new DataColumn("tipodocid", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("tipodocString", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("NumRef", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("FechaVto", typeof(DateTime)));
//        dataTable.Columns.Add(new DataColumn("Moneda", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("ImpSaldoPesosOrig", typeof(decimal)));
//        dataTable.Columns.Add(new DataColumn("ImpSaldoPesos", typeof(decimal)));
//        dataTable.Columns.Add(new DataColumn("Imp3roTransf", typeof(decimal)));
//        dataTable.Columns.Add(new DataColumn("EstadoDocumento", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("TramDeimos", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("TramDeimosEstado", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("tasaCambio", typeof(decimal)));
//        dataTable.Columns.Add(new DataColumn("documentoExcluir", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("esCargaManual", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Sistemaorigenid", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("SistemaorigenText", typeof(string)));



//        ICasoDocumentoService casoDocumento = ServiceClient<ICasoDocumentoService>.GetService("CasoDocumentoService");

//        List<CasoDocumentoDataContracts> casoDocumentos = casoDocumento.GetAllCasoDocumentos(idCaso);

//        foreach (CasoDocumentoDataContracts cd in casoDocumentos)
//        {

//            DataRow row = dataTable.NewRow();

//            row["idCaso"] = cd.ObjCaso.IdCaso;
//            row["idEstado"] = cd.ObjCaso.ObjEstadoCasoCyQ.IdEstado;

//            row["idDocumento"] = cd.IdDocumento;
//            if (cd.ObjCliente != null)
//            {
//                row["IdCliente"] = cd.ObjCliente.IdCliente;
//                row["CodCliente"] = cd.ObjCliente.CodCliente;
//                row["DenominacionCliente"] = cd.ObjCliente.DenominacionCliente;
//                row["AgenciaGestionaria"] = cd.ObjCliente.AgenciaGestionaria;
//            }
//            row["acuerdoIco"] = cd.AcuerdoICO;

//            row["tipodocid"] = cd.ObjTipodocsistema.IdTipodocsistema;
//            row["tipodocString"] = cd.ObjTipodocsistema.Abreviatura;
//            row["NumRef"] = cd.NumRef;
//            row["FechaVto"] = cd.FechaVto;
//            row["Moneda"] = cd.Moneda;
//            row["ImpSaldoPesosOrig"] = cd.ImpSaldoPesosOrig;
//            row["ImpSaldoPesos"] = cd.ImpSaldoPesos;
//            row["Imp3roTransf"] = cd.Imp3roTransf;
//            row["EstadoDocumento"] = cd.EstadoDocumento;
//            row["TramDeimos"] = cd.TramDeimos.ToString().Trim();
//            row["TramDeimosEstado"] = cd.TramDeimosEstado.ToString().Trim();
//            row["tasaCambio"] = cd.TasaCambio;
//            row["documentoExcluir"] = cd.Excluir;
//            row["esCargaManual"] = cd.EsCargaManual;
//            row["Sistemaorigenid"] = cd.ObjSistemaorigen.IdSistemaorigen;
//            row["SistemaorigenText"] = cd.ObjTipodocsistema.Abreviatura;
//            dataTable.Rows.Add(row);
//        }
//        return dataTable;
//    }

//   public static DataTable GetMacroconceptoExcel(DataTable Macroconcepto, DataTable Documentos)
//   {
//       try
//       {
//           DataTable dataTable = new DataTable();
//           DataTable dtTmp = new DataTable();
//           DataColumn[] keys = new DataColumn[1];
//           long idDocumento = 0;
//           int cant = 0;
   
//           //Revisar si el Documento esta incluido
//           if (Macroconcepto.Select("excluir=0").Length == 0)
//           {
//               return new DataTable();
//           }
//           else
//           {
//               Macroconcepto = Macroconcepto.Select("excluir=0", "idDocumento,tipoMacroconceptoText asc").CopyToDataTable();

//               DataColumn idMacro = new DataColumn("idMacroconcepto", typeof(long));
//               keys[0] = idMacro;
//               dataTable.Columns.Add(idMacro);
//               dataTable.PrimaryKey = keys;

//               dataTable.Columns.Add(new DataColumn("idDocumento", typeof(long)));
//               dataTable.Columns.Add(new DataColumn("NumRef", typeof(string)));
//               dataTable.Columns.Add(new DataColumn("FechaVto", typeof(DateTime)));

//               // Recorrer los macroconceptos
//               dtTmp = SelectDistinct(Macroconcepto, new string[] { "id_tipoMacroconcepto", "tipoMacroconceptoText" });

//               dtTmp = dtTmp.Select("", "tipoMacroconceptoText ASC").CopyToDataTable();

//               foreach (DataRow dr in dtTmp.Rows)
//               {
//                   dataTable.Columns.Add(new DataColumn(dr["tipoMacroconceptoText"].ToString(), typeof(decimal)));
//               }
//               DataRow row = dataTable.NewRow();

//               foreach (DataRow dr in Macroconcepto.Select("", "idDocumento asc , tipoMacroconceptoText asc"))
//               {

//                   // Reviso si el documento esta incluido
//                   if (Documentos.Select("DocumentoExcluir= 0 and idDocumento =" + dr["idDocumento"].ToString()).Length > 0)
//                   {
//                       if (idDocumento != long.Parse(dr["idDocumento"].ToString()))
//                       {
//                           if (idDocumento != 0)
//                           {
//                               while (dataTable.Columns.Count > cant)
//                               {
//                                   row[cant] = 0;
//                                   cant += 1;
//                               }
//                               if (row == null)
//                               {
//                                   row = dataTable.NewRow();
//                               }
//                               dataTable.Rows.Add(row);
//                           }
//                           cant = 4;
//                           row = dataTable.NewRow();
//                           row["idMacroconcepto"] = long.Parse(dr["idMacroconcepto"].ToString());
//                           row["idDocumento"] = long.Parse(dr["idDocumento"].ToString());
//                           row["NumRef"] = dr["NumRef"].ToString();
//                           if (DateTime.Parse(dr["FechaVto"].ToString()) != DateTime.MinValue)
//                           {
//                               row["FechaVto"] = DateTime.Parse(dr["FechaVto"].ToString());
//                           }
//                           idDocumento = long.Parse(dr["idDocumento"].ToString());
//                       }
//                       if (int.Parse(dr["excluir"].ToString()) == 1)
//                       {
//                           row[cant] = 0;
//                       }
//                       else
//                       {
//                           row[cant] = decimal.Parse(dr["ValorActualizado"].ToString());
//                       }
//                       cant += 1;
//                   }
//               }
//               dataTable.Rows.Add(row);

//               return dataTable;
//           }
//       }
//       catch 
//       {
//           return new DataTable();
//       }
//   }
   
//   public static DataTable GetDocumentoMacroconcepto(long idCaso)
//    {
//        DataTable dataTable = new DataTable();
//        DataTable dataTableTemp = new DataTable();
//        DataColumn[] keys = new DataColumn[2];

//        DataColumn idMacroconcepto = new DataColumn("idMacroconcepto", typeof(long));
//        DataColumn id_tipoMacroconcepto = new DataColumn("id_tipoMacroconcepto", typeof(int));
//        keys[0] = idMacroconcepto;
//        dataTable.Columns.Add(idMacroconcepto);
//        dataTable.Columns.Add(id_tipoMacroconcepto);
//        dataTable.PrimaryKey = keys;

//        dataTable.Columns.Add(new DataColumn("idCaso", typeof(long)));
//        dataTable.Columns.Add(new DataColumn("IdCliente", typeof(long)));
//        dataTable.Columns.Add(new DataColumn("CodCliente", typeof(string)));
//        /// Datos documentos
//        dataTable.Columns.Add(new DataColumn("idDocumento", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("FechaVto", typeof(DateTime)));
//        dataTable.Columns.Add(new DataColumn("AcuerdoICO", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("NumRef", typeof(string)));
//         dataTable.Columns.Add(new DataColumn("tipoMacroconceptoText", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("valorOriginal", typeof(decimal)));
//        dataTable.Columns.Add(new DataColumn("valorActualizado", typeof(decimal)));
//        dataTable.Columns.Add(new DataColumn("esCargaManual", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("excluir", typeof(int)));



//        ICasoDocumentoMacroconceptoService casoDocumentoMacroconcepto = ServiceClient<ICasoDocumentoMacroconceptoService>.GetService("CasoDocumentoMacroconceptoService");

//        List<CasoDocumentoMacroconceptoDataContracts> casoDocumentosMacro = casoDocumentoMacroconcepto.GetAllCasoDocumentoMacroconceptos(idCaso);


//        foreach (CasoDocumentoMacroconceptoDataContracts cdm in casoDocumentosMacro)
//        {

//            DataRow row = dataTable.NewRow();

//            row["idMacroconcepto"] = cdm.IdMacroconcepto;
//            row["idCaso"] = cdm.ObjDocumento.ObjCaso.IdCaso;
//            row["idDocumento"] = cdm.ObjDocumento.IdDocumento;
//            row["FechaVto"] = cdm.ObjDocumento.FechaVto;
//            row["CodCliente"] = cdm.ObjDocumento.ObjCliente.CodCliente;
//            row["AcuerdoICO"] = cdm.ObjDocumento.AcuerdoICO;
//            row["NumRef"] = cdm.ObjDocumento.NumRef;
//            row["id_tipoMacroconcepto"] = cdm.ObjMacroConcepto.IdTipomacroconcepto;
//            row["tipoMacroconceptoText"] = cdm.ObjMacroConcepto.DescriCorta;
//            row["valorOriginal"] = cdm.ValorOriginal;
//            row["valorActualizado"] = cdm.ValorActualizado;
//            row["esCargaManual"] = cdm.EsCargaManual;
//            row["excluir"] = cdm.Excluir;

//            dataTable.Rows.Add(row);
//        }
//        return dataTable;
//    }

//    public static DataTable GetCartas(long idCaso)
//    {
//        DataTable dataTable = new DataTable();
//        DataColumn[] keys = new DataColumn[1];

//        ICasoCartaService casoCarta = ServiceClient<ICasoCartaService>.GetService("CasoCartaService");

//        List<CasoCartaDataContracts> Cartas = casoCarta.GetAllCasoCartas(idCaso);

//        DataColumn idCarta = new DataColumn("idCarta", typeof(long));
//        keys[0] = idCarta;
//        dataTable.Columns.Add(idCarta);
//        dataTable.PrimaryKey = keys;

//        dataTable.Columns.Add(new DataColumn("IdCaso", typeof(long)));
//        dataTable.Columns.Add(new DataColumn("TipoCartaID", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("TipoCartaNombre", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("IdCartarel", typeof(long)));
//        dataTable.Columns.Add(new DataColumn("DenominacionCliente", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Localidad", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Provincia", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Calle", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Puerta", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Edificio", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Escalera", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Piso", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("Departamento", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("CodPost", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("envioAutorizado", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("FechaAutorizacionEnvio", typeof(DateTime)));
//        dataTable.Columns.Add(new DataColumn("FechaEnvio", typeof(DateTime)));
//        dataTable.Columns.Add(new DataColumn("idUsuarioAutorizador", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("UsuarioAutorizador", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("idEnvioCD", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("observaciones", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("numCD", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("fechaAR", typeof(DateTime)));
//        dataTable.Columns.Add(new DataColumn("idCartaMotivoAR", typeof(int)));
//        dataTable.Columns.Add(new DataColumn("CartaMotivoARText", typeof(string)));
//        dataTable.Columns.Add(new DataColumn("EstadoCarta", typeof(int)));

//        foreach (CasoCartaDataContracts carta in Cartas)
//        {

//            DataRow row = dataTable.NewRow();
//            row["idCarta"] = carta.IdCarta;
//            row["IdCaso"] = carta.IdCaso;
//            row["TipoCartaID"] = carta.ObjTipoCarta.IdTipocarta;
//            row["TipoCartaNombre"] = carta.ObjTipoCarta.DescCarta;
//            row["IdCartarel"] = carta.IdCartarel;
//            row["DenominacionCliente"] = carta.DenominacionCliente;
//            row["Localidad"] = carta.Localidad;
//            row["Provincia"] = carta.Provincia;
//            row["Calle"] = carta.Calle;
//            row["Puerta"] = carta.Puerta;
//            row["Edificio"] = carta.Edificio;
//            row["Escalera"] = carta.Escalera;
//            row["Piso"] = carta.Piso;
//            row["Departamento"] = carta.Departamento;
//            row["CodPost"] = carta.CodPost;
//            row["envioAutorizado"] = carta.EnvioAutorizado;
//            if (carta.FechaAutorizacionEnvio != DateTime.MinValue)
//            {
//                row["FechaAutorizacionEnvio"] = carta.FechaAutorizacionEnvio;
//            }
            
//            if (carta.ObjEnvio != null)
//            {
//                if (carta.ObjEnvio.FechaEnvio != DateTime.MinValue)
//                {
//                    row["FechaEnvio"] = carta.ObjEnvio.FechaEnvio;
//                }
//                row["idEnvioCD"] = carta.ObjEnvio.IdEnviocd;
//            }
//            else
//            {
//                row["idEnvioCD"] = 0;
//            }
//            row["idUsuarioAutorizador"] = carta.IdUsuarioAutorizador;

//            if (carta.IdUsuarioAutorizador != 0)
//            {
//                IUsuarioService usuario = ServiceClient<IUsuarioService>.GetService("UsuarioService");
//                row["UsuarioAutorizador"] = usuario.GetUsuario(carta.IdUsuarioAutorizador).NombreUsuario;
//                usuario = null;
//            }
//            else
//            {
//                row["UsuarioAutorizador"] = string.Empty;
//            }
//            row["observaciones"] = carta.Observaciones;
//            row["numCD"] = carta.NumCD;
//            if (carta.FechaAR != DateTime.MinValue)
//            {
//                row["fechaAR"] = carta.FechaAR;
//            }
           
//            if (carta.ObjCartaMotivoAR != null)
//            {
//                row["idCartaMotivoAR"] = carta.ObjCartaMotivoAR.IdCartamotivoar;
//                row["CartaMotivoARText"] = carta.ObjCartaMotivoAR.DescMotivoCarta;
//            }
//            else
//            {
//                row["CartaMotivoARText"] = string.Empty;
//                row["idCartaMotivoAR"] = 0;
//            }
//            row["EstadoCarta"] = carta.EstadoCarta;

//            dataTable.Rows.Add(row);
//        }
//        return dataTable;
//    }

//    #endregion
}
