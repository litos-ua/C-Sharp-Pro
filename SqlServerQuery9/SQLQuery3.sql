USE Hospital;


-- 1. Выводится все содержимое таблицы палат (Wards).
PRINT 'Выводится содержимое таблицы палат (Wards)';

SELECT * 
FROM [dbo].[Wards];

-- 2. Выводятся фамилии (Surname) и телефоны (Phone) всех докторов (Doctors).
SELECT [Surname], [Phone] 
FROM [dbo].[Doctors];

-- 3. Выводятся таблицы палат все этажи без повторений, где размещаются палаты.
SELECT DISTINCT [Floor] 
FROM [dbo].[Wards];

-- 4. Выводятся названия заболеваний (Diseases.Name) под названием «Name of Disease» и степень их тяжести под названием «Severity of Disease».
SELECT [Name] AS "Name of Disease", [Severity] AS "Severity of Disease" 
FROM [dbo].[Diseases];

-- 5. Применяем выражение FROM дл таблиц отделений (d), палат (w), докторов (doc).
SELECT 
    d.[Name] AS DepartmentName,
    w.[Name] AS WardName,
    doc.[Surname] AS DoctorSurname,
    d.[Id] AS MatchingId
FROM 
    [dbo].[Departments] AS d
    JOIN [dbo].[Wards] AS w ON d.[Id] = w.[Id]
    JOIN [dbo].[Doctors] AS doc ON d.[Id] = doc.[Id];
--запрос выводит список отделений, палат и докторов, у которых совпадает идентификатор Id

-- 6. Выводим названия отделений (Departments.Name), которые находятся в корпусе 5 с фондом финансирования (Departments.Financing) меньшим, чем 30000.
SELECT [Name] 
FROM [dbo].[Departments] 
WHERE [Building] = 5 AND [Financing] < 30000;

-- 7. Выводим названия отделений, которые находятся в корпусе 3 с фондом финансирования в диапазоне от 12000 до 15000.
SELECT [Name] 
FROM [dbo].[Departments] 
WHERE [Building] = 3 AND [Financing] BETWEEN 12000 AND 15000;

-- 8. Выводим названия палат, которые находятся в корпусах 4 и 5 и при этом на 1-м этаже.
SELECT [Name] 
FROM [dbo].[Wards] 
WHERE [Building] IN (4, 5) AND [Floor] = 1;

-- 9. Выводим названия, корпуса и фонды финансирования отделений, которые находятся в корпусах 3 или 5 
    --и имеют фонд финансирования меньше 11000 или больше 25000.
SELECT [Name], [Building], [Financing] 
FROM [dbo].[Departments] 
WHERE ([Building] = 3 OR [Building] = 5) AND ([Financing] < 11000 OR [Financing] > 25000);


-- 10. Выводим фамилии докторов (Doctors.Surname), зарплата (сумма ставки и надбавки) которых превышает 1500.
SELECT [Surname] 
FROM [dbo].[Doctors] 
WHERE [Salary] + ([Salary] * [AllowancePercent] / 100) > 1500;

-- 11. Выводим фамилии докторов (Doctors.Surname), у которых половина зарплаты превышает трехразовую надбавку.
SELECT [Surname] 
FROM [dbo].[Doctors] 
WHERE [Salary] / 2 > 3 * ([Salary] * [AllowancePercent] / 100);

-- 12. Выводим названия обследований (Examinations.Name) без повторений, которые проводятся в первые три дня недели с 12:00 до 15:00.
SELECT DISTINCT [Name] 
FROM [dbo].[Examinations] 
WHERE [DayOfWeek] BETWEEN 1 AND 3 
  AND [StartTime] >= '12:00' 
  AND [EndTime] <= '15:00';

-- 13. Выводим названия отделений (Departments.Name) и номера отделений (Departments.Id), которые находятся в корпусах 1, 3 или 5.
SELECT [Name], [Id] 
FROM [dbo].[Departments] 
WHERE [Building] IN (1, 3, 5);

-- 14. Выводим названия заболеваний всех степеней тяжести, кроме 1-го и 2-го.
SELECT [Name] 
FROM [dbo].[Diseases] 
WHERE [Severity] NOT IN (1, 2);

-- 15. Выводим названия отделений, которые не находятся в 1-м или 3-м корпусе.
SELECT [Name] 
FROM [dbo].[Departments] 
WHERE [Building] NOT IN (1, 3);

-- 16. Выводим названия отделений, которые находятся в 1-м или 3-м корпусе.
SELECT [Name] 
FROM [dbo].[Departments] 
WHERE [Building] IN (1, 3);

-- 17. Выводим фамилии докторов, которые начинаются с буквы «N».
SELECT [Surname] 
FROM [dbo].[Doctors] 
WHERE [Surname] LIKE 'N%';

