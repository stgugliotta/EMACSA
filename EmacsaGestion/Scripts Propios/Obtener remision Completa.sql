declare @idRemision as int
declare @idRecibo as int
declare @idPagoCur as int
declare @formaPagoCur as varchar(20)
declare @numRecibo as varchar(30)


select @idRemision=max(idRemision)from dbo.TBL_Remision (nolock)


select @idRecibo=remRec.idRecibo from dbo.TBL_Remision (nolock) rem
INNER JOIN dbo.TBL_Remision_Recibo (nolock) remRec
ON rem.idRemision=remRec.idRemision
where remRec.idremision=@idRemision


select * from dbo.TBL_Remision_Recibo

SELECT 'D E T A L L E  D E  L A  R E M I S I O N'

select * from dbo.TBL_Remision (nolock) rem
INNER JOIN dbo.TBL_Remision_Recibo (nolock) remRec
ON rem.idRemision=remRec.idRemision
where remRec.idremision=@idRemision

SELECT 'D E T A L L E  D E L  R E C I B O '

select * from dbo.TBL_Recibo_Pago  (nolock)
where idrecibo=@idRecibo 

select @numRecibo=numRecibo from dbo.TBL_Recibo (nolock)
where id_recibo=@idRecibo


DECLARE Pago_Cursor CURSOR FOR 


select idPago,formaPago from dbo.TBL_Recibo_Pago 
where idrecibo=@idRecibo

SELECT 'D E T A L L E  D E  P A G O S'


OPEN Pago_Cursor -- Abro el cursor
	FETCH NEXT FROM Pago_Cursor 
	-- Inserto en las variables segun el orden en el que realice la seleccion
	INTO @idPagoCur,@formaPagoCur


WHILE @@FETCH_STATUS = 0 -- HASTA QUE NO ESTE VACIA LA SELECCION

	BEGIN
	IF @formaPagoCur='CHEQUE' 
	Begin
          SELECT * FROM MTR_CHEQUE WHERE ID=@idPagoCur
	END
	
	IF @formaPagoCur='EFECTIVO' 
	Begin
          SELECT * FROM TBL_Efectivo WHERE ID=@idPagoCur
	END

	IF @formaPagoCur='DEPOSITO' 
	Begin
          SELECT * FROM TBL_Deposito WHERE ID=@idPagoCur
	END

	IF @formaPagoCur='RETENCION' 
	Begin
          SELECT * FROM TBL_Retencion WHERE ID=@idPagoCur
	END
	
	IF @formaPagoCur='TRANSFERENCIA' 
	Begin
          SELECT * FROM TBL_Transferencia WHERE ID=@idPagoCur
	END

	IF @formaPagoCur='OTRO'
	Begin
          SELECT * FROM TBL_OtroPago WHERE ID=@idPagoCur
	END

	IF @formaPagoCur='DESCUENTO' 
	Begin
          SELECT * FROM TBL_Remision_Descuento WHERE ID=@idPagoCur
	END




	FETCH NEXT FROM Pago_Cursor 
	INTO @idPagoCur,@formaPagoCur
	END
	CLOSE Pago_Cursor 
	DEALLOCATE Pago_Cursor 



SELECT 'D E T A L L E  D E  F A C T U R A S  D E L  R E C I B O  '

select * from dbo.TBL_Recibo_Factura (nolock)
where numRecibo=@numRecibo


--
--
--SELECT rec.NumRecibo,rec.fechaCarga,recPago.idPago,recPago.formaPago FROM dbo.TBL_Recibo (NOLOCK) rec
--	INNER JOIN dbo.TBL_Recibo_Pago (NOLOCK) recPago
--	ON rec.id_recibo=recpago.idrecibo
--	LEFT JOIN dbo.MTR_Cheque (NOLOCK) cheque
--	ON recPago.idPago=cheque.id and recPago.formaPago='CHEQUE'
--	LEFT JOIN  dbo.TBL_Efectivo(NOLOCK) efectivo
--	ON recPago.idPago=efectivo.id and recPago.formaPago='EFECTIVO'
--	LEFT JOIN  dbo.TBL_Deposito (NOLOCK) deposito
--	ON recPago.idPago=deposito.id and recPago.formaPago='DEPOSITO'
--	LEFT JOIN  dbo.TBL_Retencion (NOLOCK) retencion
--	ON recPago.idPago=retencion.id and recPago.formaPago='RETENCION'
--	LEFT JOIN  dbo.TBL_Transferencia (NOLOCK) transferencia
--	ON recPago.idPago=transferencia.id and recPago.formaPago='TRANSFERENCIA'
--	LEFT JOIN  dbo.TBL_OtroPago (NOLOCK) otro
--	ON recPago.idPago=otro.id and recPago.formaPago='OTRO'
--	LEFT JOIN  dbo.TBL_Remision_Descuento (NOLOCK) descuento
--	ON recPago.idPago=otro.id and recPago.formaPago='DESCUENTO'
--where recpago.idrecibo=@idRecibo


