USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_CHAT] 
	@IdChat int,
	@IdTipoChat int,
	@IdMotivoChat int,
	@UsuarioRemetente int,
	@UsuarioDestinatario int,
	@DtEnvio date
as
begin
	select 
		IdTipoChat,
	    IdMotivoChat,
	    UsuarioRemetente,
	    UsuarioDestinatario,
	    DtEnvio
	from 
		Chat
	Where 
		(@IdChat is null or @IdChat=0) or (IdChat = @IdChat)
		and (@IdTipoChat is null or @IdTipoChat=0) or (IdTipoChat = @IdTipoChat)
		and (@IdMotivoChat is null or @IdMotivoChat=0) or (IdMotivoChat = @IdMotivoChat)
		and (@UsuarioRemetente is null or @UsuarioRemetente=0) or (UsuarioRemetente = @UsuarioRemetente)
		and (@UsuarioDestinatario is null or @UsuarioDestinatario=0) or (UsuarioDestinatario = @UsuarioDestinatario)
		and (@DtEnvio is null) or (cast(DtEnvio as date) = cast(@DtEnvio as date))
end