create trigger trgUsuario On dbo.Usuario After update, insert, delete 
as 
begin 
	Declare @IdUsuario int
	Declare @NomeUsuario varchar(50)  
	Declare @Racf varchar(4)
	Declare @CPF varchar(11)
	Declare @CEP varchar(8)
	Declare @NumeroEndereco int 
	Declare @DtAdmissao date 
	Declare @DtDemissao date
	Declare @IdCargo int
	Declare @Senha varchar(6)
	Declare @IdUsuarioAlteracao int
	Declare @IdUsuarioAntigo int
	Declare @NomeUsuarioAntigo varchar(50)  
	Declare @RacfAntigo varchar(4)
	Declare @CPFAntigo varchar(11)
	Declare @CEPAntigo varchar(8)
	Declare @NumeroEndercoAntigo int 
	Declare @DtAdmissaoAntigo date 
	Declare @DtDemissaoAntigo date
	Declare @IdCargoAntigo int
	Declare @SenhaAntigo varchar(6)

Select 
	@IdUsuario    = inserted.IdUsuario ,
@NomeUsuario   = inserted.NomeUsuario ,
@Racf          = inserted.Racf ,
@CPF           = inserted.CPF ,
@CEP           = inserted.CEP ,
@NumeroEndereco = inserted.NumeroEndereco ,
@DtAdmissao    = inserted.DtAdmissao ,
@DtDemissao    = inserted.DtDemissao ,
@IdCargo       = inserted.IdCargo,
@Senha       = inserted.Senha,
@IdUsuarioAlteracao       = inserted.IdUsuarioAlteracao
from inserted

Select 
	@IdUsuarioAntigo     = Deleted.IdUsuario ,
@NomeUsuarioAntigo   = Deleted.NomeUsuario ,
@RacfAntigo          = Deleted.Racf ,
@CPFAntigo           = Deleted.CPF ,
@CEPAntigo           = Deleted.CEP ,
@NumeroEnderecoAntigo = Deleted.NumeroEndereco ,
@DtAdmissaoAntigo    = Deleted.DtAdmissao ,
@DtDemissaoAntigo    = Deleted.DtDemissao ,
@IdCargoAntigo       = Deleted.IdCargo,
@Senha       = Deleted.Senha,
@IdUsuarioAlteracao       = Deleted.IdUsuarioAlteracao
from deleted

IF exists (Select * from inserted)
	If Update (IdUsuario)
	Begin
	If(@IdUsuarioAntigo is null or @IdUsuario <> @IdUsuarioAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@IdUsuarioAntigo,@IdUsuario)
	End
	If Update (NomeUsuario)
	Begin
	If(@NomeUsuarioAntigo is null or @NomeUsuario <> @NomeUsuarioAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@NomeUsuarioAntigo,@NomeUsuario)
	End
	If Update (Racf)
	Begin
	If(@RacfAntigo is null or @Racf <> @RacfAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@RacfAntigo,@Racf)
	End
	If Update (CPF)
	Begin
	If(@CPFAntigo is null or @CPF <> @CPFAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@CPFAntigo,@CPF)
	End
	If Update (CEP)
	Begin
	If(@CEPAntigo is null or @CEP <> @CEPAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@CEPAntigo,@CEP)
	End
	If Update (NumeroEndereco)
	Begin
	If(@NumeroEnderecoAntigo is null or @NumeroEndereco <> @NumeroEnderecoAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@NumeroEnderecoAntigo,@NumeroEndereco)
	End
	If Update (DtAdmissao)
	Begin
	If(@DtAdmissaoAntigo is null or @DtAdmissao <> @DtAdmissaoAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@DtAdmissaoAntigo,@DtAdmissao)
	End
	If Update (DtDemissao)
	Begin
	If(@DtDemissaoAntigo is null or @DtDemissao <> @DtDemissaoAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@DtDemissaoAntigo,@DtDemissao)
	End
	If Update (IdCargo)
	Begin
	If(@IdCargoAntigo is null or @IdCargo <> @IdCargoAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@IdCargoAntigo,@IdCargo)
	End
	If Update (Senha)
	Begin
	If(@SenhaAntigo is null or @Senha <> @SenhaAntigo)
		insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values (getdate(),@IdUsuarioAlteracao,@SenhaAntigo,@Senha)
	End
Else 
	Begin
	Insert into Log(DtAlteracao,IdUsuario,ValorAgora,ValorDepois) values(getdate(),@IdUsuarioAlteracao,@IdUsuario,null)
	End
End
