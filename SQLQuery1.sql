-- =============================================
-- 1. CREACIÓN DE LA BASE DE DATOS
-- =============================================
-- Verifica la existencia de la base de datos para evitar errores de duplicidad al ejecutar el script
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'OMSA_Recaudacion')
BEGIN
    CREATE DATABASE OMSA_Recaudacion;
END
GO

USE OMSA_Recaudacion;
GO

-- =============================================
-- 2. TABLA DE RUTAS
-- =============================================
-- Almacena los trayectos disponibles y el costo oficial del pasaje
CREATE TABLE Ruta (
    ID_Ruta INT IDENTITY(1,1) PRIMARY KEY, -- Identificador automático (PK)
    NombreRuta VARCHAR(100) NOT NULL,       -- Nombre descriptivo de la ruta
    TarifaPasaje DECIMAL(10,2) NOT NULL     -- Valor monetario del pasaje (RD$)
);

-- =============================================
-- 3. TABLA DE VEHÍCULOS
-- =============================================
-- Control físico de los autobuses asignados a la flota
CREATE TABLE Vehiculo (
    ID_Vehiculo INT IDENTITY(1,1) PRIMARY KEY,
    Ficha VARCHAR(50) NOT NULL UNIQUE, -- Identificador interno único de la OMSA
    Placa VARCHAR(50) NOT NULL UNIQUE, -- Registro legal único del vehículo
    Capacidad INT NOT NULL             -- Cantidad máxima de pasajeros permitidos
);

-- =============================================
-- 4. TABLA DE CHOFERES
-- =============================================
-- Registro del personal operativo responsable de los viajes
CREATE TABLE Chofer (
    ID_Chofer INT IDENTITY(1,1) PRIMARY KEY,
    Cedula VARCHAR(20) NOT NULL UNIQUE,         -- Documento de identidad (Sin duplicados)
    NombreCompleto VARCHAR(100) NOT NULL,       -- Nombre y apellido del empleado
    NumeroLicencia VARCHAR(50) NOT NULL UNIQUE  -- Registro de conducir obligatorio y único
);

-- =============================================
-- 5. TABLA DE VIAJES (TABLA TRANSACCIONAL)
-- =============================================
-- Relaciona las entidades principales para registrar la operación diaria
CREATE TABLE Viaje (
    ID_Viaje INT IDENTITY(1,1) PRIMARY KEY,
    ID_Ruta INT NOT NULL,     -- Referencia a la ruta realizada
    ID_Chofer INT NOT NULL,   -- Referencia al chofer asignado
    ID_Vehiculo INT NOT NULL, -- Referencia al autobús utilizado
    FechaViaje DATETIME NOT NULL,
    Estado VARCHAR(20) DEFAULT 'Activo', -- Control de flujo (Activo, Finalizado, Cancelado)
    
    -- Definición de Relaciones (Integridad Referencial)
    -- Aseguran que no se asigne un ID que no exista en las tablas maestras
    CONSTRAINT FK_Viaje_Ruta FOREIGN KEY (ID_Ruta) REFERENCES Ruta(ID_Ruta),
    CONSTRAINT FK_Viaje_Chofer FOREIGN KEY (ID_Chofer) REFERENCES Chofer(ID_Chofer),
    CONSTRAINT FK_Viaje_Vehiculo FOREIGN KEY (ID_Vehiculo) REFERENCES Vehiculo(ID_Vehiculo)
);

-- =============================================
-- 6. TABLA DE TICKETS (DETALLE DE RECAUDACIÓN)
-- =============================================
-- Registro individual de cada cobro realizado durante un viaje específico
CREATE TABLE Ticket (
    ID_Ticket INT IDENTITY(1,1) PRIMARY KEY,
    ID_Viaje INT NOT NULL,           -- Vincula el ticket con un viaje específico
    HoraEmision DATETIME NOT NULL,   -- Momento exacto del cobro
    MontoPagado DECIMAL(10,2) NOT NULL, -- Valor recaudado en esa transacción
    
    -- Relación con Viaje: Si el viaje no existe, no se puede cobrar el ticket
    CONSTRAINT FK_Ticket_Viaje FOREIGN KEY (ID_Viaje) REFERENCES Viaje(ID_Viaje)
);