CREATE DATABASE Hospital;
GO

-- Временная задержка 5 секунд
WAITFOR DELAY '00:00:05';

USE Hospital;

-- 1.Таблица Departments
CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Financing MONEY NOT NULL DEFAULT 0 CHECK (Financing >= 0),
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> '')
);

-- 2.Таблица Diseases
CREATE TABLE Diseases (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
    Severity INT NOT NULL DEFAULT 1 CHECK (Severity >= 1)
);

-- 3.Таблица Doctors
CREATE TABLE Doctors (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name NVARCHAR(MAX) NOT NULL CHECK (Name <> ''),
	Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> ''),
    Phone CHAR(10) NULL,
    Salary MONEY NOT NULL CHECK (Salary > 0),
	AllowancePercent INT NOT NULL CHECK (AllowancePercent BETWEEN 0 AND 50)
);

-- 4.Таблица Examinations
CREATE TABLE Examinations (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
    DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 1 AND 7),
    StartTime TIME NOT NULL CHECK (StartTime BETWEEN '08:00' AND '18:00'),
    EndTime TIME NOT NULL,
	--значение времени окончания (EndTime) всегда позже времени начала (StartTime)
    CONSTRAINT CK_Examinations_EndTime CHECK (EndTime > StartTime) 
);

-- 5.Таблица Wards
CREATE TABLE Wards (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Floor INT NOT NULL CHECK (Floor >= 1),
    Name NVARCHAR(20) NOT NULL UNIQUE CHECK (Name <> '')
);
