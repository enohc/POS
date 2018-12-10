--create database POS3
--go
--use pos3;
--go
drop table TICKET;
drop table CONFIG_PROMOCION;
drop table PROMOCION;
drop table ROL_MENU;
drop table USUARIO;
drop table MENU;
drop table ROL;
drop table PRODUCTO;
drop table CATALOGO;
go
create table MENU(
	idMenu		int not null IDENTITY (1, 1),
	pagina		nvarchar(200),
	descripcion	nvarchar(200),
	activo		bit,
	primary key (idMenu),
	unique (pagina)
);
go
create table ROL(
	idRol		int not null IDENTITY (1, 1),
	nombre		varchar(30),
	decripcion	varchar(140),
	activo		bit,
	primary key(idRol),
	unique (nombre)
);

go
create table ROL_MENU(
	rol		int,
	menu	int,
	activo	bit,
	primary key (rol,menu),
	foreign key (rol) references ROL(idRol),
	foreign key (menu) references MENU(idMenu)
);
go
create table USUARIO(
	nombre		varchar(70),
	usuario		varchar(20),
	clave		varchar(20),
	sexo		char(1),
	DUI			varchar(10),
	rol			integer,
	activo		bit,
	unique (nombre),
	unique (usuario),
	primary key (DUI),
	foreign key (rol) references ROL(idRol)
);
go
CREATE TABLE CATALOGO (
    idCatalogo	int not null IDENTITY (1, 1),
    nombre		VARCHAR(20) NOT NULL,
    descripcion VARCHAR(200) NOT NULL,
    Valor		VARCHAR(400) NOT NULL,
    catalogo	INTEGER NOT NULL,
    subCatalogo	bit NULL,
    activo		bit NOT NULL,
    PRIMARY KEY (idCatalogo),
	foreign key (catalogo) references CATALOGO(idCatalogo)
);
go
CREATE TABLE PRODUCTO (
    idProdcuto		int not null IDENTITY (1, 1),
    producto		VARCHAR(30) NOT NULL,
    tipo			INTEGER NOT NULL,
    precio_venta	MONEY NOT NULL,
    activo			bit NOT NULL,
    PRIMARY KEY (idProdcuto),
	foreign key (tipo) references CATALOGO(idCatalogo)
);
go
CREATE TABLE PROMOCION (
    idPromocion		VARCHAR(30) NOT NULL,
    nombre			VARCHAR(30) NOT NULL,
    desde			DATE NOT NULL,
    hatas			DATE NOT NULL,
    precio_venta	MONEY NOT NULL,
    activo			BIT NOT NULL,
    PRIMARY KEY (idPromocion)
);
go
CREATE TABLE CONFIG_PROMOCION (
    producto	INTEGER NOT NULL,
    promocion	VARCHAR(30) NOT NULL,
    activo		BIT NOT NULL
	PRIMARY KEY (producto,promocion),
	foreign key (promocion) references PROMOCION(idPromocion),
	foreign key (producto) references PRODUCTO(idProdcuto)
);
go
CREATE TABLE TICKET (
    idTicket	int not null IDENTITY (1, 1),
    fecha		DATETIME NOT NULL,
    usuario		VARCHAR(10) NOT NULL,
    producto	INTEGER null,
    promocion	VARCHAR(30) null,
    PRIMARY KEY (idTicket),
	foreign key (promocion) references PROMOCION(idPromocion),
	foreign key (producto) references PRODUCTO(idProdcuto)
);