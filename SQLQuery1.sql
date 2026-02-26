CREATE DATABASE OMSA_Recaudacion;
GO

USE OMSA_Recaudacion;
GO

CREATE TABLE Ruta (
    ID_Ruta INT IDENTITY(1,1) PRIMARY KEY,
    NombreRuta VARCHAR(100) NOT NULL,
    TarifaPasaje DECIMAL(10,2) NOT NULL
);

CREATE TABLE Vehiculo (
    ID_Vehiculo INT IDENTITY(1,1) PRIMARY KEY,
    Ficha VARCHAR(50) NOT NULL,
    Placa VARCHAR(50) NOT NULL,
    Capacidad INT NOT NULL
);

CREATE TABLE Chofer (
    ID_Chofer INT IDENTITY(1,1) PRIMARY KEY,
    Cedula VARCHAR(20) NOT NULL,
    NombreCompleto VARCHAR(100) NOT NULL,
    NumeroLicencia VARCHAR(50) NOT NULL
);

CREATE TABLE Viaje (
    ID_Viaje INT IDENTITY(1,1) PRIMARY KEY,
    ID_Ruta INT NOT NULL,
    ID_Chofer INT NOT NULL,
    ID_Vehiculo INT NOT NULL,
    FechaViaje DATETIME NOT NULL,
    Estado VARCHAR(20) DEFAULT 'Activo',
    FOREIGN KEY (ID_Ruta) REFERENCES Ruta(ID_Ruta),
    FOREIGN KEY (ID_Chofer) REFERENCES Chofer(ID_Chofer),
    FOREIGN KEY (ID_Vehiculo) REFERENCES Vehiculo(ID_Vehiculo)
);

CREATE TABLE Ticket (
    ID_Ticket INT IDENTITY(1,1) PRIMARY KEY,
    ID_Viaje INT NOT NULL,
    HoraEmision DATETIME NOT NULL,
    MontoPagado DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Viaje) REFERENCES Viaje(ID_Viaje)
);