truncate table [dbo].[MovimientoInventario]
TRUNCATE  TABLE [dbo].[Inventario]
TRUNCATE TABLE [dbo].[Productos]
select*from [dbo].[MovimientoInventario]
select*from [dbo].[Inventario]
select*from [dbo].[Productos]

create table MovimientoInventario(
Folio varchar(50) not null,
IdMovimiento int not null,
IdConcepto int not null,
FechaRegistro datetime not null,
IdProducto Varchar(100) not null,
Cantidad numeric(18,2)
)

ALTER PROCEDURE InsMovInvDet
@Folio varchar(50),
@IdMovimiento int,
@IdConcepto int,
@FechaRegistro datetime,
@IdProducto Varchar(100),
@Cantidad numeric(18,2)
AS
IF @IdMovimiento = 1
BEGIN
INSERT INTO [dbo].[MovimientoInventario]
(
Folio,
IdMovimiento,
IdConcepto,
FechaRegistro,
IdProducto,
Cantidad
)
VALUES
(
@Folio,
@IdMovimiento,
@IdConcepto,
@FechaRegistro,
@IdProducto,
@Cantidad
)
Update [dbo].[Inventario]
set    CantidadSistema = CantidadSistema + @Cantidad
where  IdProducto = @IdProducto
END
IF @IdMovimiento = 2
BEGIN
INSERT INTO [dbo].[MovimientoInventario]
(
Folio,
IdMovimiento,
IdConcepto,
FechaRegistro,
IdProducto,
Cantidad
)
VALUES
(
@Folio,
@IdMovimiento,
@IdConcepto,
@FechaRegistro,
@IdProducto,
@Cantidad
)
Update [dbo].[Inventario]
set    CantidadSistema = CantidadSistema - @Cantidad
where  IdProducto = @IdProducto
END