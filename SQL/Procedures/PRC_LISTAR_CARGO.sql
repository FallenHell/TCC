USE [TCC]
GO
/****** Object:  StoredProcedure [dbo].[PRC_LISTAR_CARGO]    Script Date: 15/09/2019 17:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[PRC_LISTAR_CARGO] 
	@IdCargo int,
	@NomeCargo varchar(50)
as
begin
	select 
		NomeCargo
	from 
		Cargo
	Where 
		(@IdCargo is null or @IdCargo=0) or (IdCargo = @IdCargo)
		and (@NomeCargo is null) or (NomeCargo = @NomeCargo)
end