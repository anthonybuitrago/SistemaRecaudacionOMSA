-- 1. Creación de la Base de Datos
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'OMSA_Recaudacion')
BEGIN
    CREATE DATABASE OMSA_Recaudacion;
END
GO

USE OMSA_Recaudacion;
GO

-- 2. Tabla de Rutas: Define los trayectos y sus costos
CREATE TABLE Ruta (
    ID_Ruta INT IDENTITY(1,1) PRIMARY KEY,
    NombreRuta VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255),
    TarifaPasaje DECIMAL(10,2) NOT NULL
);

-- 3. Tabla de Vehículos: Control de los autobuses físicos
CREATE TABLE Vehiculo (
    ID_Vehiculo INT IDENTITY(1,1) PRIMARY KEY,
    Ficha VARCHAR(50) NOT NULL UNIQUE, -- La ficha debe ser única por autobús
    Placa VARCHAR(50) NOT NULL UNIQUE, -- No puede haber dos buses con la misma placa
    Capacidad INT NOT NULL
);

-- 4. Tabla de Choferes: Datos del personal operativo
CREATE TABLE Chofer (
    ID_Chofer INT IDENTITY(1,1) PRIMARY KEY,
    Cedula VARCHAR(20) NOT NULL UNIQUE,         -- Evita duplicados de identidad
    NombreCompleto VARCHAR(100) NOT NULL,
    NumeroLicencia VARCHAR(50) NOT NULL UNIQUE  -- La licencia es personal e intransferible
);

-- 5. Tabla de Viajes: Relaciona chofer, ruta y vehículo en un tiempo dado
CREATE TABLE Viaje (
    ID_Viaje INT IDENTITY(1,1) PRIMARY KEY,
    ID_Ruta INT NOT NULL,
    ID_Chofer INT NOT NULL,
    ID_Vehiculo INT NOT NULL,
    FechaViaje DATETIME NOT NULL,
    Estado VARCHAR(20) DEFAULT 'Activo', -- Ej: Activo, Finalizado, Cancelado
    
    -- Llaves Foráneas (Relaciones)
    CONSTRAINT FK_Viaje_Ruta FOREIGN KEY (ID_Ruta) REFERENCES Ruta(ID_Ruta),
    CONSTRAINT FK_Viaje_Chofer FOREIGN KEY (ID_Chofer) REFERENCES Chofer(ID_Chofer),
    CONSTRAINT FK_Viaje_Vehiculo FOREIGN KEY (ID_Vehiculo) REFERENCES Vehiculo(ID_Vehiculo)
);

-- 6. Tabla de Tickets: Registro detallado de cada pasaje cobrado
CREATE TABLE Ticket (
    ID_Ticket INT IDENTITY(1,1) PRIMARY KEY,
    ID_Viaje INT NOT NULL,
    HoraEmision DATETIME NOT NULL,
    MontoPagado DECIMAL(10,2) NOT NULL,
    
    CONSTRAINT FK_Ticket_Viaje FOREIGN KEY (ID_Viaje) REFERENCES Viaje(ID_Viaje)
);