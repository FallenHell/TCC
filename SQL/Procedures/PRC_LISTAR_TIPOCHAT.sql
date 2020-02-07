USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_TIPOCHAT]
	@IdTipoChat int,
	@NomeTipoChat varchar(20)
as
begin
	select 
		NomeTipoChat
	from 
		TipoChat
	Where 
		(@IdTipoChat is null or @IdTipoChat=0) or (IdTipoChat = @IdTipoChat)
		and (@NomeTipoChat is null) or (NomeTipoChat = @NomeTipoChat)	
end