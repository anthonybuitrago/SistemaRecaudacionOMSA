-- =============================================
-- SCRIPT MAESTRO DEFINITIVO: OMSA_Recaudacion
-- Propósito: Limpieza total y creación de estructura 2024
-- =============================================

USE master;
GO

-- 1. ELIMINAR LA BASE DE DATOS SI YA EXISTE (Para evitar errores de "Object already exists")
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'OMSA_Recaudacion')
BEGIN
    -- Forzamos el cierre de cualquier conexión activa para poder borrarla
    ALTER DATABASE OMSA_Recaudacion SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE OMSA_Recaudacion;
END
GO

-- 2. CREAR LA BASE DE DATOS DESDE CERO
CREATE DATABASE OMSA_Recaudacion;
GO

USE OMSA_Recaudacion;
GO

-- 3. TABLA: Usuario (Acceso al sistema)
CREATE TABLE Usuario (
    ID_Usuario      INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario   VARCHAR(50)  NOT NULL UNIQUE,
    Contrasena      VARCHAR(255) NOT NULL,
    Rol             VARCHAR(30)  NOT NULL DEFAULT 'Operador',
    FechaCreacion   DATETIME     NOT NULL DEFAULT GETDATE(),
    Activo          BIT          NOT NULL DEFAULT 1
);

-- 4. TABLA: Ruta (Actualizada con Tiempo y Distancia)
CREATE TABLE Ruta (
    ID_Ruta         INT IDENTITY(1,1) PRIMARY KEY,
    NombreRuta      VARCHAR(100) NOT NULL,
    Tarifa          DECIMAL(10,2) NOT NULL DEFAULT 15.00,
    TiempoMinutos   INT NOT NULL DEFAULT 0,  -- Dato de gestión
    DistanciaKM     DECIMAL(10,2) NOT NULL DEFAULT 0, -- Dato de gestión
    Estado          VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT CK_Ruta_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);

-- 5. TABLA: Vehiculo (Actualizada con Modelo y Estado)
CREATE TABLE Vehiculo (
    ID_Vehiculo     INT IDENTITY(1,1) PRIMARY KEY,
    Ficha           VARCHAR(50) NOT NULL UNIQUE,
    Placa           VARCHAR(50) NOT NULL UNIQUE,
    Modelo          VARCHAR(100) NULL,
    Capacidad       INT NOT NULL,
    Estado          VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT CK_Vehiculo_Estado CHECK (Estado IN ('Activo', 'Inactivo', 'Mantenimiento'))
);

-- 6. TABLA: Chofer (Actualizada con Estado y Teléfono)
CREATE TABLE Chofer (
    ID_Chofer       INT IDENTITY(1,1) PRIMARY KEY,
    Cedula          VARCHAR(20)  NOT NULL UNIQUE,
    NombreCompleto  VARCHAR(100) NOT NULL,
    NumeroLicencia  VARCHAR(50)  NOT NULL UNIQUE,
    Telefono        VARCHAR(20)  NULL,
    Estado          VARCHAR(20)  NOT NULL DEFAULT 'Activo',
    FechaIngreso    DATE         NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    CONSTRAINT CK_Chofer_Estado CHECK (Estado IN ('Activo', 'Inactivo', 'Suspendido'))
);

-- 7. TABLA: Viaje (Transaccional - Registra cada salida)
CREATE TABLE Viaje (
    ID_Viaje    INT IDENTITY(1,1) PRIMARY KEY,
    ID_Ruta     INT NOT NULL,
    ID_Chofer   INT NOT NULL,
    ID_Vehiculo INT NOT NULL,
    FechaViaje  DATETIME NOT NULL DEFAULT GETDATE(),
    Estado      VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT CK_Viaje_Estado CHECK (Estado IN ('Activo', 'Finalizado', 'Cancelado')),
    CONSTRAINT FK_Viaje_Ruta FOREIGN KEY (ID_Ruta) REFERENCES Ruta(ID_Ruta),
    CONSTRAINT FK_Viaje_Chofer FOREIGN KEY (ID_Chofer) REFERENCES Chofer(ID_Chofer),
    CONSTRAINT FK_Viaje_Vehiculo FOREIGN KEY (ID_Vehiculo) REFERENCES Vehiculo(ID_Vehiculo)
);

-- 8. TABLA: Ticket (Recaudación por viaje)
CREATE TABLE Ticket (
    ID_Ticket       INT IDENTITY(1,1) PRIMARY KEY,
    ID_Viaje        INT NOT NULL,
    HoraEmision     DATETIME NOT NULL DEFAULT GETDATE(),
    MontoPagado     DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Ticket_Viaje FOREIGN KEY (ID_Viaje) REFERENCES Viaje(ID_Viaje)
);

-- =============================================
-- 9. CARGA DE DATOS INICIALES (Para probar el programa)
-- =============================================

-- Usuario para el Login
INSERT INTO Usuario (NombreUsuario, Contrasena, Rol) 
VALUES ('admin', 'Admin123', 'Administrador');

-- Rutas de ejemplo
INSERT INTO Ruta (NombreRuta, Tarifa, TiempoMinutos, DistanciaKM) VALUES 
('27 de Febrero', 15.00, 85, 22.5),
('John F. Kennedy', 15.00, 75, 19.8),
('Winston Churchill', 15.00, 45, 11.2);

-- Vehículos de ejemplo
INSERT INTO Vehiculo (Ficha, Placa, Modelo, Capacidad) VALUES
('OMSA-MB-001', 'A234501', 'Mercedes-Benz O500', 45),
('OMSA-VV-001', 'B567801', 'Volvo B7R', 50);

-- Choferes de ejemplo
INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia, Telefono) VALUES
('001-0000000-1', 'Juan Pérez', 'LC-10293', '809-555-0101'),
('001-0000000-2', 'Pedro Martínez', 'LC-55442', '829-555-0202');

-- Índices para velocidad
CREATE INDEX IX_Viaje_FechaViaje ON Viaje(FechaViaje);
CREATE INDEX IX_Chofer_Cedula ON Chofer(Cedula);
GO

PRINT '¡Base de datos OMSA_Recaudacion creada desde cero sin errores!';