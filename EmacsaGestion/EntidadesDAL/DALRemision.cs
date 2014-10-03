using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;
using System.Transactions;


namespace EntidadesDAL
{
    /// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Remision
    /// </summary>
    public class DALRemision : AbstractMapper<Remision>
    {
        /// <summary>
        /// Constructor Standard
        /// </summary>
        public DALRemision()
        {
            DBConnection oDbConnection = DBConnection.Instancia;
            Db = oDbConnection.Db;
            ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection;
        }

        /// <summary>
        /// Destructor Standard
        /// </summary>
        ~DALRemision()
        {
            ObjConnection.Dispose();
        }

        /// <summary>
        /// M?todo que retorna solo un objeto  Remision
        /// </summary>
        /// <param name="idTarea"></param>      
        /// <returns></returns>
        public Remision Load(int idRemision)
        {
            try
            {
                Remision oReturn = null;
                CommandText = "PA_MG_FRONT_Remision_SELECT";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idRemision", DbType.Int32, idRemision));

                List<Remision> Remisions = AbstractFindAll(oParameters);
                if (Remisions.Count > 0)
                {
                    oReturn = Remisions[0];
                }

                return oReturn;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        /// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Remision
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        public void Delete(Remision oRemision)
        {
            //try
            //{
            //    CommandText = "PA_MG_FRONT_Remision_DELETE";
            //    CommandType = CommandType.StoredProcedure;
            //    ArrayList oParameters = new ArrayList();

            //    oParameters.Add(new DBParametro("@idtarea", DbType.Int32, oRemision.IdTarea));

            //    ExecuteNonQuery(oParameters);
            //}
            //catch (Exception ex)
            //{
            //    Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, Delete", ex.Message);

            //    throw new GobbiTechnicalException(
            //        string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            //}
        }

        /// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Remision
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        public void Update(Remision oRemision)
        {
            try
            {

                //using (TransactionScope transScope = new TransactionScope())
                //{


          

                CommandText = "PA_MG_FRONT_Remision_Update";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idRemision", DbType.Int32, oRemision.NumeroRemision));
                oParameters.Add(new DBParametro("@fechaCreacion", DbType.DateTime, oRemision.FechaDeCreacion));
                oParameters.Add(new DBParametro("@usuarioCreador", DbType.String, oRemision.AnalistaGenerador.Nombre));
                oParameters.Add(new DBParametro("@estado", DbType.String, oRemision.Estado));
                oParameters.Add(new DBParametro("@cambio", DbType.Double, oRemision.Cambio));
                oParameters.Add(new DBParametro("@idCliente", DbType.Int32, null));
                oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, null));


                this.ExecuteNonQuery(oParameters);




            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);


            }
        }






        /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Remision
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        public int Insert(Remision oRemision)
        {
            try
            {

                //using (TransactionScope transScope = new TransactionScope())
                //{


                this.BeginTransaction();

                    CommandText = "PA_MG_FRONT_Remision_Insert";
                    CommandType = CommandType.StoredProcedure;
                    ArrayList oParameters = new ArrayList();

                    oParameters.Add(new DBParametro("@idRemision", DbType.Int32, 0));
                    oParameters.Add(new DBParametro("@fechaCreacion", DbType.DateTime, oRemision.FechaDeCreacion));
                    oParameters.Add(new DBParametro("@usuarioCreador", DbType.String, oRemision.AnalistaGenerador.Nombre));
                    oParameters.Add(new DBParametro("@estado", DbType.String, oRemision.Estado));
                    oParameters.Add(new DBParametro("@cambio", DbType.Double, oRemision.Cambio));
                    oParameters.Add(new DBParametro("@idCliente", DbType.Int32, null));
                    oParameters.Add(new DBParametro("@idDeudor", DbType.Int32, null));

                    int idRemision = int.Parse(ExecuteScalar(oParameters,this.ObjConnection).ToString());


                    List<Recibo> listaDeRecibos = new List<Recibo>();
                    listaDeRecibos = oRemision.ListaDeRecibos;


                    foreach (Recibo recibo in listaDeRecibos)
                    {


                        DALRecibo dalRecibo = new DALRecibo();

                        int idRecibo = int.Parse(dalRecibo.InsertEscalar(recibo).ToString());


                        CommandText = "PA_MG_FRONT_Remision_Recibo_Insert";
                        CommandType = CommandType.StoredProcedure;
                        ArrayList oParametersRemiReci = new ArrayList();
                        oParametersRemiReci.Add(new DBParametro("@idRemision", DbType.Int32, idRemision));
                        oParametersRemiReci.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));

                       // ExecuteNonQuery(oParametersRemiReci);
                        ExecuteScalar(oParametersRemiReci, this.ObjConnection);



                        List<Pago> listaDePagos = new List<Pago>();

                        listaDePagos = recibo.ListadoDePagosIngresados;





                        foreach (Pago pago in listaDePagos)
                        {

                            CommandText = "PA_MG_FRONT_Recibo_Pago_Insert";
                            CommandType = CommandType.StoredProcedure;
                            ArrayList oParametersReciPago = new ArrayList();
                            oParametersReciPago.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));
                            oParametersReciPago.Add(new DBParametro("@numRecibo", DbType.String, recibo.Numero));
                            oParametersReciPago.Add(new DBParametro("@idMoneda", DbType.Int32, pago.IdMoneda));

                            switch (pago.FormaPago.Descripcion)
                            {

                                case "CHEQUE":
                                    Cheque cheque = new Cheque();
                                    this.MappingEntity(pago, cheque);

                                    DALCheque dalCheque = new DALCheque();
                                    int idCheque = dalCheque.InsertEscalar(cheque);

                                    oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idCheque));
                                    oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));

                                    //ExecuteNonQuery(oParametersReciPago);
                                    ExecuteScalar(oParametersReciPago, this.ObjConnection);

                                    break;

                                case "RETENCION":
                                    Retencion retencion = new Retencion();
                                    this.MappingEntity(pago, retencion);

                                    DALRetencion dalRetencion = new DALRetencion();
                                    int idRetencion = dalRetencion.InsertEscalar(retencion);

                                    oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idRetencion));
                                    oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                    ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                    break;

                                case "EFECTIVO":

                                    Efectivo efectivo = new Efectivo();
                                    this.MappingEntity(pago, efectivo);

                                    DALEfectivo dalEfectivo = new DALEfectivo();
                                    int idEfectivo = dalEfectivo.InsertEscalar(efectivo);
                                    oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idEfectivo));
                                    oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                    ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                    break;

                                case "DEPOSITO":
                                    Deposito deposito = new Deposito();
                                    this.MappingEntity(pago, deposito);

                                    DALDeposito dalDeposito = new DALDeposito();
                                    int idDeposito = dalDeposito.InsertEscalar(deposito);
                                    oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idDeposito));
                                    oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                    ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                    break;

                                case "TRANSFERENCIA":
                                    Transferencia transferencia = new Transferencia();
                                    this.MappingEntity(pago, transferencia);

                                    DALTransferencia dalTransferencia = new DALTransferencia();
                                    int idTransferencia = dalTransferencia.InsertEscalar(transferencia);
                                    oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idTransferencia));
                                    oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                    ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                    break;

                                case "OTRO":
                                    OtroPago otroPago = new OtroPago();
                                    this.MappingEntity(pago, otroPago);

                                    DALOtroPago dalOtroPago = new DALOtroPago();
                                    int idOtroPago = dalOtroPago.InsertEscalar(otroPago);
                                    oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idOtroPago));
                                    oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                    ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                    break;

                                case "DESCUENTO":
                                    RemisionDescuento remisionDescuento = new RemisionDescuento();
                                    this.MappingEntity(pago, remisionDescuento);

                                    DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento();
                                    int idRemisionDescuento = dalRemisionDescuento.InsertEscalar(remisionDescuento);
                                    oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idRemisionDescuento));
                                    oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                    ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                    break;





                            }


                        }

                        List<ReciboFactura> listaReciboFacturas = new List<ReciboFactura>();
                        listaReciboFacturas = recibo.ListadoDeFacturasACancelar;

                        foreach (ReciboFactura  factura in listaReciboFacturas)
                        {
                            DALReciboFactura dalReciboFactura = new DALReciboFactura();

                            dalReciboFactura.InsertEscalar(factura);
                            
                        }

                    }

                    this.CommitTransaction();
                    
                    return idRemision;
                    

                

               
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
                this.RollBackTransaction();
          
            }
        }




        /// <summary>
        /// M?todo que inserta recibos para una remision existente.
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        public void  UpdateReciboEnRemision(Remision oRemision)
        {
            try
            {

                this.BeginTransaction();

                int idRemision = oRemision.NumeroRemision;

                List<Recibo> listaDeRecibos = new List<Recibo>();
                listaDeRecibos = oRemision.ListaDeRecibos;


                foreach (Recibo recibo in listaDeRecibos)
                {


                    DALRecibo dalRecibo = new DALRecibo();

                    int idRecibo = int.Parse(dalRecibo.InsertEscalar(recibo).ToString());


                    CommandText = "PA_MG_FRONT_Remision_Recibo_Insert";
                    CommandType = CommandType.StoredProcedure;
                    ArrayList oParametersRemiReci = new ArrayList();
                    oParametersRemiReci.Add(new DBParametro("@idRemision", DbType.Int32, idRemision));
                    oParametersRemiReci.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));
             
                    // ExecuteNonQuery(oParametersRemiReci);
                    ExecuteScalar(oParametersRemiReci, this.ObjConnection);



                    List<Pago> listaDePagos = new List<Pago>();

                    listaDePagos = recibo.ListadoDePagosIngresados;


                    if (recibo.CompensacionDePago != null)
                    {
                        DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago();
                        dalCompensacionDePago.Insert(recibo.CompensacionDePago);
                    }



                    foreach (Pago pago in listaDePagos)
                    {

                        CommandText = "PA_MG_FRONT_Recibo_Pago_Insert";
                        CommandType = CommandType.StoredProcedure;
                        ArrayList oParametersReciPago = new ArrayList();
                        oParametersReciPago.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));
                        oParametersReciPago.Add(new DBParametro("@numRecibo", DbType.String, recibo.Numero));
                        oParametersReciPago.Add(new DBParametro("@idMoneda", DbType.Int32, pago.IdMoneda));
                        oParametersReciPago.Add(new DBParametro("@totalPesificado", DbType.Double, pago.TotalPesificado));

                        switch (pago.FormaPago.Descripcion)
                        {

                            case "CHEQUE":
                                Cheque cheque = new Cheque();
                                this.MappingEntity(pago, cheque);

                                DALCheque dalCheque = new DALCheque();
                                int idCheque = dalCheque.InsertEscalar(cheque);

                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idCheque));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));

                                //ExecuteNonQuery(oParametersReciPago);
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);

                                break;

                            case "RETENCION":
                                Retencion retencion = new Retencion();
                                this.MappingEntity(pago, retencion);

                                DALRetencion dalRetencion = new DALRetencion();
                                int idRetencion = dalRetencion.InsertEscalar(retencion);

                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idRetencion));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "EFECTIVO":

                                Efectivo efectivo = new Efectivo();
                                this.MappingEntity(pago, efectivo);

                                DALEfectivo dalEfectivo = new DALEfectivo();
                                int idEfectivo = dalEfectivo.InsertEscalar(efectivo);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idEfectivo));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "DEPOSITO":
                                Deposito deposito = new Deposito();
                                this.MappingEntity(pago, deposito);

                                DALDeposito dalDeposito = new DALDeposito();
                                int idDeposito = dalDeposito.InsertEscalar(deposito);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idDeposito));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "TRANSFERENCIA":
                                Transferencia transferencia = new Transferencia();
                                this.MappingEntity(pago, transferencia);

                                DALTransferencia dalTransferencia = new DALTransferencia();
                                int idTransferencia = dalTransferencia.InsertEscalar(transferencia);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idTransferencia));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "OTRO":
                                OtroPago otroPago = new OtroPago();
                                this.MappingEntity(pago, otroPago);

                                DALOtroPago dalOtroPago = new DALOtroPago();
                                int idOtroPago = dalOtroPago.InsertEscalar(otroPago);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idOtroPago));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "DESCUENTO":
                                RemisionDescuento remisionDescuento = new RemisionDescuento();
                                this.MappingEntity(pago, remisionDescuento);

                                DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento();
                                int idRemisionDescuento = dalRemisionDescuento.InsertEscalar(remisionDescuento);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idRemisionDescuento));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                        }


                    }

                    List<ReciboFactura> listaReciboFacturas = new List<ReciboFactura>();
                    listaReciboFacturas = recibo.ListadoDeFacturasACancelar;

                    foreach (ReciboFactura factura in listaReciboFacturas)
                    {
                        DALReciboFactura dalReciboFactura = new DALReciboFactura();

                        dalReciboFactura.InsertEscalar(factura);

                    }
                   
                }

                this.CommitTransaction();


            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
                this.RollBackTransaction();

            }
        }


        public void UpdateReciboEnRemision(Remision oRemision,Recibo oRecibo)
        {
            try
            {

                this.BeginTransaction();

                int idRemision = oRemision.NumeroRemision;

                List<Recibo> listaDeRecibos = new List<Recibo>();
                listaDeRecibos = oRemision.ListaDeRecibos;


                foreach (Recibo recibo in listaDeRecibos)
                {
                    DALRecibo dalRecibo = new DALRecibo();
                    dalRecibo.Update(oRecibo);
                       
                    int idRecibo = oRecibo.Id;


                    CommandText = "PA_MG_FRONT_Remision_Recibo_Insert";
                    CommandType = CommandType.StoredProcedure;
                    ArrayList oParametersRemiReci = new ArrayList();
                    oParametersRemiReci.Add(new DBParametro("@idRemision", DbType.Int32, idRemision));
                    oParametersRemiReci.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));

                    // ExecuteNonQuery(oParametersRemiReci);
                    ExecuteScalar(oParametersRemiReci, this.ObjConnection);

                    List<Pago> listaDePagos = new List<Pago>();

                    listaDePagos = recibo.ListadoDePagosIngresados;
                    if (recibo.CompensacionDePago != null)
                    {
                        DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago();
                        dalCompensacionDePago.Insert(recibo.CompensacionDePago);
                    }



                    foreach (Pago pago in listaDePagos)
                    {

                        CommandText = "PA_MG_FRONT_Recibo_Pago_Insert";
                        CommandType = CommandType.StoredProcedure;
                        ArrayList oParametersReciPago = new ArrayList();
                        oParametersReciPago.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));
                        oParametersReciPago.Add(new DBParametro("@numRecibo", DbType.String, recibo.Numero));
                        oParametersReciPago.Add(new DBParametro("@idMoneda", DbType.Int32, pago.IdMoneda));
                        oParametersReciPago.Add(new DBParametro("@totalPesificado", DbType.Double, pago.TotalPesificado));
                     

                        switch (pago.FormaPago.Descripcion)
                        {

                            case "CHEQUE":
                                Cheque cheque = new Cheque();
                                this.MappingEntity(pago, cheque);

                                DALCheque dalCheque = new DALCheque();
                                int idCheque = dalCheque.InsertEscalar(cheque);

                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idCheque));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));

                                //ExecuteNonQuery(oParametersReciPago);
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);

                                break;

                            case "RETENCION":
                                Retencion retencion = new Retencion();
                                this.MappingEntity(pago, retencion);

                                DALRetencion dalRetencion = new DALRetencion();
                                int idRetencion = dalRetencion.InsertEscalar(retencion);

                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idRetencion));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "EFECTIVO":

                                Efectivo efectivo = new Efectivo();
                                this.MappingEntity(pago, efectivo);

                                DALEfectivo dalEfectivo = new DALEfectivo();
                                int idEfectivo = dalEfectivo.InsertEscalar(efectivo);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idEfectivo));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "DEPOSITO":
                                Deposito deposito = new Deposito();
                                this.MappingEntity(pago, deposito);

                                DALDeposito dalDeposito = new DALDeposito();
                                int idDeposito = dalDeposito.InsertEscalar(deposito);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idDeposito));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "TRANSFERENCIA":
                                Transferencia transferencia = new Transferencia();
                                this.MappingEntity(pago, transferencia);

                                DALTransferencia dalTransferencia = new DALTransferencia();
                                int idTransferencia = dalTransferencia.InsertEscalar(transferencia);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idTransferencia));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "OTRO":
                                OtroPago otroPago = new OtroPago();
                                this.MappingEntity(pago, otroPago);

                                DALOtroPago dalOtroPago = new DALOtroPago();
                                int idOtroPago = dalOtroPago.InsertEscalar(otroPago);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idOtroPago));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "DESCUENTO":
                                RemisionDescuento remisionDescuento = new RemisionDescuento();
                                this.MappingEntity(pago, remisionDescuento);

                                DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento();
                                int idRemisionDescuento = dalRemisionDescuento.InsertEscalar(remisionDescuento);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idRemisionDescuento));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                        }

                    }

                    List<ReciboFactura> listaReciboFacturas = new List<ReciboFactura>();
                    listaReciboFacturas = recibo.ListadoDeFacturasACancelar;

                    foreach (ReciboFactura factura in listaReciboFacturas)
                    {
                        DALReciboFactura dalReciboFactura = new DALReciboFactura();

                        dalReciboFactura.InsertEscalar(factura,idRecibo);

                        DALAccion dalAccion =new DALAccion();
                        Accion accion =new Accion();
                        accion.IdAccion = 0;
                        accion.Usuario = oRemision.AnalistaGenerador.Nombre;
                        accion.FechaAccion = DateTime.Now;
                        double res = factura.Saldo - factura.ImporteAImputar;
                        accion.IdEstado = res==0?5:7;
                        accion.Observacion = res == 0 ? "Factura imputada en recibo: " + oRecibo.Numero + ", remisión:" + oRemision.NumeroRemision.ToString()+ " , Monto Imputado: " + factura.ImporteAImputar.ToString() : "Factura imputada parcialmente en recibo: " + oRecibo.Numero + ", remisión:" + oRemision.NumeroRemision.ToString() +", Monto Imputado: " + factura.ImporteAImputar.ToString();
                        accion.IdFactura = factura.IdFactura;
                        accion.IdDeudor = oRecibo.Deudor.IdDeudor;
                        accion.IdCliente =Int32.Parse(oRecibo.Cliente.IdCliente.ToString());
                        accion.FechaVencimiento = DateTime.Parse("01/01/1900");
                        accion.ProximaGestion = DateTime.Parse("01/01/1900");
                        accion.Saldo = factura.Saldo;
                        accion.MontoImputacion = factura.MontoImputacion;
                        dalAccion.InsertComplementario(accion);

                    }

                }

                this.CommitTransaction();

            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
                this.RollBackTransaction();

            }
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Remision de la tabla dbo.TBL_Remision
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        /// 
        public List<Remision> GetAllRemisions()
        {
            //try
            //{
            //    CommandText = "PA_MG_FRONT_Remision_SELECTALL";
            //    CommandType = CommandType.StoredProcedure;
            //    ArrayList oParameters = new ArrayList();

            //    List<Remision> Remisions = AbstractFindAll(oParameters);

            //    return Remisions;
            //}
            //catch (Exception ex)
            //{
            //    Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, getRemisions", ex.Message);

            //    throw new GobbiTechnicalException(
            //        string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            //}
            

                return null;
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Remision de la tabla dbo.TBL_Remision
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        /// 
        public List<Remision> GetAllRemisionsBlocked()
        {
            try
            {
                CommandText = "PA_MG_FRONT_Remision_SelectALL_Locked";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                List<Remision> Remisions = AbstractFindAll(oParameters);

                return Remisions;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, getRemisions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }


            return null;
        }


        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Remision de la tabla dbo.TBL_Remision
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        public List<Remision> GetAllRemisionsByAnalista(string analista)
        {
            //try
            //{
            //    CommandText = "PA_MG_FRONT_Remision_SELECTALL_ByAnalista";
            //    CommandType = CommandType.StoredProcedure;
            //    ArrayList oParameters = new ArrayList();
            //    oParameters.Add(new DBParametro("@analista", DbType.String, analista));
            //    List<Remision> Remisions = AbstractFindAll(oParameters);

            //    return Remisions;
            //}
            //catch (Exception ex)
            //{
            //    Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, getRemisions", ex.Message);

            //    throw new GobbiTechnicalException(
            //        string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            //}

            return null;
        }



        /// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Remision de la tabla dbo.TBL_Remision
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        public List<Remision> GetAllRemisionsByAnalistaYFecha(string analista,DateTime fecha)
        {
        //    try
        //    {
        //        CommandText = "PA_MG_FRONT_Remision_SELECTALL_ByAnalistaYFecha";
        //        CommandType = CommandType.StoredProcedure;
        //        ArrayList oParameters = new ArrayList();
        //        oParameters.Add(new DBParametro("@analista", DbType.String, analista));
        //        oParameters.Add(new DBParametro("@fecha", DbType.DateTime, fecha));
        //        List<Remision> Remisions = AbstractFindAll(oParameters);

        //        return Remisions;
        //    }
        //    catch (Exception ex)
        //    {
        //        Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, getRemisions", ex.Message);

        //        throw new GobbiTechnicalException(
        //            string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
        //    }
            return null;
        }


        /// <summary>
        /// M?todo que crea un objeto Remision de la tabla dbo.TBL_Remision
        /// </summary>
        /// <param name="oRemision"></param>
        /// <returns></returns>
        public override Remision DoLoad(IDataReader registros)
        {
  

           
            try
            {
                Remision remision = new Remision();
                remision.NumeroRemision = registros.GetInt32(0);
                remision.FechaDeCreacion = registros.IsDBNull(1) ? DateTime.Now : registros.GetDateTime(1);
                remision.AnalistaGenerador = new Analista();
                remision.AnalistaGenerador.Nombre =registros.GetString(2);
                remision.Estado = registros.GetString(3);
                //remision.Cambio = registros.GetFloat(4);
                remision.IDCliente=registros.IsDBNull(5) ? 0:registros.GetInt32(5);
                try
                {
                    remision.Cliente = registros.GetString(7);

                }
                catch (Exception)
                {

                    remision.Cliente = string.Empty;
                }


                return remision;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, getRemisions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
     
      
        }

        public int InsertCabecera(Remision oRemision)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Remision_Insert";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@idremision", DbType.Int32, 0));
                oParameters.Add(new DBParametro("@fechacreacion", DbType.DateTime, oRemision.FechaDeCreacion));
                oParameters.Add(new DBParametro("@usuariocreador", DbType.String, oRemision.AnalistaGenerador.Nombre));
                oParameters.Add(new DBParametro("@estado", DbType.String, oRemision.Estado));
                oParameters.Add(new DBParametro("@cambio", DbType.Double, oRemision.Cambio));
                oParameters.Add(new DBParametro("@idcliente", DbType.Int32, oRemision.IDCliente));
                oParameters.Add(new DBParametro("@iddeudor", DbType.Int32, null));

                return int.Parse(ExecuteScalar(oParameters).ToString());
                
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
                                   
        private void MappingEntity(object source, object target)
        {

            if ((source==null)||(target==null))
            {
            return;
            }

            System.Collections.IEnumerator propiedades;

            propiedades = source.GetType().GetProperties().GetEnumerator();

            System.Reflection.PropertyInfo propiedad;

            object value;

            

            while( propiedades.MoveNext())
            {
                try
                {
                propiedad = (System.Reflection.PropertyInfo)propiedades.Current;

                value = propiedad.GetGetMethod().Invoke(source, null);

                if (value != null)
                {
                    object[] parameters = new object[1];

                    parameters[0] = value;
                    target.GetType().GetProperty(propiedad.Name).GetSetMethod().Invoke(target, parameters);
                }
                }
            
            catch(Exception ex)
            {
            
            }
            }
        
        
        }

        public void UpdateReciboEnRemisionParaEdicion(Remision oRemision, Recibo oRecibo)
        {
            try
            {

               // this.BeginTransaction();

                int idRemision = oRemision.NumeroRemision;

                List<Recibo> listaDeRecibos = new List<Recibo>();
                listaDeRecibos = oRemision.ListaDeRecibos;


                foreach (Recibo recibo in listaDeRecibos)
                {
                    DALRecibo dalRecibo = new DALRecibo();
                    dalRecibo.Update(oRecibo);

                    int idRecibo = oRecibo.Id;

                    //Elimino los pagos, facturas y compensaciones del recibo original. El recibo sigue quedando vivo. 
                    CommandText = "PA_MG_FRONT_Recibo_Delete_PorIdReciboIdCliente";
                    CommandType = CommandType.StoredProcedure;
                    ArrayList oParametersRemiReci = new ArrayList();
                    oParametersRemiReci.Add(new DBParametro("@id_cliente", DbType.Int32, recibo.Cliente.IdCliente));
                    oParametersRemiReci.Add(new DBParametro("@id_Recibo", DbType.Int32, idRecibo));

                    // ExecuteNonQuery(oParametersRemiReci);
                    ExecuteScalar(oParametersRemiReci, this.ObjConnection);


                    //Ahora sobre el recibo vivo cargo la nueva compensación si es que existe.

                    List<Pago> listaDePagos = new List<Pago>();

                    listaDePagos = recibo.ListadoDePagosIngresados;
                    if (recibo.CompensacionDePago != null)
                    {
                        DALCompensacionDePago dalCompensacionDePago = new DALCompensacionDePago();
                        dalCompensacionDePago.Insert(recibo.CompensacionDePago);
                    }



                    foreach (Pago pago in listaDePagos)
                    {

                        CommandText = "PA_MG_FRONT_Recibo_Pago_Insert";
                        CommandType = CommandType.StoredProcedure;
                        ArrayList oParametersReciPago = new ArrayList();
                        oParametersReciPago.Add(new DBParametro("@idRecibo", DbType.Int32, idRecibo));
                        oParametersReciPago.Add(new DBParametro("@numRecibo", DbType.String, recibo.Numero));
                        oParametersReciPago.Add(new DBParametro("@idMoneda", DbType.Int32, pago.IdMoneda));
                        oParametersReciPago.Add(new DBParametro("@totalPesificado", DbType.Double, pago.TotalPesificado));

                        switch (pago.FormaPago.Descripcion)
                        {

                            case "CHEQUE":
                                Cheque cheque = new Cheque();
                                this.MappingEntity(pago, cheque);

                                DALCheque dalCheque = new DALCheque();
                                int idCheque = dalCheque.InsertEscalar(cheque);

                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idCheque));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));

                                //ExecuteNonQuery(oParametersReciPago);
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);

                                break;

                            case "RETENCION":
                                Retencion retencion = new Retencion();
                                this.MappingEntity(pago, retencion);

                                DALRetencion dalRetencion = new DALRetencion();
                                int idRetencion = dalRetencion.InsertEscalar(retencion);

                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idRetencion));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "EFECTIVO":

                                Efectivo efectivo = new Efectivo();
                                this.MappingEntity(pago, efectivo);

                                DALEfectivo dalEfectivo = new DALEfectivo();
                                int idEfectivo = dalEfectivo.InsertEscalar(efectivo);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idEfectivo));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "DEPOSITO":
                                Deposito deposito = new Deposito();
                                this.MappingEntity(pago, deposito);

                                DALDeposito dalDeposito = new DALDeposito();
                                int idDeposito = dalDeposito.InsertEscalar(deposito);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idDeposito));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "TRANSFERENCIA":
                                Transferencia transferencia = new Transferencia();
                                this.MappingEntity(pago, transferencia);

                                DALTransferencia dalTransferencia = new DALTransferencia();
                                int idTransferencia = dalTransferencia.InsertEscalar(transferencia);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idTransferencia));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "OTRO":
                                OtroPago otroPago = new OtroPago();
                                this.MappingEntity(pago, otroPago);

                                DALOtroPago dalOtroPago = new DALOtroPago();
                                int idOtroPago = dalOtroPago.InsertEscalar(otroPago);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idOtroPago));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                            case "DESCUENTO":
                                RemisionDescuento remisionDescuento = new RemisionDescuento();
                                this.MappingEntity(pago, remisionDescuento);

                                DALRemisionDescuento dalRemisionDescuento = new DALRemisionDescuento();
                                int idRemisionDescuento = dalRemisionDescuento.InsertEscalar(remisionDescuento);
                                oParametersReciPago.Add(new DBParametro("@idPago", DbType.Int32, idRemisionDescuento));
                                oParametersReciPago.Add(new DBParametro("@formaPago", DbType.String, pago.FormaPago.Descripcion));
                                ExecuteScalar(oParametersReciPago, this.ObjConnection);
                                break;

                        }

                    }

                    List<ReciboFactura> listaReciboFacturas = new List<ReciboFactura>();
                    listaReciboFacturas = recibo.ListadoDeFacturasACancelar;

                    foreach (ReciboFactura factura in listaReciboFacturas)
                    {
                        DALReciboFactura dalReciboFactura = new DALReciboFactura();

                        dalReciboFactura.InsertEscalar(factura, idRecibo,this.ObjConnection);

                        DALAccion dalAccion = new DALAccion();
                        Accion accion = new Accion();
                        accion.IdAccion = 0;
                        accion.Usuario = oRemision.AnalistaGenerador.Nombre;
                        accion.FechaAccion = DateTime.Now;
                        double res = factura.Saldo - factura.ImporteAImputar;
                        accion.IdEstado = res == 0 ? 5 : 7;
                       // accion.Observacion = res == 0 ? "Factura imputada en recibo: " + oRecibo.Numero + ", remisión:" + oRemision.NumeroRemision.ToString() : "Factura imputada parcialmente en recibo: " + oRecibo.Numero + ", remisión:" + oRemision.NumeroRemision.ToString();
                        accion.Observacion = res == 0 ? "Factura imputada en recibo: " + oRecibo.Numero + ", remisión:" + oRemision.NumeroRemision.ToString() + " , Monto Imputado: " + factura.ImporteAImputar.ToString() : "Factura imputada parcialmente en recibo: " + oRecibo.Numero + ", remisión:" + oRemision.NumeroRemision.ToString() + ", Monto Imputado: " + factura.ImporteAImputar.ToString();
                        accion.IdFactura = factura.IdFactura;
                        accion.IdDeudor = oRecibo.Deudor.IdDeudor;
                        accion.IdCliente = Int32.Parse(oRecibo.Cliente.IdCliente.ToString());
                        accion.FechaVencimiento = DateTime.Parse("01/01/1900");
                        accion.ProximaGestion = DateTime.Parse("01/01/1900");
                        accion.Saldo = factura.Saldo;
                        accion.MontoImputacion = factura.MontoImputacion;
                        dalAccion.InsertComplementario(accion);

                    }

                }

                //this.CommitTransaction();

            }
            catch (Exception ex)
            {
                //this.RollBackTransaction();
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRemision, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);


            }
        }

        public override Remision DoLoad(IDataReader registros, Remision ent)
        {
            throw new NotImplementedException();
        }
    }
}
