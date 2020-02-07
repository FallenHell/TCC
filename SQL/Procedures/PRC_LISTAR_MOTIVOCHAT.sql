USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_MOTIVOCHAT] 
	@IdMotivoChat int,
	@NomeMotivoChat varchar(50)
as
begin
	select 
		NomeMotivoChat
	from 
		MotivoChat
	Where 
		(@IdMotivoChat is null or @IdMotivoChat=0) or (IdMotivoChat = @IdMotivoChat)
		and (@NomeMotivoChat is null) or (NomeMotivoChat = @NomeMotivoChat)
end