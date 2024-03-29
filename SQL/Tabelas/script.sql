/****** Object:  Table [dbo].[Avaliacao]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Avaliacao](
	[IdAvaliacao] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioAvaliado] [int] NOT NULL,
	[UsuarioAvaliador] [int] NOT NULL,
	[Nota] [varchar](1) NOT NULL,
	[DtAvaliacao] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAvaliacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[IdCargo] [int] IDENTITY(1,1) NOT NULL,
	[NomeCargo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Chat]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[IdChat] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoChat] [int] NOT NULL,
	[IdMotivoChat] [int] NOT NULL,
	[UsuarioRemetente] [int] NOT NULL,
	[UsuarioDestinatario] [int] NOT NULL,
	[DtEnvio] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdChat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Impedimento]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Impedimento](
	[IdImpedimento] [int] IDENTITY(1,1) NOT NULL,
	[TipoImpedimento] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdImpedimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ImpedimentoUsuario]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImpedimentoUsuario](
	[IdImpedimentoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdImpedimento] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdImpedimentoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[IdLog] [int] IDENTITY(1,1) NOT NULL,
	[DtAlteracao] [date] NOT NULL,
	[IdUsuario] [int] NULL,
	[ValorAgora] [varchar](100) NULL,
	[ValorDepois] [varchar](100) NULL,
 CONSTRAINT [PK__Log__0C54DBC60131AB23] PRIMARY KEY CLUSTERED 
(
	[IdLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MotivoChat]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MotivoChat](
	[IdMotivoChat] [int] IDENTITY(1,1) NOT NULL,
	[NomeMotivoChat] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMotivoChat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoChat]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoChat](
	[IdTipoChat] [int] IDENTITY(1,1) NOT NULL,
	[NomeTipoChat] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoChat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoLog]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoLog](
	[IdTipoLog] [int] IDENTITY(1,1) NOT NULL,
	[NomeTipoLog] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/11/2019 22:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NomeUsuario] [varchar](50) NOT NULL,
	[Racf] [varchar](4) NOT NULL,
	[CPFCNPJ] [varchar](20) NOT NULL,
	[CEP] [varchar](8) NOT NULL,
	[NumeroEndereco] [int] NOT NULL,
	[DtAdmissao] [date] NOT NULL,
	[DtDemissao] [date] NULL,
	[IdCargo] [int] NOT NULL,
	[IdUsuarioAlteracao] [int] NULL,
	[Senha] [varchar](6) NULL,
	[Ativo] [bit] NOT NULL,
	[IdGestor] [int] NULL,
	[TipoDocumento] [varchar](4) NULL,
	[PIS] [varchar](20) NULL,
	[Motivo] [varchar](50) NULL,
	[IdDesligamento] [int] NULL,
 CONSTRAINT [PK__Usuario__5B65BF97F6FDF45C] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK__Avaliacao__Usuar__239E4DCF] FOREIGN KEY([UsuarioAvaliado])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK__Avaliacao__Usuar__239E4DCF]
GO
ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK__Avaliacao__Usuar__24927208] FOREIGN KEY([UsuarioAvaliador])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK__Avaliacao__Usuar__24927208]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD FOREIGN KEY([IdMotivoChat])
REFERENCES [dbo].[MotivoChat] ([IdMotivoChat])
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD FOREIGN KEY([IdTipoChat])
REFERENCES [dbo].[TipoChat] ([IdTipoChat])
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK__Chat__UsuarioDes__2A4B4B5E] FOREIGN KEY([UsuarioDestinatario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK__Chat__UsuarioDes__2A4B4B5E]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK__Chat__UsuarioRem__29572725] FOREIGN KEY([UsuarioRemetente])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK__Chat__UsuarioRem__29572725]
GO
ALTER TABLE [dbo].[ImpedimentoUsuario]  WITH CHECK ADD FOREIGN KEY([IdImpedimento])
REFERENCES [dbo].[Impedimento] ([IdImpedimento])
GO
ALTER TABLE [dbo].[ImpedimentoUsuario]  WITH CHECK ADD  CONSTRAINT [FK__Impedimen__IdUsu__1FCDBCEB] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[ImpedimentoUsuario] CHECK CONSTRAINT [FK__Impedimen__IdUsu__1FCDBCEB]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK__Log__IdUsuario__2D27B809] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK__Log__IdUsuario__2D27B809]
GO
ALTER TABLE [dbo].[Usuario]  WITH NOCHECK ADD  CONSTRAINT [FK__Usuario__IdCargo__151B244E] FOREIGN KEY([IdCargo])
REFERENCES [dbo].[Cargo] ([IdCargo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK__Usuario__IdCargo__151B244E]
GO
