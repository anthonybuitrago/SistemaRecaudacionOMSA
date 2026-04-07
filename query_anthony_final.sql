-- =============================================
-- SCRIPT MAESTRO DEFINITIVO: OMSA_Recaudacion (Versión Integrada)
-- Propósito: Limpieza total, creación de estructura 2024 y 
--            carga de datos de prueba completos (Elvis Seed Data).
-- =============================================

USE master;
GO

-- 1. ELIMINAR LA BASE DE DATOS SI YA EXISTE
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'OMSA_Recaudacion')
BEGIN
    ALTER DATABASE OMSA_Recaudacion SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE OMSA_Recaudacion;
END
GO

-- 2. CREAR LA BASE DE DATOS DESDE CERO
CREATE DATABASE OMSA_Recaudacion;
GO

USE OMSA_Recaudacion;
GO

-- =============================================
-- CREACIÓN DE TABLAS
-- =============================================

-- 3. TABLA: Usuario
CREATE TABLE Usuario (
    ID_Usuario      INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario   VARCHAR(50)  NOT NULL UNIQUE,
    Contrasena      VARCHAR(255) NOT NULL,
    Rol             VARCHAR(30)  NOT NULL DEFAULT 'Operador',
    FechaCreacion   DATETIME     NOT NULL DEFAULT GETDATE(),
    Activo          BIT          NOT NULL DEFAULT 1
);

-- 4. TABLA: Ruta
CREATE TABLE Ruta (
    ID_Ruta         INT IDENTITY(1,1) PRIMARY KEY,
    NombreRuta      VARCHAR(100) NOT NULL,
    Tarifa          DECIMAL(10,2) NOT NULL DEFAULT 25.00,
    TiempoMinutos   INT NOT NULL DEFAULT 0,
    DistanciaKM     DECIMAL(10,2) NOT NULL DEFAULT 0,
    Estado          VARCHAR(20) NOT NULL DEFAULT 'Activo'
);

-- 5. TABLA: Vehiculo
CREATE TABLE Vehiculo (
    ID_Vehiculo     INT IDENTITY(1,1) PRIMARY KEY,
    Ficha           VARCHAR(50) NOT NULL UNIQUE,
    Placa           VARCHAR(50) NOT NULL UNIQUE,
    Modelo          VARCHAR(100) NULL,
    Capacidad       INT NOT NULL,
    Estado          VARCHAR(20) NOT NULL DEFAULT 'Activo'
);

-- 6. TABLA: Chofer
CREATE TABLE Chofer (
    ID_Chofer       INT IDENTITY(1,1) PRIMARY KEY,
    Cedula          VARCHAR(20)  NOT NULL UNIQUE,
    NombreCompleto  VARCHAR(100) NOT NULL,
    NumeroLicencia  VARCHAR(50)  NOT NULL UNIQUE,
    Telefono        VARCHAR(20)  NULL,
    Estado          VARCHAR(20)  NOT NULL DEFAULT 'Activo',
    FechaIngreso    DATE         NOT NULL DEFAULT CAST(GETDATE() AS DATE)
);

-- 7. TABLA: Viaje
CREATE TABLE Viaje (
    ID_Viaje    INT IDENTITY(1,1) PRIMARY KEY,
    ID_Ruta     INT NOT NULL,
    ID_Chofer   INT NOT NULL,
    ID_Vehiculo INT NOT NULL,
    FechaViaje  DATETIME NOT NULL DEFAULT GETDATE(),
    Estado      VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT FK_Viaje_Ruta FOREIGN KEY (ID_Ruta) REFERENCES Ruta(ID_Ruta),
    CONSTRAINT FK_Viaje_Chofer FOREIGN KEY (ID_Chofer) REFERENCES Chofer(ID_Chofer),
    CONSTRAINT FK_Viaje_Vehiculo FOREIGN KEY (ID_Vehiculo) REFERENCES Vehiculo(ID_Vehiculo)
);

-- 8. TABLA: Ticket
CREATE TABLE Ticket (
    ID_Ticket       INT IDENTITY(1,1) PRIMARY KEY,
    ID_Viaje        INT NOT NULL,
    HoraEmision     DATETIME NOT NULL DEFAULT GETDATE(),
    MontoPagado     DECIMAL(10,2) NOT NULL,
    Estado          VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT FK_Ticket_Viaje FOREIGN KEY (ID_Viaje) REFERENCES Viaje(ID_Viaje)
);

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS
-- =============================================

GO
CREATE PROCEDURE SP_Dashboard_Totales
AS
BEGIN
    SELECT 
        (SELECT ISNULL(SUM(MontoPagado), 0) FROM Ticket) AS RecaudacionHoy,
        (SELECT COUNT(*) FROM Ticket) AS TicketsVendidosHoy,
        (SELECT COUNT(*) FROM Viaje WHERE Estado = 'Activo') AS ViajesActivos,
        (SELECT COUNT(*) FROM Vehiculo) AS TotalVehiculos
END
GO

-- =============================================
-- CARGA DE DATOS DE PRUEBA (ELVIS SEED DATA)
-- =============================================

-- Usuarios
INSERT INTO Usuario (NombreUsuario, Contrasena, Rol) VALUES ('admin', 'Admin123', 'Administrador');

-- Rutas de Elvis (Añadimos tiempos y distancias lógicas)
INSERT INTO Ruta (NombreRuta, Tarifa, TiempoMinutos, DistanciaKM) VALUES 
('John F. Kennedy', 25.00, 75, 18.5),
('Juan Bosch', 25.00, 60, 14.2),
('La Barquita', 25.00, 45, 10.0),
('Máximo Gómez', 25.00, 55, 12.8),
('Naco', 25.00, 30, 7.5),
('Simón Bolívar', 25.00, 40, 9.0),
('Los Ríos', 25.00, 50, 11.5),
('27 de Febrero', 25.00, 90, 22.0),
('Abraham Lincoln', 25.00, 35, 8.2),
('Alcarrizos', 25.00, 110, 28.5),
('Charles de Gaulle', 25.00, 85, 20.3),
('Independencia', 25.00, 70, 16.0);

-- Vehículos de Elvis (Añadimos Modelos)
INSERT INTO Vehiculo (Ficha, Placa, Modelo, Capacidad) VALUES
('OMSA-MB-001', 'A234501', 'Mercedes-Benz O500', 45),
('OMSA-MB-002', 'A234502', 'Mercedes-Benz O500', 45),
('OMSA-MB-003', 'A234503', 'Mercedes-Benz O500', 45),
('OMSA-VV-001', 'B567801', 'Volvo B7R', 50),
('OMSA-VV-002', 'B567802', 'Volvo B7R', 50),
('OMSA-VV-003', 'B567803', 'Volvo B7R', 50),
('OMSA-ART-001', 'C890101', 'Marcopolo Articulado', 220),
('OMSA-ART-002', 'C890102', 'Marcopolo Articulado', 220),
('OMSA-ART-003', 'C890103', 'Marcopolo Articulado', 220);

-- Choferes de Elvis (Añadimos Teléfonos ficticios)
INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia, Telefono) VALUES
('1234', 'Antony Buitrago', '3', '809-555-0001'),
('4567', 'Elvis Baez', '5', '809-555-0002'),
('8910', 'Rusember Areche', '4', '809-555-0003'),
('1112', 'Luis Eduardo', '2', '809-555-0004');

-- Viajes de prueba (Usamos IDs que sabemos que existen)
INSERT INTO Viaje (ID_Ruta, ID_Chofer, ID_Vehiculo, FechaViaje, Estado) VALUES
(1, 1, 1, GETDATE(), 'Activo'),
(2, 2, 2, GETDATE(), 'Activo'),
(3, 3, 3, GETDATE(), 'Activo');

-- Tickets de prueba
INSERT INTO Ticket (ID_Viaje, MontoPagado, Estado) VALUES 
(1, 25.00, 'Activo'), (1, 25.00, 'Activo'), (1, 25.00, 'Activo'),
(2, 25.00, 'Activo'), (2, 25.00, 'Activo');

-- Índices
CREATE INDEX IX_Viaje_FechaViaje ON Viaje(FechaViaje);
CREATE INDEX IX_Chofer_Cedula ON Chofer(Cedula);
GO

PRINT '¡Base de datos OMSA_Recaudacion creada y restaurada con datos integrados!';