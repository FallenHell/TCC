USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_IMPEDIMENTOUSUARIO] 
	@IdImpedimentoUsuario int,
	@IdUsuario int,
	@IdImpedimento int
as
begin
	select 
		IdUsuario,
		IdImpedimento
	from 
		ImpedimentoUsuario
	Where 
		(@IdImpedimentoUsuario is null or @IdImpedimentoUsuario=0) or (IdImpedimentoUsuario = @IdImpedimentoUsuario)
		and (@IdUsuario is null or @IdUsuario=0) or (IdUsuario = @IdUsuario)
		and (@IdImpedimento is null or @IdImpedimento=0) or (IdImpedimento = @IdImpedimento)
end