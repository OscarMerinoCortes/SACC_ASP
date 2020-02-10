select*from inventario
CREATE table Inventario 
(
IdInventario int identity(1,1) not null primary key,
IdProducto VARCHAR(100) not null,
CantidadSistema numeric(18,2) not null,
)
--Consulta para inventario
ALTER procedure PV_ConProInvDet
as
Declare 
@CantidadReal int = 0
select a.IdProducto
      ,a.Descripcion
	  ,a.PrecioVenta
	  ,b.Cantidadsistema
	  ,@CantidadReal as CantidadReal
from [dbo].[Productos] a, [dbo].[Inventario] b
where a.CodigoInterno=b.
IdProducto

