USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_LOG] 
	@IdLog int,
	@IdUsuario int,
	@ValorAgora varchar(100),
	@ValorDepois varchar(100),
	@DtAlteracao date
as
begin
	select 
		IdUsuario,
		ValorAgora,
		ValorDepois,
		DtAlteracao
	from 
		Log
	Where 
		(@IdLog is null or @IdLog=0) or (IdLog = @IdLog)
		and (@IdUsuario is null or @IdUsuario=0) or (IdUsuario = @IdUsuario)
		and (@ValorAgora is null) or (ValorAgora = @ValorAgora)
		and (@ValorDepois is null) or (ValorDepois = @ValorDepois)
		and (@DtAlteracao is null) or (cast(DtAlteracao as date) = cast(@DtAlteracao as date))
end