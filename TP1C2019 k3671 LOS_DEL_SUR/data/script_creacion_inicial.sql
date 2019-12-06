USE GD2C2019
GO

IF OBJECT_ID ('LOS_DEL_SUR.ENCRIPTAR') IS NOT NULL 
  DROP FUNCTION LOS_DEL_SUR.ENCRIPTAR; 
  GO

--CREACION DE TABLAS--
IF OBJECT_ID ('LOS_DEL_SUR.TARJETA_USUARIO','U') IS NOT NULL  
DROP TABLE LOS_DEL_SUR.TARJETA_USUARIO;

IF OBJECT_ID ('LOS_DEL_SUR.OFERTA_FACTURA','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.OFERTA_FACTURA;

IF OBJECT_ID('LOS_DEL_SUR.USUARIOXROL','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.USUARIOXROL;

IF OBJECT_ID ('LOS_DEL_SUR.PERMISOS','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.PERMISOS;

IF OBJECT_ID('LOS_DEL_SUR.FUNCIONALIDAD','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.FUNCIONALIDAD; 

IF OBJECT_ID('LOS_DEL_SUR.ROL','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.ROL; 

IF OBJECT_ID('LOS_DEL_SUR.ADMINISTRATIVO','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.ADMINISTRATIVO ;

IF OBJECT_ID ('LOS_DEL_SUR.ENTREGA','U') IS NOT NULL 
DROP TABLE LOS_DEL_SUR.ENTREGA

IF OBJECT_ID('LOS_DEL_SUR.CUPON','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.CUPON;

IF OBJECT_ID('LOS_DEL_SUR.COMPRA','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.COMPRA;

IF OBJECT_ID ('LOS_DEL_SUR.CARGA','U') IS NOT NULL 
DROP TABLE LOS_DEL_SUR.CARGA

IF OBJECT_ID('LOS_DEL_SUR.CLIENTE','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.CLIENTE;

IF OBJECT_ID('LOS_DEL_SUR.FACTURACION','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.FACTURACION;

IF OBJECT_ID('LOS_DEL_SUR.OFERTA','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.OFERTA; 

IF OBJECT_ID('LOS_DEL_SUR.PROVEEDOR','U') IS NOT NULL
DROP TABLE LOS_DEL_SUR.PROVEEDOR;

IF OBJECT_ID('LOS_DEL_SUR.USUARIO','U') IS NOT NULL 
DROP TABLE LOS_DEL_SUR.USUARIO;

IF OBJECT_ID ('LOS_DEL_SUR.DIRECCION','U') IS NOT NULL 
DROP TABLE LOS_DEL_SUR.DIRECCION ;

IF OBJECT_ID ('LOS_DEL_SUR.TARJETA','U') IS NOT NULL 
DROP TABLE LOS_DEL_SUR.TARJETA; 





/* -- Schema -- */
IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'LOS_DEL_SUR')
    DROP SCHEMA LOS_DEL_SUR
GO

/* ############### CREACIÓN ############### */

/* -- Schema -- */
CREATE SCHEMA LOS_DEL_SUR AUTHORIZATION gdCupon2019;
GO

/*CRACION DE TABLAS*/

CREATE TABLE LOS_DEL_SUR.FUNCIONALIDAD(
FUNCION_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
FUNCION_NOMBRE NVARCHAR(255) 
);
GO


CREATE TABLE LOS_DEL_SUR.ROL (
ROL_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
ROL_NOMBRE NVARCHAR(255),
ROL_ESTADO BIT DEFAULT 1,
);
GO

CREATE TABLE LOS_DEL_SUR.PERMISOS (
FUNCION_ID NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.FUNCIONALIDAD(FUNCION_ID),
ROL_ID NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.ROL(ROL_ID)
);
GO


CREATE TABLE LOS_DEL_SUR.USUARIO(
USUARIO_ID NUMERIC (18,0) IDENTITY PRIMARY KEY,
USUARIO_USERNAME NVARCHAR(255), 
USUARIO_PASSWORD NVARCHAR(255)  ,
USUARIO_INTENTOS NUMERIC (18,0), 
USUARIO_ESTADO  BIT DEFAULT 1
);
GO



CREATE TABLE LOS_DEL_SUR.ADMINISTRATIVO (
ADMIN_ID NUMERIC(18,0) IDENTITY PRIMARY KEY, 
ADMIN_NOMBRE NVARCHAR(255),
ADMIN_APELLIDO NVARCHAR(255),
ADMIN_USUARIO NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.USUARIO(USUARIO_ID)

);
GO

CREATE TABLE LOS_DEL_SUR.USUARIOXROL(
ROL_ID NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.ROL(ROL_ID),
USUARIO_ID NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.USUARIO(USUARIO_ID)
);
GO

CREATE TABLE LOS_DEL_SUR.DIRECCION(
DIRECCION_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
DIRECCION_CALLE NVARCHAR(255),
DIRECCION_PISO NUMERIC(18,0),
DIRECCION_DEPTO NVARCHAR(255),
DIRECCION_COD_POSTAL NUMERIC(18,0) 
);
GO

CREATE TABLE LOS_DEL_SUR.CLIENTE(
CLIE_ID NUMERIC (18,0) IDENTITY PRIMARY KEY,
CLIE_NOMBRE NVARCHAR(255),
CLIE_APELLIDO NVARCHAR(255),
CLIE_DNI NVARCHAR(255),
CLIE_MAIL NVARCHAR(255),
CLIE_TELEFONO NUMERIC (18,0),
CLIE_DIRECCION NUMERIC (18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.DIRECCION(DIRECCION_ID),
CLIE_CIUDAD NVARCHAR(255) ,
CLIE_FECHA_NAC DATETIME,
CLIE_USUARIO NUMERIC (18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.USUARIO(USUARIO_ID),
CLIE_SALDO NUMERIC (18,0),

);
GO

CREATE TABLE LOS_DEL_SUR.PROVEEDOR (
PROVEE_ID NUMERIC (18,0) IDENTITY PRIMARY KEY,
PROVEE_RAZON_SOCIAL NVARCHAR(255),
PROVEE_MAIL NVARCHAR(255),
PROVEE_TELEFONO NUMERIC (18,0),
PROVEE_DIRECCION NUMERIC (18,0) NOT NULL FOREIGN KEY REFERENCES  LOS_DEL_SUR.DIRECCION(DIRECCION_ID) ,
PROVEE_CUIT NVARCHAR(255), 
PROVEE_CIUDAD NVARCHAR(255),
PROVEE_CONTACTO  NVARCHAR(255),
PROVEE_USUARIO NUMERIC (18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.USUARIO(USUARIO_ID),
PROVEE_RUBRO NVARCHAR(255)
);
GO



CREATE TABLE LOS_DEL_SUR.FACTURACION (
FACTURA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY, 
FACTURA_FECHA DATETIME,
FACTURA_NUMERO NUMERIC(18,0) UNIQUE NOT NULL,
FACTURA_PROVEE NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.PROVEEDOR(PROVEE_ID),
FACTURA_TOTAL NUMERIC(18,0),
FACTURA_PERIODO NVARCHAR(255)
);
GO

CREATE TABLE LOS_DEL_SUR.OFERTA( 
OFERTA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
OFERTA_DESCRIPCION NVARCHAR(255),
OFERTA_FECHA DATETIME,
OFERTA_FECHA_VENC DATETIME,
OFERTA_PRECIO NUMERIC(18,2),
OFERTA_OFERTA_LISTA NUMERIC(18,2),
OFERTA_PORCENTAJE_DESC NUMERIC (18,2),
OFERTA_PROVEEDOR NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.PROVEEDOR(PROVEE_ID),
OFERTA_STOCK NUMERIC(18,0), 
OFERTA_LIMITE_COMPRA NUMERIC(18,0),
OFERTA_CODIGO NVARCHAR(50) UNIQUE NOT NULL,  

);
GO

CREATE TABLE LOS_DEL_SUR.OFERTA_FACTURA(

OFERTA_FACT_NUMERO NUMERIC (18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.FACTURACION(FACTURA_ID),
OFERTA_FACT_OFERTA NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.OFERTA(OFERTA_ID),
OFERTA_FACT_CANTIDAD NUMERIC(18,0),
OFERTA_FACT_PRECIO_UNITARIO NUMERIC(18,0),
);
GO

CREATE TABLE LOS_DEL_SUR.COMPRA(
COMPRA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY ,
COMPRA_FECHA DATETIME,
COMPRA_OFERTA NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.OFERTA(OFERTA_ID),
COMPRA_CLIENTE NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.CLIENTE(CLIE_ID)

);
GO

CREATE TABLE LOS_DEL_SUR.CUPON(
CUPON_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
CUPON_CODIGO NVARCHAR(255),
CUPON_OFERTA NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.OFERTA(OFERTA_ID),
CUPON_PRECIO NUMERIC(18,2),
CUPON_PRECIO_LITA NUMERIC(18,2),
CUPON_CANTIDAD NUMERIC(18,0),
CUPON_VENCIMIENTO DATETIME,
CUPON_COMPRA NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.COMPRA(COMPRA_ID),
CUPON_ESTADO BIT DEFAULT 1
);
GO

CREATE TABLE LOS_DEL_SUR.ENTREGA (
ENTREGA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
ENTREGA_CUPON NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.CUPON(CUPON_ID) ,
ENTREGA_FECHA DATETIME,
ENTREGA_CLIENTE_DESTINO NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.CLIENTE(CLIE_ID) --HACE REFERENCIA A CLIENTE_ID O CLIENTE_DESTINO?
);
GO



CREATE TABLE LOS_DEL_SUR.CARGA(
CARGA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
CARGA_FECHA DATETIME,
CARGA_CLIENTE NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES  LOS_DEL_SUR.CLIENTE(CLIE_ID),
CARGA_TIPO_PAGO NVARCHAR(255),
CARGA_MONTO NUMERIC(18,2),
CARGA_TARJ_NUMERO NUMERIC(18,0),
CARGA_TARJ_VENCIMIENTO DATETIME,
CARGA_TARJ_NOMBRE NVARCHAR(255)
);
GO

--MIGRACION DE DATOS--

--ENCRIPTACION DE USUARIO 
/*IF OBJECT_ID ('LOS_DEL_SUR.ENCRIPTAR') IS NOT NULL
    DROP FUNCTION LOS_DEL_SUR.ENCRIPTAR
GO*/





CREATE FUNCTION LOS_DEL_SUR.ENCRIPTAR (@PASSTWORD NVARCHAR(255))
RETURNS NVARCHAR(255)
AS	
	BEGIN 
	 RETURN HASHBYTES('SHA2_256',@PASSTWORD )
	END
GO



/* Inserts (y demás) necesarios antes de la migración */

INSERT INTO LOS_DEL_SUR.FUNCIONALIDAD(FUNCION_NOMBRE) VALUES 
('ABM ROL'),
('ABM REGISTRO USUARIO'),
('ABM CLIENTE'),
('ABM PROVEEDOR'),
('ABM CARGA DE CREDITO'),
('ABM CONFECCION Y PUBLICACION OFERTA'),
('ABM ENTREGA/CONSUMO DE OFERTA'),
('ABM FACTURACION A PROVEEDOR'),
('ABM LISTADO ESTADISTICO');
GO

INSERT INTO LOS_DEL_SUR.ROL(ROL_NOMBRE, ROL_ESTADO) VALUES 
('CLIENTE', 1),
('ADMINISTRADOR', 1),
('PROVEEDOR',1);
GO

INSERT INTO LOS_DEL_SUR.PERMISOS(ROL_ID,FUNCION_ID)
	SELECT DISTINCT R.ROL_ID, F.FUNCION_ID
	FROM LOS_DEL_SUR.ROL R , LOS_DEL_SUR.FUNCIONALIDAD F
	WHERE R.ROL_NOMBRE='ADMINISTRADOR'

INSERT INTO LOS_DEL_SUR.PERMISOS(ROL_ID,FUNCION_ID)
	SELECT DISTINCT R.ROL_ID, F.FUNCION_ID FROM LOS_DEL_SUR.ROL R, LOS_DEL_SUR.FUNCIONALIDAD F
	WHERE R.ROL_NOMBRE='CLIENTE' AND F.FUNCION_NOMBRE IN ('ABM CLIENTES','REGISTRO USUARIO','CARGA CREDITO','ABM ENTREGA/CONSUMO DE OFERTA');

INSERT INTO LOS_DEL_SUR.PERMISOS(ROL_ID,FUNCION_ID)
	SELECT DISTINCT R.ROL_ID, F.FUNCION_ID FROM LOS_DEL_SUR.ROL R , LOS_DEL_SUR.FUNCIONALIDAD F
	WHERE R.ROL_NOMBRE='PROVEEDOR' AND F.FUNCION_NOMBRE IN('ABM REGISTRO USUARIO','ABM CONFECCION Y PUBLICACION OFERTA','ABM FACTURACION A PROVEEDOR');

--SELECT * FROM LOS_DEL_SUR.PERMISOS

--MIGRACION DE LA TABLA 

--218 DIRECCIONES DE CLIENTE--
MERGE INTO [LOS_DEL_SUR].[DIRECCION] 
		USING (SELECT DISTINCT CLI_DIRECCION FROM [gd_esquema].Maestra
				GROUP BY CLI_DIRECCION  ) M
		ON ([LOS_DEL_SUR].[DIRECCION].DIRECCION_CALLE=M.CLI_DIRECCION)

		WHEN NOT MATCHED THEN 
		INSERT (DIRECCION_CALLE)
		VALUES( M.CLI_DIRECCION);
GO


--38 DIRECCIONES DE PROVEEDORES 

MERGE INTO [LOS_DEL_SUR].[DIRECCION] 
		USING (SELECT DISTINCT PROVEE_DOM FROM [gd_esquema].Maestra
				GROUP BY PROVEE_DOM  ) M
		ON ([LOS_DEL_SUR].[DIRECCION].DIRECCION_CALLE=M.PROVEE_DOM)

		WHEN NOT MATCHED THEN 
		INSERT (DIRECCION_CALLE)
		VALUES( M.PROVEE_DOM);
GO



------------------------------------------------
-----------------------------------------------
--218 USUARIOS_CLIENTES
INSERT INTO LOS_DEL_SUR.USUARIO(USUARIO_USERNAME, USUARIO_PASSWORD)
	SELECT DISTINCT CAST(M.Cli_Dni  AS nvarchar(255)), LOS_DEL_SUR.ENCRIPTAR(M.Cli_Dni)  
		FROM gd_esquema.Maestra M
		WHERE M.Cli_Dni IS NOT NULL 
GO	


--255 USUARIOS 
INSERT INTO LOS_DEL_SUR.USUARIO (USUARIO_USERNAME, USUARIO_PASSWORD )
	SELECT DISTINCT  M.Provee_RS, LOS_DEL_SUR.ENCRIPTAR (M.Provee_CUIT)  
		FROM gd_esquema.Maestra M
		WHERE M.Provee_RS IS NOT NULL
GO


------------------------------------------------
-----------------------------------------------


--218 CLIENTES

INSERT INTO LOS_DEL_SUR.CLIENTE (CLIE_NOMBRE,  
								CLIE_APELLIDO, 
								CLIE_DNI,
								CLIE_MAIL,
								CLIE_TELEFONO, 
								CLIE_DIRECCION, 
								CLIE_CIUDAD,
								CLIE_FECHA_NAC,
								CLIE_USUARIO)
				SELECT DISTINCT M.CLI_NOMBRE,
								M.CLI_APELLIDO, 
								CAST(M.Cli_Dni  AS nvarchar(255)),
								M.CLI_MAIL,
								M.CLI_TELEFONO,
								D.DIRECCION_ID, 
								M.CLI_CIUDAD,
								M.CLI_FECHA_NAC,
								U.USUARIO_ID
				FROM [gd_esquema].Maestra M
				JOIN LOS_DEL_SUR.DIRECCION D ON D.DIRECCION_CALLE=M.Cli_Direccion
				JOIN LOS_DEL_SUR.USUARIO U ON U.USUARIO_USERNAME =	CAST(M.Cli_Dni  AS nvarchar(255))
go		

			

INSERT INTO LOS_DEL_SUR.PROVEEDOR(PROVEE_RAZON_SOCIAL, 
									PROVEE_TELEFONO, 
									PROVEE_DIRECCION, 
									PROVEE_CUIT, 
									PROVEE_RUBRO,
									PROVEE_USUARIO)
					SELECT DISTINCT M.PROVEE_RS, 
									M.PROVEE_TELEFONO,
									D.DIRECCION_ID, 
									M.PROVEE_CUIT, 
									M.PROVEE_RUBRO,
									U.USUARIO_ID
					FROM gd_esquema.Maestra M
					JOIN LOS_DEL_SUR.DIRECCION D ON D.DIRECCION_CALLE=M.Provee_Dom
					JOIN LOS_DEL_SUR.USUARIO U ON U.USUARIO_USERNAME= M.Provee_RS


GO 



--84249 OFERTAS
MERGE INTO  [LOS_DEL_SUR].[OFERTA]
 USING (SELECT DISTINCT MA.Oferta_Descripcion, 
					MA.Oferta_Fecha,
					MA.Oferta_Fecha_Venc,
					MA.Oferta_Precio,
					MA.Oferta_Precio_Ficticio,
					P.PROVEE_ID, 
					MA.Oferta_Cantidad, 
					MA.Oferta_Codigo
			FROM [gd_esquema].Maestra MA  
			JOIN [LOS_DEL_SUR].[PROVEEDOR] P ON P.PROVEE_CUIT=MA.PROVEE_CUIT AND
			 P.PROVEE_RAZON_SOCIAL= MA.PROVEE_RS AND 
			 P.PROVEE_CUIT=MA.PROVEE_CUIT ) M
			ON 
			([LOS_DEL_SUR].[OFERTA].OFERTA_CODIGO=M.Oferta_Codigo	
			)
			WHEN NOT MATCHED THEN 
			INSERT (OFERTA_DESCRIPCION,
					OFERTA_FECHA,
					OFERTA_FECHA_VENC,
					OFERTA_PRECIO,
					OFERTA_OFERTA_LISTA,
					OFERTA_PORCENTAJE_DESC,
					OFERTA_PROVEEDOR,
					OFERTA_STOCK,
					OFERTA_LIMITE_COMPRA,
					OFERTA_CODIGO )
			VALUES(M.Oferta_Descripcion, 
					M.Oferta_Fecha,
					M.Oferta_Fecha_Venc,
					M.Oferta_Precio,
					M.Oferta_Precio_Ficticio,
					(100.00 - ROUND(Oferta_Precio * 100.0 / Oferta_Precio_Ficticio, 2))	,													  
					M.PROVEE_ID, 
					M.Oferta_Cantidad, 
					M.Oferta_Cantidad,	
					M.Oferta_Codigo);
GO



--SELECT * FROM LOS_DEL_SUR.OFERTA
 
INSERT INTO LOS_DEL_SUR.CARGA(
							CARGA_FECHA ,
							CARGA_CLIENTE ,
							CARGA_TIPO_PAGO,
							CARGA_MONTO 
							)
	SELECT DISTINCT M.Carga_Fecha,C.CLIE_ID, M.Tipo_Pago_Desc,M.Carga_Credito
	FROM gd_esquema.Maestra M
	JOIN LOS_DEL_SUR.CLIENTE C ON C.CLIE_DNI=M.Cli_Dni
	where M.Carga_Credito is not null							  
GO



-- 119678 COMPRAS
INSERT INTO LOS_DEL_SUR.COMPRA(COMPRA_FECHA,COMPRA_OFERTA,COMPRA_CLIENTE)
	SELECT DISTINCT m.Oferta_Fecha_Compra,O.OFERTA_ID,C.CLIE_ID  
		FROM gd_esquema.Maestra M
	JOIN LOS_DEL_SUR.OFERTA O ON M.Oferta_Codigo=O.OFERTA_CODIGO 
	JOIN LOS_DEL_SUR.CLIENTE C ON M.Cli_Dni=C.CLIE_DNI

GO 

--FACTURACION 481
INSERT INTO LOS_DEL_SUR.FACTURACION(FACTURA_FECHA,
									FACTURA_NUMERO,
									FACTURA_PROVEE,
									FACTURA_TOTAL,
									FACTURA_PERIODO)
		SELECT DISTINCT M.Factura_Fecha, 
						M.Factura_Nro,
						(SELECT P.PROVEE_ID FROM LOS_DEL_SUR.PROVEEDOR P WHERE P.PROVEE_CUIT=M.Provee_CUIT),
						(SELECT SUM(M1.Oferta_Precio)FROM gd_esquema.Maestra M1 WHERE M1.Factura_Nro=M.Factura_Nro),
						(select  CONCAT( MONTH(M2.Factura_Fecha),'/', YEAR(M2.Factura_Fecha) ) 
						from gd_esquema.Maestra M2 
						where  M2.Factura_Nro=M.Factura_Nro 
						GROUP BY M2.Factura_Fecha)
		FROM gd_esquema.Maestra M
		WHERE M.Factura_Nro IS NOT NULL 
			
GO	

	

--66644 OFERTA X FACTURAS
INSERT INTO LOS_DEL_SUR.OFERTA_FACTURA(OFERTA_FACT_NUMERO,
										OFERTA_FACT_OFERTA,
										OFERTA_FACT_PRECIO_UNITARIO) 
	SELECT DISTINCT F.FACTURA_ID,
					O.OFERTA_ID ,
					M.Oferta_Precio  
	FROM gd_esquema.Maestra M
	JOIN LOS_DEL_SUR.OFERTA O ON O.OFERTA_CODIGO=M.Oferta_Codigo
	JOIN LOS_DEL_SUR.FACTURACION F ON F.FACTURA_NUMERO=M.Factura_Nro  
GO




--119678 COMPRAS 
INSERT INTO LOS_DEL_SUR.CUPON (CUPON_CODIGO, 
								CUPON_OFERTA, 
								CUPON_PRECIO, 
								CUPON_PRECIO_LITA, 
								CUPON_VENCIMIENTO,
								CUPON_CANTIDAD,
								CUPON_COMPRA, 
								CUPON_ESTADO)
	SELECT DISTINCT M.Oferta_Codigo, 
					F.OFERTA_ID, 
					M.Oferta_Precio,
					M.Oferta_Precio_Ficticio, 
					MONTH(M.Oferta_Fecha)+1 ,
					'1', 
					C.COMPRA_ID ,
					'1'  
	FROM gd_esquema.Maestra M
	JOIN LOS_DEL_SUR.OFERTA F ON F.OFERTA_CODIGO= M.Oferta_Codigo
	JOIN LOS_DEL_SUR.COMPRA C ON C.COMPRA_OFERTA=F.OFERTA_ID
GO




