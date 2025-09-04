create database facturasbd
go
use facturasbd
go

create table formapagos(
    idforma int,
    nombre varchar(20),
    constraint pk_formapagos primary key(idforma)
);

create table facturas(
    nroFactura int identity(2001,1), 
    fecha datetime,
    idforma int,
    cliente varchar(50),
    constraint pk_facturas primary key(nrofactura),
    constraint fk_formapago foreign key (idforma) references formapagos(idforma)
);

create table articulos(
    id_articulo int identity(1,1),
    nombre varchar (50),
    precioUnitario numeric,
    stock int,
    constraint pk_articulos primary key(id_articulo)
);

create table detalle_factura(
    id_detalle int identity(1,1),
    id_articulo int,
    cantidad int,
    nrofactura int,
    monto numeric,
    constraint pk_detalle primary key(id_detalle),
    constraint fk_factura foreign key (nrofactura) references facturas(nrofactura),
    constraint fk_articulo foreign key (id_articulo) references articulos(id_articulo)
);

insert into formapagos values (1, 'Efectivo');
insert into formapagos values (2, 'Tarjeta Débito');
insert into formapagos values (3, 'Tarjeta Crédito');

insert into articulos values ('Yerba Mate 1Kg', 4500);
insert into articulos values ( 'Azúcar 1Kg', 1500);
insert into articulos values ( 'Aceite 1Lt', 3800);
insert into articulos values ( 'Fideos Spaghetti 500g', 1200);
insert into articulos values ( 'Leche Sachet 1Lt', 1100);
insert into articulos values ( 'Pan Casero Kg', 2500);
insert into articulos values ( 'Galletitas Dulces', 900);
insert into articulos values ( 'Gaseosa 2.25Lt', 2800);

insert into facturas values ('2024-08-01', 1, 'José Fernández');
insert into facturas values ('2024-08-02', 2, 'Marta Rivas');
insert into facturas values ('2024-08-03', 3, 'Don Ricardo (fiado)');
insert into facturas values ('2024-08-04', 1, 'Lucía Giménez');

insert into detalle_factura values ( 1, 1, 2001, 4500);
insert into detalle_factura values ( 2, 2, 2001, 3000); 
insert into detalle_factura values ( 5, 3, 2001, 3300);

insert into detalle_factura values ( 3, 1, 2002, 3800);
insert into detalle_factura values ( 4, 2, 2002, 2400); 
insert into detalle_factura values ( 8, 1, 2002, 2800);

insert into detalle_factura values ( 6, 1, 2003, 2500);
insert into detalle_factura values ( 7, 2, 2003, 1800); 
insert into detalle_factura values ( 5, 1, 2003, 1100);

insert into detalle_factura values ( 2, 1, 2004, 1500);
insert into detalle_factura values ( 1, 1, 2004, 4500);
insert into detalle_factura values ( 8, 1, 2004, 2800);
----------------------------------------------------------
set ansi_nulls on
go
set quoted_identifier on
go

create procedure dbo.sp_guardar_facturas
@nro int output,
@fecha datetime,
@tipo int,
@cliente varchar(50)


as
begin
 if @nro=0
    begin 
       insert into facturas(fecha,idforma,cliente)
              values(@fecha,@tipo,@cliente)
              set @nro=SCOPE_IDENTITY();
end 
    else 
      begin 
         update facturas
            set fecha=@fecha,idforma=@tipo,cliente=@cliente
            where nroFactura=@nro
            end
end
go
            
create procedure  dbo.sp_insertar_detalle
@id int,
@articulo int,
@cantidad int,
@nroFactura int,
@monto int
as
begin 
     insert into Detalle_Factura(id_articulo,cantidad,nrofactura,monto)
                  values(@articulo,@cantidad,@nroFactura,@monto)
                  set @id=SCOPE_IDENTITY();
end
go

create procedure  dbo.sp_insertar_articulos
@id int output,
@nombre varchar (50),
@precio numeric,
 @stock int
as 
begin 
           insert into articulos(nombre,precioUnitario,
                  values(@fecha,@tipo,@cliente)
                set @id=SCOPE_IDENTITY();
end 
go
         


create procedure dbo.sp_recuperar_facturas
as
begin
select * 
from facturas
end
go