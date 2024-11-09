USE University;
GO

--1.Отображает всю информацию из таблицы со студентами и оценками

SELECT Students.StudentID, Students.FirstName, Students.Patronymic, Students.Surname, Students.BirthDate, 
       Students.City, Students.Email, Students.Phone, 
       (SELECT CountryName FROM Countries WHERE Countries.CountryID = Students.CountryID) AS CountryName,
       (SELECT GroupName FROM Groups WHERE Groups.GroupID = Students.GroupID) AS GroupName,
       (SELECT AverageGrade FROM StudentGrades WHERE StudentGrades.StudentID = Students.StudentID) AS AverageGrade,
       (SELECT SubjectName FROM Subjects WHERE Subjects.SubjectID = 
           (SELECT MinSubjectID FROM StudentGrades WHERE StudentGrades.StudentID = Students.StudentID)) AS MinSubject,
       (SELECT SubjectName FROM Subjects WHERE Subjects.SubjectID = 
           (SELECT MaxSubjectID FROM StudentGrades WHERE StudentGrades.StudentID = Students.StudentID)) AS MaxSubject
FROM Students;

GO

-- Временная задержка 5 секунд
WAITFOR DELAY '00:00:05';

-- 2.Отображать ФИО всех студентов
SELECT Students.Surname, Students.FirstName, Students.Patronymic FROM Students;
GO

WAITFOR DELAY '00:00:05';

-- 3.Отображение всех средних оценок
SELECT StudentGrades.AverageGrade FROM StudentGrades;
GO

WAITFOR DELAY '00:00:05';

-- 4.Показываем ФИО всех студентов с минимальной оценкой, большей, чем указанная

SELECT Students.Surname, Students.Patronymic, Students.FirstName FROM Students
JOIN StudentGrades ON Students.StudentID = StudentGrades.StudentID
WHERE StudentGrades.AverageGrade > 7;


WAITFOR DELAY '00:00:05';

-- 5.Выводим страны откуда родом студенты
SELECT DISTINCT Countries.CountryName FROM Students
JOIN Countries ON Students.CountryID = Countries.CountryID;

WAITFOR DELAY '00:00:05';

--6.Показываем города студентов (названия городов уникальные (название выводится один раз))
SELECT DISTINCT Students.City FROM Students;

WAITFOR DELAY '00:00:05';

--7.Показываем названия групп (названия групп уникальные (название выводится один раз))
SELECT DISTINCT Groups.GroupName FROM Groups;
