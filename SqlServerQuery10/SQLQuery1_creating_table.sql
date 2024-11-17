-- Создание базы данных Hospital2
--CREATE DATABASE BarberShop;
--GO

USE BarberShop;

--  Таблица Barbers
CREATE TABLE Barbers (
    BarberId INT IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Patronymic NVARCHAR(50) NULL,
    Gender NVARCHAR(10) NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NULL,
    DateOfBirth DATE NULL,
    HiringDate DATE NOT NULL,
    Position NVARCHAR(20) NOT NULL,
    RatingsAverage DECIMAL(3,2) NULL DEFAULT 0,
    CONSTRAINT PK_Barbers_BarberId PRIMARY KEY (BarberId),
    CONSTRAINT UQ_Barbers_PhoneNumber UNIQUE (PhoneNumber),
    CONSTRAINT UQ_Barbers_Email UNIQUE (Email),
    CONSTRAINT CHK_Barbers_Age CHECK (DATEDIFF(YEAR, DateOfBirth, GETDATE()) >= 21)
);
-- Таблица Services
CREATE TABLE Services (
    ServiceId INT IDENTITY(1,1),
    ServiceName NVARCHAR(100) NOT NULL,
    DurationMinutes INT NOT NULL,
    Price DECIMAL(8,2) NOT NULL,
    CONSTRAINT PK_Services_ServiceId PRIMARY KEY (ServiceId)
);

-- Таблица BarberServices
CREATE TABLE BarberServices (
    BarberServiceId INT IDENTITY(1,1),
    BarberId INT NOT NULL,
    ServiceId INT NOT NULL,
    CONSTRAINT PK_BarberServices_BarberServiceId PRIMARY KEY (BarberServiceId),
    CONSTRAINT FK_BarberServices_BarberId FOREIGN KEY (BarberId) REFERENCES Barbers(BarberId),
    CONSTRAINT FK_BarberServices_ServiceId FOREIGN KEY (ServiceId) REFERENCES Services(ServiceId),
    CONSTRAINT UQ_BarberServices_BarberId_ServiceId UNIQUE (BarberId, ServiceId)
);

-- Таблица Schedules
CREATE TABLE Schedules (
    ScheduleId INT IDENTITY(1,1),
    BarberId INT NOT NULL,
    DayOfWeek NVARCHAR(20) NOT NULL,
    AvailableTimeStart TIME NOT NULL,
    AvailableTimeEnd TIME NOT NULL,
    CONSTRAINT PK_Schedules_ScheduleId PRIMARY KEY (ScheduleId),
    CONSTRAINT FK_Schedules_BarberId FOREIGN KEY (BarberId) REFERENCES Barbers(BarberId),
    CONSTRAINT CHK_Schedules_Time CHECK (AvailableTimeStart < AvailableTimeEnd)
);

-- Таблица Clients
CREATE TABLE Clients (
    ClientId INT IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Patronymic NVARCHAR(50) NULL,
    PhoneNumber NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NULL,
    CONSTRAINT PK_Clients_ClientId PRIMARY KEY (ClientId),
    CONSTRAINT UQ_Clients_PhoneNumber UNIQUE (PhoneNumber),
    CONSTRAINT UQ_Clients_Email UNIQUE (Email)
);

-- Таблица Appointments
CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1),
    ClientId INT NOT NULL,
    BarberId INT NOT NULL,
    AppointmentDate DATE NOT NULL,
    AppointmentTime TIME NOT NULL,
    TotalPrice DECIMAL(8,2) NOT NULL,
	Status BIT NOT NULL DEFAULT 0, -- 0 = незавершённая, 1 = завершённая
    CONSTRAINT PK_Appointments_AppointmentId PRIMARY KEY (AppointmentId),
    CONSTRAINT FK_Appointments_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),
    CONSTRAINT FK_Appointments_BarberId FOREIGN KEY (BarberId) REFERENCES Barbers(BarberId)
);

-- Таблица Feedbacks
CREATE TABLE Feedbacks (
    FeedbackId INT IDENTITY(1,1),
    ClientId INT NOT NULL,
    BarberId INT NOT NULL,
    Rating NVARCHAR(10) NOT NULL,
    Comment NVARCHAR(MAX) NULL,
    CONSTRAINT PK_Feedbacks_FeedbackId PRIMARY KEY (FeedbackId),
    CONSTRAINT FK_Feedbacks_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),
    CONSTRAINT FK_Feedbacks_BarberId FOREIGN KEY (BarberId) REFERENCES Barbers(BarberId)
);
