-- Создаем базу данных University
--CREATE DATABASE University;
--GO

USE University;
GO

-- Создаем таблицы

-- Таблица стран
CREATE TABLE Countries (
    CountryID INT PRIMARY KEY IDENTITY,
    CountryName NVARCHAR(100) UNIQUE NOT NULL
);

-- Таблица студенческих групп
CREATE TABLE Groups (
    GroupID INT PRIMARY KEY IDENTITY,
    GroupName NVARCHAR(100) UNIQUE NOT NULL
);

-- Таблица предметов
CREATE TABLE Subjects (
    SubjectID INT PRIMARY KEY IDENTITY,
    SubjectName NVARCHAR(100) UNIQUE NOT NULL
);

-- Таблица студентов
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(100) NOT NULL,
    Patronymic NVARCHAR(100),
    Surname NVARCHAR(100) NOT NULL,
    BirthDate DATE NOT NULL,
	CountryID INT NOT NULL,
    City NVARCHAR(100),
    Email NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(20),
    GroupID INT NOT NULL,   -- id группы из таблицы Groups
    FOREIGN KEY (CountryID) REFERENCES Countries(CountryID),
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
);

-- Таблица оценок студентов
CREATE TABLE StudentGrades (
    GradeID INT PRIMARY KEY IDENTITY,
    StudentID INT NOT NULL, -- id студента из таблицы Students
    AverageGrade TINYINT CHECK (AverageGrade BETWEEN 1 AND 12),  -- Средняя оценка за год по 12-й шкале
    MinSubjectID INT NOT NULL, -- Предмет с минимальной оценкой
    MaxSubjectID INT NOT NULL, -- Предмет с максимальной оценкой
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (MinSubjectID) REFERENCES Subjects(SubjectID),
    FOREIGN KEY (MaxSubjectID) REFERENCES Subjects(SubjectID)
);




