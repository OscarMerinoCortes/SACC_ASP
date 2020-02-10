create table Venta(
IdVenta int not null primary key identity(1,1),
CodigoInterno varchar(100),
PrecioVenta numeric(18,2),
Folio varchar(100) not null,
Fecha datetime not null,
Vendedor varchar(100) not null,
Descuento numeric(18,2) not null,
IdProducto int not null,
Cantidad numeric(18,2) not null,
Subtotal numeric(18,2) not null,
Total numeric(18,2) not null
)


--INSERTAR
alter procedure InsVenDet
@CodigoInterno varchar(100),
@PrecioVenta numeric(18,2),
@Folio varchar(100),
@Fecha datetime,
@Vendedor varchar(100),
@Descuento numeric(18,2),
@IdProducto int,
@Cantidad numeric(18,2),
@Subtotal numeric(18,2),
@Total numeric(18,2)
as
insert into [dbo].[Venta](
CodigoInterno,
PrecioVenta,
Folio,
Fecha,
Vendedor,
Descuento,
IdProducto,
Cantidad,
Subtotal,
Total
)
VALUES(
@CodigoInterno,
@PrecioVenta,
@Folio,
@Fecha,
@Vendedor,
@Descuento,
@IdProducto,
@Cantidad,
@Subtotal,
@Total
)
update [dbo].[Inventario]
set    CantidadSistema = CantidadSistema-@Cantidad
WHERE  IdProducto = @CodigoInterno