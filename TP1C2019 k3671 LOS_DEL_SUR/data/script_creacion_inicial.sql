USE GD2C2019
GO

--CREACION DE TABLAS--


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
USUARIO_PASSWORD NVARCHAR(255),
USUARIO_INTENTOS NUMERIC (18,0),
USUARIO_ESTADO BIT NOT NULL DEFAULT 1
);
GO


CREATE TABLE LOS_DEL_SUR.ADMINISTRATIVO (
ADMIN_ID NUMERIC(18,0) IDENTITY PRIMARY KEY, 
--ADMIN_NOMBRE,
--ADMIN_APELLIDO,
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
CLIE_NOMBRE NVARCHAR(50),
CLIE_APELLIDO NVARCHAR(50),
CLIE_DNI NUMERIC (18,0) UNIQUE,
CLIE_MAIL NVARCHAR(50),
CLIE_TELEFONO NUMERIC (18,0),
CLIE_DIRECCION NUMERIC (18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.DIRECCION(DIRECCION_ID),
CLIE_CIUDAD NVARCHAR(255) ,
CLIE_FECHA_NAC DATE,
CLIE_USUARIO NUMERIC (18,0) FOREIGN KEY REFERENCES LOS_DEL_SUR.USUARIO(USUARIO_ID), --LE QUEITE EL NOT NULL PARA PODER MIGRAR
CLIE_SALDO NUMERIC (18,0)
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
PROVEE_USUARIO NUMERIC (18,0) FOREIGN KEY REFERENCES LOS_DEL_SUR.USUARIO(USUARIO_ID), -- LE QUIETE EL NOT NULL PARA PODER MIGRAR
PROVEE_RUBRO NVARCHAR(255)
);
GO

CREATE TABLE LOS_DEL_SUR.FACTURACION (
FACTURA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY, 
FACTURA_FECHA DATETIME,
FACTURA_NUMERO NUMERIC(18,0),
FACTURA_PROVEE NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.PROVEEDOR(PROVEE_ID),
FACTURA_TOTAL NUMERIC(18,0)
--FACTURA_PERIODO  QUE ENTRABA EN PEDRIODO,
);
GO

CREATE TABLE LOS_DEL_SUR.OFERTA( 
OFERTA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
OFERTA_DESCRIPCION NVARCHAR(255),
OFERTA_FECHA DATETIME,
OFERTA_FECHA_VENC DATETIME,
OFERTA_PRECIO NUMERIC(18,2),
OFERTA_OFERTA_LISTA NUMERIC(18,2),
OFERTA_PORCENTAJE_DESC NUMERIC(18,2),
OFERTA_PROVEEDOR NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.PROVEEDOR(PROVEE_ID),
OFERTA_STOCK NUMERIC(18,0), 
OFERTA_LIMITE_COMPRA NUMERIC(18,0),
OFERTA_CODIGO NVARCHAR(50),  

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
CUPON_CODIGO NUMERIC(18,0),
CUPON_OFERTA NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.OFERTA(OFERTA_ID),
CUPON_PRECIO NUMERIC(18,2),
CUPON_PRECIO_LITA NUMERIC(18,2),
CUPON_CANTIDAD NUMERIC(18,0),
CUPON_VENCIMIENTO DATETIME,
CUPON_COMPRA NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.COMPRA(COMPRA_ID),
--CUPON_ESTADO COMO LO DEFINIMOS?
);
GO

CREATE TABLE LOS_DEL_SUR.ENTREGA (
ENTREGA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
ENTREGA_CUPON NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.CUPON(CUPON_ID) ,
ENTREGA_FECHA DATETIME,
--ENTREGA_DESITON
ENTREGA_CLIENTE_DESTINO NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES LOS_DEL_SUR.CLIENTE(CLIE_ID) --HACE REFERENCIA A CLIENTE_ID O CLIENTE_DESTINO?
);
GO



CREATE TABLE LOS_DEL_SUR.CARGA(
CARGA_ID NUMERIC(18,0) IDENTITY PRIMARY KEY,
CARGA_FECHA DATETIME,
CARGA_CLIENTE NUMERIC(18,0) NOT NULL FOREIGN KEY REFERENCES  LOS_DEL_SUR.CLIENTE(CLIE_ID),
CARGA_TIPO_PAGO NVARCHAR(255),
CARGA_MONTO NUMERIC(18,0),
CARGA_TARJ_NUMERO NUMERIC(18,0),
CARGA_TARJ_VENCIMIENTO DATETIME,
CARGA_TARJ_NOMBRE NVARCHAR(255)
);
GO

--MIGRACION DE DATOS--

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

--SELECT *FROM  LOS_DEL_SUR.DIRECCION


--218 CLIENTES
MERGE INTO [LOS_DEL_SUR].[CLIENTE]
		USING (SELECT DISTINCT MA.CLI_NOMBRE,MA.CLI_APELLIDO, MA.CLI_DNI,MA.CLI_MAIL,
		MA.CLI_TELEFONO,D.DIRECCION_ID, MA.CLI_CIUDAD,MA.CLI_FECHA_NAC
				FROM [gd_esquema].Maestra MA
				JOIN LOS_DEL_SUR.DIRECCION D ON D.DIRECCION_CALLE= MA.CLI_DIRECCION
				) M
			ON( [LOS_DEL_SUR].[CLIENTE].CLIE_NOMBRE = M.CLI_NOMBRE AND
				[LOS_DEL_SUR].[CLIENTE].CLIE_APELLIDO=M.CLI_APELLIDO AND
				[LOS_DEL_SUR].[CLIENTE].CLIE_DNI=M.CLI_DNI )
			WHEN NOT MATCHED THEN 
			INSERT (CLIE_NOMBRE,CLIE_APELLIDO,CLIE_DNI,CLIE_MAIL,CLIE_TELEFONO, CLIE_DIRECCION, CLIE_CIUDAD,CLIE_FECHA_NAC )
			VALUES (CLI_NOMBRE,CLI_APELLIDO, CLI_DNI,CLI_MAIL,CLI_TELEFONO,DIRECCION_ID, CLI_CIUDAD, CLI_FECHA_NAC );
					
			GO


--SELECT DISTINCT * FROM LOS_DEL_SUR.CLIENTE ORDER BY CLIE_DIRECCION
--SELECT Provee_Dom FROM gd_esquema.Maestra
--SELECT DISTINCT count (Cli_Dni),Cli_Dni,Cli_Apellido FROM GD_ESQUEMA.MAESTRA GROUP BY  CLI_DNI,Cli_Apellido
--SELECT DISTINCT COUNT (Provee_CUIT),Provee_RS FROM gd_esquema.Maestra GROUP BY Provee_RS


--38 PROVEEDORES

MERGE INTO [LOS_DEL_SUR].[PROVEEDOR]
	USING (SELECT DISTINCT MA.PROVEE_RS, MA.PROVEE_TELEFONO,D.DIRECCION_ID, MA.PROVEE_CUIT, MA.PROVEE_RUBRO  FROM [gd_esquema].Maestra MA 
	JOIN LOS_DEL_SUR.DIRECCION D ON  D.DIRECCION_CALLE=MA.PROVEE_DOM ) M
	ON ([LOS_DEL_SUR].[PROVEEDOR].PROVEE_RAZON_SOCIAL=M.PROVEE_RS AND
		[LOS_DEL_SUR].[PROVEEDOR].PROVEE_TELEFONO=M.PROVEE_TELEFONO AND
		[LOS_DEL_SUR].[PROVEEDOR].PROVEE_CUIT=M.PROVEE_CUIT 
		)
	WHEN NOT MATCHED THEN 
	INSERT(PROVEE_RAZON_SOCIAL, PROVEE_TELEFONO, PROVEE_DIRECCION, PROVEE_CUIT, PROVEE_RUBRO )
	VALUES( M.PROVEE_RS, M.PROVEE_TELEFONO, DIRECCION_ID, M.PROVEE_CUIT, M.PROVEE_RUBRO );
GO



--------------------------------------------------------PROCEDURES---------------------------------------------------------------------------------------
--------------------------------------------------------PROCEDURES---------------------------------------------------------------------------------------
--------------------------------------------------------PROCEDURES---------------------------------------------------------------------------------------
--------------------------------------------------------PROCEDURES---------------------------------------------------------------------------------------
--------------------------------------------------------PROCEDURES---------------------------------------------------------------------------------------
--------------------------------------------------------PROCEDURES---------------------------------------------------------------------------------------


--Buscar usuarios
create procedure [dbo].BUSCAR_USER @Usuario varchar(30), @Password nvarchar(255)
as
begin 
	declare @estado bit
	declare @intentos int
	--------MODIFICAR LA PARTE DE ENCRIPTACION----------
	select @estado = usuario_Estado from LOS_DEL_SUR.Usuario where USUARIO_USERNAME =  @Usuario and USUARIO_PASSWORD = @Password
	select @intentos = USUARIO_INTENTOS from LOS_DEL_SUR.Usuario where USUARIO_USERNAME = @Usuario

	if not exists(select 1 from LOS_DEL_SUR.Usuario where USUARIO_USERNAME = @Usuario)
		select 0 as resultado
	if exists(select 1 from LOS_DEL_SUR.Usuario where USUARIO_USERNAME = @Usuario and USUARIO_PASSWORD <> @Password )
				
		if (@intentos >= 2) 
			begin
				update LOS_DEL_SUR.Usuario set USUARIO_ESTADO = 0 where USUARIO_USERNAME = @Usuario
				update LOS_DEL_SUR.Usuario set USUARIO_INTENTOS = USUARIO_INTENTOS+1 where USUARIO_USERNAME = @Usuario
				select 1 as resultado
			end
		else begin
				update LOS_DEL_SUR.Usuario set USUARIO_INTENTOS = USUARIO_INTENTOS+1 where USUARIO_USERNAME = @Usuario
				select 2 as resultado
			end
	if @estado = 0
		select 1 as resultado
	if @estado = 1
		begin
			if @intentos = 1 or @intentos = 2
				update LOS_DEL_SUR.Usuario set USUARIO_INTENTOS = 0 where USUARIO_USERNAME = @Usuario
			select 3 as resultado
		end
end
go

----------------------------------------------UPDATE CLIENTES------------------



/****** Object:  StoredProcedure [dbo].[UPDATE_CLIENTE]    Script Date: 22/11/2019 15:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_CLIENTE]
	-- Add the parameters for the stored procedure here
	@clieID int,
	@clieNombre NVARCHAR(50),
	@clieApellido NVARCHAR(50),
	@clieDni NUMERIC(18,0),
	@clieMail NVARCHAR(50),
	@clieTelefono NUMERIC(18,0),
	@clieFechaNac  NVARCHAR(255),
	@clieCiudad NVARCHAR(225),
	@clieDireccion NVARCHAR(255),
	@cliePiso NUMERIC(18,0),
	@clieDepto NVARCHAR(255),
	@clieCodPostal NUMERIC(18,0),
	@cliePassword NVARCHAR(255),
	@clieHabilitado BIT


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	

    -- Insert statements for procedure here
	UPDATE	LOS_DEL_SUR.CLIENTE
				
	SET     
		CLIE_NOMBRE = @clieNombre,
		CLIE_APELLIDO = @clieApellido,
		CLIE_DNI = @clieDni,
		CLIE_MAIL = @clieMail,
		CLIE_TELEFONO = @clieTelefono,
		CLIE_FECHA_NAC = convert(datetime,@clieFechaNac,103),
		CLIE_CIUDAD = @clieCiudad
		
		FROM LOS_DEL_SUR.CLIENTE
		

		WHERE CLIE_ID = @clieID
END
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE	LOS_DEL_SUR.DIRECCION
				
	SET     
		DIRECCION_CALLE = @clieDireccion,
		DIRECCION_PISO = @cliePiso,
		DIRECCION_DEPTO = @clieDepto,
		DIRECCION_COD_POSTAL = @clieCodPostal 

	FROM LOS_DEL_SUR.DIRECCION D
		 join LOS_DEL_SUR.CLIENTE C on c.CLIE_DIRECCION = d.DIRECCION_ID

    WHERE CLIE_ID = @clieID
END
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE	LOS_DEL_SUR.USUARIO
				
	SET     
		USUARIO_PASSWORD = @cliePassword,
		USUARIO_ESTADO = @clieHabilitado

	FROM LOS_DEL_SUR.USUARIO U
		 join LOS_DEL_SUR.CLIENTE C on c.CLIE_USUARIO = U.USUARIO_ID

	WHERE CLIE_ID = @clieID
END


-----------------------------------------BUSCAR CLIENTES ---------------------------

/****** Object:  StoredProcedure [dbo].[BUSCAR_CLIENTE]    Script Date: 22/11/2019 15:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BUSCAR_CLIENTE]
	-- Add the parameters for the stored procedure here
	@clieID int
	
AS
BEGIN
	SELECT  CLIE_ID,
			CLIE_NOMBRE,
			CLIE_APELLIDO,
			CLIE_DNI,
			CLIE_MAIL,
			CLIE_TELEFONO,
			CLIE_FECHA_NAC,
			CLIE_CIUDAD,
			DIRECCION_CALLE,
			DIRECCION_PISO,
			DIRECCION_DEPTO,
			DIRECCION_COD_POSTAL,
			USUARIO_USERNAME,
			USUARIO_PASSWORD,
			USUARIO_ESTADO
		  
	FROM LOS_DEL_SUR.CLIENTE c 
		 join LOS_DEL_SUR.DIRECCION d on c.CLIE_DIRECCION = d.DIRECCION_ID
		 join LOS_DEL_SUR.USUARIO u on c.CLIE_USUARIO = u.USUARIO_ID 
	
	WHERE CLIE_ID = @clieID
END
RETURN


-----------------------------------------BUSCAR PROVEEDOR ---------------------------
----------------------------------------------------------------------------------------------------------
/****** Object:  StoredProcedure [dbo].[BUSCAR_PROVEEDOR]    Script Date: 25/11/2019 18:41:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BUSCAR_PROVEEDOR]
	-- Add the parameters for the stored procedure here
	@proveeID int
	
AS
BEGIN
	SELECT  
			PROVEE_RAZON_SOCIAL,
			PROVEE_CUIT,
			PROVEE_CONTACTO,
			PROVEE_MAIL,
			PROVEE_TELEFONO,
			PROVEE_RUBRO,
			PROVEE_CIUDAD,
			DIRECCION_CALLE,
			DIRECCION_PISO,
			DIRECCION_DEPTO,
			DIRECCION_COD_POSTAL,
			USUARIO_USERNAME,
			USUARIO_PASSWORD,
			USUARIO_ESTADO
		  
	FROM LOS_DEL_SUR.PROVEEDOR c 
		 join LOS_DEL_SUR.DIRECCION d on c.PROVEE_DIRECCION = d.DIRECCION_ID
		 join LOS_DEL_SUR.USUARIO u on c.PROVEE_USUARIO = u.USUARIO_ID 
	
	WHERE PROVEE_ID = @proveeID
END
RETURN

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------- LISTAR PROVEEDORES -------------------------------------------------------------------------------------------------------------------------------------


/****** Object:  StoredProcedure [dbo].[LISTAR_PROVEEDORES]    Script Date: 25/11/2019 18:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LISTAR_PROVEEDORES]
	-- Add the parameters for the stored procedure here
	@proveeRazSoc NVARCHAR(255) = NULL,
	@proveeCuit NVARCHAR(255)= NULL,
	@proveeMail nvarchar(225)= NULL
	
AS
BEGIN

	declare @sql nvarchar(max)

	set @sql = 'Select PROVEE_ID, PROVEE_RAZON_SOCIAL, PROVEE_CUIT, PROVEE_CONTACTO, PROVEE_MAIL, PROVEE_TELEFONO, PROVEE_RUBRO, PROVEE_CIUDAD, USUARIO_USERNAME, USUARIO_ESTADO FROM LOS_DEL_SUR.PROVEEDOR P  join LOS_DEL_SUR.USUARIO u on P.PROVEE_USUARIO = u.USUARIO_Id WHERE 1 = 1'
				
	 IF @proveeCuit IS NOT NULL AND LEN(@proveeCuit) > 0
		set @sql = @sql + ' AND PROVEE_CUIT = ' +  char(39) + @proveeCuit + char(39) 
	
	 IF @proveeRazSoc IS NOT NULL AND LEN(@proveeRazSoc) > 0
		set @sql = @sql + ' AND PROVEE_RAZON_SOCIAL LIKE ' +  char(39) + '%' + @proveeRazSoc + '%' + char(39)

	 IF @proveeMail IS NOT NULL AND LEN(@proveeMail) > 0
		set @sql = @sql + ' AND PROVEE_MAIL LIKE ' +  char(39) + '%' + @proveeMail + '%' + char(39)
	
	 execute sp_executesql @sql	
END

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------SETEAR USER-----------------------------------------

/****** Object:  StoredProcedure [dbo].[SETEAR_USER]    Script Date: 25/11/2019 18:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDURES


CREATE procedure [dbo].[SETEAR_USER]
 @Usuario varchar(30)
AS
BEGIN
	SELECT U.USUARIO_ID, ROL_ID
	FROM LOS_DEL_SUR.USUARIO U JOIN LOS_DEL_SUR.USUARIOXROL R ON U.USUARIO_ID = R.USUARIO_ID
	WHERE USUARIO_USERNAME = @Usuario
END

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------UPDATE PROVEEDORS------------------

/****** Object:  StoredProcedure [dbo].[UPDATE_PROVEEDOR]    Script Date: 25/11/2019 18:43:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_PROVEEDOR]
	-- Add the parameters for the stored procedure here
	@proveeID int,
	@proveeRazSoc NVARCHAR(50),
	@proveeCuit NVARCHAR(50),
	@proveeContacto NVARCHAR(50),
	@proveeMail NVARCHAR(50),
	@proveeTelefono NUMERIC(18,0),
	@proveeRubro  NVARCHAR(255),
	@proveeCiudad NVARCHAR(225),
	@proveeCalle NVARCHAR(255),
	@proveePiso NUMERIC(18,0),
	@proveeDepto NVARCHAR(255),
	@proveeCP NUMERIC(18,0),
	@proveePassword NVARCHAR(255),
	@proveeHabilitado BIT


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	

    -- Insert statements for procedure here
	UPDATE	LOS_DEL_SUR.PROVEEDOR
				
	SET     
		PROVEE_RAZON_SOCIAL = @proveeRazSoc,
		PROVEE_CUIT = @proveeCuit,
		PROVEE_CONTACTO = @proveeContacto,
		PROVEE_MAIL = @proveeMail,
		PROVEE_TELEFONO = @proveeTelefono,
		PROVEE_RUBRO = @proveeRubro,
		PROVEE_CIUDAD = @proveeCiudad
		
		FROM LOS_DEL_SUR.PROVEEDOR
		

		WHERE PROVEE_ID = @proveeID
END

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE	LOS_DEL_SUR.DIRECCION
				
	SET     
		DIRECCION_CALLE = @proveeCalle,
		DIRECCION_PISO = @proveePiso,
		DIRECCION_DEPTO = @proveeDepto,
		DIRECCION_COD_POSTAL = @proveeCP 

	FROM LOS_DEL_SUR.DIRECCION D
		 join LOS_DEL_SUR.PROVEEDOR P on P.PROVEE_DIRECCION = d.DIRECCION_ID

    WHERE PROVEE_ID = @proveeID
END

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE	LOS_DEL_SUR.USUARIO
				
	SET     
		USUARIO_PASSWORD = @proveePassword,
		USUARIO_ESTADO = @proveeHabilitado

	FROM LOS_DEL_SUR.USUARIO U
		 join LOS_DEL_SUR.PROVEEDOR P on P.PROVEE_USUARIO = U.USUARIO_ID

	WHERE PROVEE_ID = @proveeID
END


------------------------------------CARGAR MONTO--------------------------


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CARGAR_CREDITO]
	-- Add the parameters for the stored procedure here
	@clieID int,
	@tipoPago NVARCHAR(255)= NULL,
	@monto NUMERIC(18,0),
	@tarjetaNum NUMERIC(18,0),
	@tarjetaVenc DATETIME,
	@tarjetaNombre NVARCHAR(255),
	@fecha DATETIME
	
AS
BEGIN
	UPDATE	LOS_DEL_SUR.CARGA
				
	SET     
		CARGA_FECHA = @fecha,
		CARGA_CLIENTE = @clieID,
		CARGA_TIPO_PAGO = @tipoPago,
		CARGA_MONTO = @monto,
		CARGA_TARJ_NUMERO = @tarjetaNum,
		CARGA_TARJ_VENCIMIENTO = @tarjetaVenc,
		CARGA_TARJ_NOMBRE = @tarjetaNombre
		
		FROM LOS_DEL_SUR.CARGA
END
BEGIN
	UPDATE	LOS_DEL_SUR.CLIENTE
				
	SET     
		CLIE_SALDO = @monto
		
		FROM LOS_DEL_SUR.CLIENTE
		WHERE CLIE_ID = @clieID
END
