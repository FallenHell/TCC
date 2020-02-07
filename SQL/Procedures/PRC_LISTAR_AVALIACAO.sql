USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_AVALIACAO] 
	@IdAvaliacao int,
	@UsuarioAvaliado int,
	@UsuarioAvaliador int,
	@Nota varchar(100),
	@DtAvaliacao date
as
begin
	select 
		UsuarioAvaliado,
		UsuarioAvaliador,
		Nota,
		DtAvaliacao
	from 
		Avaliacao
	Where 
		(@IdAvaliacao is null or @IdAvaliacao=0) or (IdAvaliacao = @IdAvaliacao)
		and (@UsuarioAvaliado is null or @UsuarioAvaliado=0) or (UsuarioAvaliado = @UsuarioAvaliado)
		and (@UsuarioAvaliador is null or @UsuarioAvaliador=0) or (UsuarioAvaliador = @UsuarioAvaliador)
		and (@Nota is null) or (Nota = @Nota)
		and (@DtAvaliacao is null) or (cast(DtAvaliacao as date) = cast(@DtAvaliacao as date))
end