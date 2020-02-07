USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_USUARIO] 
	@IdUsuario int ,
	@NomeUsuario varchar(50),
	@Racf varchar(4) ,
	@CPF varchar(11) ,
	@CEP varchar(8) ,
	@NumeroEndereco int ,
	@DtAdmissao date ,
	@DtDemissao date,
	@IdCargo int,
	@IdUsuarioAlteracao int,
	@Senha varchar(6),
	@Ativo bit
as
begin
	select 
		NomeUsuario ,
		Racf  ,
		CPF  ,
		CEP  ,
		NumeroEndereco ,
		DtAdmissao  ,
		DtDemissao ,
		IdCargo ,
		IdUsuarioAlteracao ,
		Senha ,
		Ativo 
	from 
		Usuario
	Where 
		(@IdUsuario is null or @IdUsuario=0) or (IdUsuario = @IdUsuario)
		and (@NomeUsuario is null ) or (NomeUsuario = @NomeUsuario)
		and (@Racf is null ) or (Racf = @Racf)
		and (@CPF is null) or (CPF = @CPF)
		and (@CEP is null) or (CEP = @CEP)
		and (@NumeroEndereco is null or @NumeroEndereco=0) or (NumeroEndereco = @NumeroEndereco)
		and (@DtAdmissao is null) or (cast(DtAdmissao as date) = cast(@DtAdmissao as date))
		and (@DtDemissao is null) or (cast(DtDemissao as date) = cast(@DtDemissao as date))
		and (@IdCargo is null or @IdCargo=0) or (IdCargo = @IdCargo)
		and (@IdUsuarioAlteracao is null or @IdUsuarioAlteracao=0) or (IdUsuarioAlteracao = @IdUsuarioAlteracao)
		and (@Senha is null) or (Senha = @Senha)
		and (@Ativo is null or @Ativo=0) or (Ativo = @Ativo)
end