--Rodar em Primeiro essas Tabelas

create table Cargo(
	IdCargo int Identity(1,1) not null PRIMARY KEY,
	NomeCargo varchar(50) not null
)

create table Impedimento(
	IdImpedimento int Identity(1,1) not null PRIMARY KEY,
	TipoImpedimento varchar(100) not null
)

create table TipoLog(
	IdTipoLog int Identity(1,1) not null Primary KEY,
	NomeTipoLog varchar(20) not null
)
create table TipoChat(
	IdTipoChat int Identity(1,1) not null Primary key,
	NomeTipoChat varchar(20) not null
)
create table MotivoChat(
	IdMotivoChat int Identity(1,1) not null Primary key,
	NomeMotivoChat varchar(20) not null
)
--Rodar em Segundo essas Tabelas

create table Usuario(
	IdUsuario int Identity(1,1) not null PRIMARY KEY,
	NomeUsuario varchar(50) not null,
	Racf varchar(4) not null,
	Senha varchar(6) not null,
	CPF varchar(11) not null,
	CEP varchar(8) not null,
	NumeroEndereco int not null,
	DtAdmissao date not null,
	DtDemissao date,
	IdCargo int not null FOREIGN Key references Cargo(IdCargo),
	IdUsuarioAlteracao int,
	Ativo bit not null
)

--Rodar em Terceiro essas Tabelas

create table ImpedimentoUsuario(
	IdImpedimentoUsuario int Identity(1,1) not null Primary key,
	IdUsuario int not null FOREIGN Key references Usuario(IdUsuario),
	IdImpedimento int not null FOREIGN Key references Impedimento(IdImpedimento)
)
create table Avaliacao(
	IdAvaliacao int Identity(1,1) not null Primary key,
	UsuarioAvaliado int not null FOREIGN Key references Usuario(IdUsuario),
	UsuarioAvaliador int not null FOREIGN Key references Usuario(IdUsuario),
	Nota varchar(1) not null,
	DtAvaliacao date not null
)
create table Chat(
	IdChat int Identity(1,1) not null PRIMARY key,
	IdTipoChat int not null FOREIGN Key references TipoChat(IdTipoChat),
	IdMotivoChat int not null FOREIGN Key references MotivoChat(IdMotivoChat),
	UsuarioRemetente int not null FOREIGN Key references Usuario(IdUsuario),
	UsuarioDestinatario int not null FOREIGN Key references Usuario(IdUsuario),
	DtEnvio date not null
)

--Rodar em Quarto essas Tabelas

create table Log(
	IdLog int Identity(1,1) not null PRIMARY key,
	DtAlteracao date not null,
	IdUsuario int not null FOREIGN Key references Usuario(IdUsuario),
	ValorAgora varchar(100) not null,
	ValorDepois varchar(100) not null
)