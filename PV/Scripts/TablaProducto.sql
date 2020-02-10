select*from [dbo].[Productos]
create table Productos 
(
IdProducto int identity(1,1) not null primary key,
CodigoInterno varchar(100),
Descripcion varchar(100) not null,
Unidad int not null,
PrecioCompra numeric(18,2) not null,
PrecioVenta numeric(18,2) not null,
Clasificacion varchar(100),
FechaRegistro datetime not null,
Cantidad float not null
)


--INSERTAR
ALTER PROCEDURE PV_InsProDet
@IdProducto int,
@CodigoInterno varchar(100),
@Descripcion varchar(100),
@IdUnidad int,
@PrecioCompra numeric(18,2),
@PrecioVenta numeric(18,2),
@Clasificacion varchar(100),
@FechaRegistro datetime,
@Cantidad float
AS
IF @IdProducto = 0
BEGIN
Insert into dbo.Productos(
CodigoInterno,
Descripcion,
Unidad,
PrecioCompra,
PrecioVenta,
Clasificacion,
FechaRegistro,
Cantidad)
VALUES
(
@CodigoInterno,
@Descripcion,
@IdUnidad,
@PrecioCompra,
@PrecioVenta,
@Clasificacion,
@FechaRegistro,
@Cantidad
)
insert into [dbo].[Inventario](
IdProducto,
CantidadSistema
)
VALUES
(
@CodigoInterno,
@Cantidad
)
END
ELSE
BEGIN
update [dbo].[Productos]
set    Descripcion=@Descripcion,
       Unidad=@IdUnidad,
	   PrecioCompra=@PrecioCompra,
	   PrecioVenta=@PrecioVenta,
	   Clasificacion=@Clasificacion,
	   Cantidad=@Cantidad
where  CodigoInterno=@CodigoInterno
END

--CONSULTAR
ALTER PROCEDURE PV_ConProDet
AS
SELECT
IdProducto,CodigoInterno,Descripcion,Unidad,PrecioCompra,PrecioVenta,Clasificacion,FechaRegistro,Cantidad
FROM [dbo].[Productos]