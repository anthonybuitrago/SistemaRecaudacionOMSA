-- 1. CREACIÓN DE LA BASE DE DATOS
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'OMSA_Recaudacion')
BEGIN
    CREATE DATABASE OMSA_Recaudacion;
    PRINT 'Base de datos OMSA_Recaudacion creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La base de datos OMSA_Recaudacion ya existe.';
END
GO

-- Selecciona la base de datos para todas las operaciones siguientes
USE OMSA_Recaudacion;
GO


-- 2. TABLA DE USUARIOS (LOGIN DEL SISTEMA)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Usuario')
BEGIN
    CREATE TABLE Usuario (
        ID_Usuario      INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador único automático
        NombreUsuario   VARCHAR(50)  NOT NULL UNIQUE,   -- Nombre de acceso (sin duplicados)
        Contrasena      VARCHAR(255) NOT NULL,           -- Contraseña (se recomienda almacenar hash)
        Rol             VARCHAR(30)  NOT NULL            -- Perfil del usuario: Admin, Operador, etc.
            DEFAULT 'Operador',
        FechaCreacion   DATETIME     NOT NULL
            DEFAULT GETDATE(),                           -- Fecha en que se creó el usuario
        Activo          BIT          NOT NULL
            DEFAULT 1                                    -- 1 = Activo, 0 = Deshabilitado
    );
    PRINT 'Tabla Usuario creada.';
END
GO

-- 3. TABLA DE RUTAS
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Ruta')
BEGIN
    CREATE TABLE Ruta (
        ID_Ruta         INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador automático (PK)
        NombreRuta      VARCHAR(100) NOT NULL,           -- Nombre descriptivo de la ruta
        TarifaPasaje    DECIMAL(10,2) NOT NULL           -- Valor monetario del pasaje (RD$)
            CONSTRAINT CK_Ruta_Tarifa CHECK (TarifaPasaje > 0) -- La tarifa debe ser positiva
    );
    PRINT 'Tabla Ruta creada.';
END
GO
INSERT INTO Ruta (NombreRuta, TarifaPasaje)
VALUES 
    ('John F. Kennedy',  25.00),
    ('Juan Bosch',       25.00),
    ('La Barquita',      25.00),
    ('Máximo Gómez',     25.00),
    ('Naco',             25.00),
    ('Simón Bolívar',    25.00),
    ('Los Ríos',         25.00),
    ('27 de Febrero',    25.00),
    ('Abraham Lincoln',  25.00),
    ('Alcarrizos',       25.00),
    ('Charles de Gaulle',25.00),
    ('Independencia',    25.00);
GO

-- Verificar que se insertaron correctamente
SELECT ID_Ruta, NombreRuta, TarifaPasaje 
FROM Ruta 
ORDER BY ID_Ruta;
GO
Delete FROM Ruta;

-- 4. TABLA DE VEHÍCULOS
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Vehiculo')
BEGIN
    CREATE TABLE Vehiculo (
        ID_Vehiculo     INT IDENTITY(1,1) PRIMARY KEY,
        Ficha           VARCHAR(50) NOT NULL UNIQUE,    -- Identificador interno único de la OMSA
        Placa           VARCHAR(50) NOT NULL UNIQUE,    -- Registro legal único del vehículo
        Capacidad       INT         NOT NULL            -- Cantidad máxima de pasajeros
            CONSTRAINT CK_Vehiculo_Capacidad CHECK (Capacidad > 0) -- Capacidad debe ser positiva
    );
    PRINT 'Tabla Vehiculo creada.';
END
GO

INSERT INTO Vehiculo (Ficha, Placa, Capacidad)
VALUES
-- Autobuses rígidos (Mercedes Benz)
('OMSA-MB-001', 'A234501', 45),
('OMSA-MB-002', 'A234502', 45),
('OMSA-MB-003', 'A234503', 45),

-- Autobuses rígidos (Volvo)
('OMSA-VV-001', 'B567801', 50),
('OMSA-VV-002', 'B567802', 50),
('OMSA-VV-003', 'B567803', 50),

-- Autobuses articulados (Mayor capacidad)
('OMSA-ART-001', 'C890101', 220),
('OMSA-ART-002', 'C890102', 220),
('OMSA-ART-003', 'C890103', 220);
GO
select * from Vehiculo;
-- 5. TABLA DE CHOFERES

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Chofer')
BEGIN
    CREATE TABLE Chofer (
        ID_Chofer           INT IDENTITY(1,1) PRIMARY KEY,
        Cedula              VARCHAR(20)  NOT NULL UNIQUE,   -- Documento de identidad (sin duplicados)
        NombreCompleto      VARCHAR(100) NOT NULL,          -- Nombre y apellido del empleado
        NumeroLicencia      VARCHAR(50)  NOT NULL UNIQUE,   -- Registro de conducir único
        Telefono            VARCHAR(20)  NULL,              -- Contacto del chofer (opcional)
        FechaIngreso        DATE         NOT NULL
            DEFAULT CAST(GETDATE() AS DATE)                 -- Fecha en que fue registrado
    );
    PRINT 'Tabla Chofer creada.';
END
GO
INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia)
VALUES
('1234', 'Antony Buitrago',  '3'),
('4567', 'Elvis Baez',       '5'),
('8910', 'Rusember Areche',  '4'),
('1112', 'Luis Eduardo',     '2');
GO


SELECT * FROM Chofer;
-- 6. TABLA DE VIAJES (TABLA TRANSACCIONAL)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Viaje')
BEGIN
    CREATE TABLE Viaje (
        ID_Viaje    INT IDENTITY(1,1) PRIMARY KEY,
        ID_Ruta     INT      NOT NULL,      -- FK ? Ruta realizada
        ID_Chofer   INT      NOT NULL,      -- FK ? Chofer asignado
        ID_Vehiculo INT      NOT NULL,      -- FK ? Autobús utilizado
        FechaViaje  DATETIME NOT NULL,      -- Fecha y hora de inicio del viaje
        Estado      VARCHAR(20)             -- Control de flujo del viaje
            NOT NULL DEFAULT 'Activo'
            CONSTRAINT CK_Viaje_Estado
                CHECK (Estado IN ('Activo', 'Finalizado', 'Cancelado')),

      
        CONSTRAINT FK_Viaje_Ruta
            FOREIGN KEY (ID_Ruta)
            REFERENCES Ruta(ID_Ruta),

        CONSTRAINT FK_Viaje_Chofer
            FOREIGN KEY (ID_Chofer)
            REFERENCES Chofer(ID_Chofer),

        CONSTRAINT FK_Viaje_Vehiculo
            FOREIGN KEY (ID_Vehiculo)
            REFERENCES Vehiculo(ID_Vehiculo)
    );
    PRINT 'Tabla Viaje creada.';
END
GO
INSERT INTO Viaje (ID_Ruta, ID_Chofer, ID_Vehiculo, FechaViaje, Estado) VALUES
(25, 1, 1, GETDATE(), 'Activo'),
(26, 2, 2, GETDATE(), 'Activo'),
(27, 3, 3, GETDATE(), 'Activo');
GO
SELECT * FROM Ruta;
SELECT * FROM Chofer;
SELECT * FROM Vehiculo;

-- 7. TABLA DE TICKETS (DETALLE DE RECAUDACIÓN)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Ticket')
BEGIN
    CREATE TABLE Ticket (
        ID_Ticket       INT IDENTITY(1,1) PRIMARY KEY,
        ID_Viaje        INT             NOT NULL,       -- FK ? Viaje al que pertenece el cobro
        HoraEmision     DATETIME        NOT NULL
            DEFAULT GETDATE(),                          -- Momento exacto del cobro
        MontoPagado     DECIMAL(10,2)   NOT NULL        -- Valor recaudado en esa transacción
            CONSTRAINT CK_Ticket_Monto CHECK (MontoPagado > 0), -- El monto debe ser positivo

        
        CONSTRAINT FK_Ticket_Viaje
            FOREIGN KEY (ID_Viaje)
            REFERENCES Viaje(ID_Viaje)
    );
    PRINT 'Tabla Ticket creada.';
END
GO

-- 8. DATOS INICIALES (SEED)
IF NOT EXISTS (SELECT * FROM Usuario WHERE NombreUsuario = 'admin')
BEGIN
    INSERT INTO Usuario (NombreUsuario, Contrasena, Rol)
    VALUES ('admin', 'Admin123', 'Administrador');
    PRINT 'Usuario administrador creado. Usuario: admin | Contraseña: Admin123';
END
GO

-- 9. ÍNDICES ADICIONALES (RENDIMIENTO)

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Viaje_FechaViaje')
BEGIN
    CREATE INDEX IX_Viaje_FechaViaje ON Viaje(FechaViaje);
    PRINT 'Índice IX_Viaje_FechaViaje creado.';
END
GO

-- Índice para buscar tickets por viaje (consulta de recaudación por viaje)
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Ticket_ID_Viaje')
BEGIN
    CREATE INDEX IX_Ticket_ID_Viaje ON Ticket(ID_Viaje);
    PRINT 'Índice IX_Ticket_ID_Viaje creado.';
END
GO

-- Índice para buscar por cédula del chofer (búsqueda frecuente)
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Chofer_Cedula')
BEGIN
    CREATE INDEX IX_Chofer_Cedula ON Chofer(Cedula);
    PRINT 'Índice IX_Chofer_Cedula creado.';
END
GO


SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Usuario';