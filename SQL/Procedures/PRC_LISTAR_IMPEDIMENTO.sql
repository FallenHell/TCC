USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_IMPEDIMENTO] 
	@IdImpedimento int,
	@TipoImpedimento varchar(100)
as
begin
	select 
		TipoImpedimento
	from 
		Impedimento
	Where 
		(@IdImpedimento is null or @IdImpedimento=0) or (IdImpedimento = @IdImpedimento)
		and (@TipoImpedimento is null) or (TipoImpedimento = @TipoImpedimento)
end