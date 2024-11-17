USE BarberShop; 
GO

-- 1. Функция возвращает ФИО всех парикмахеров салона
CREATE FUNCTION dbo.GetAllBarbersSurNamePatr()
RETURNS TABLE
AS
RETURN (
    SELECT CONCAT(Surname, ' ', FirstName, ' ', ISNULL(Patronymic, '')) AS AllBarbersFullName
    FROM Barbers
);
GO



-- 2. Функция возвращает информацию о всех сеньор-барберах ???
CREATE FUNCTION dbo.GetSeniorBarbers()
RETURNS TABLE
AS
RETURN (
    SELECT *
    FROM Barbers
    WHERE Position = 'Senior'
);
GO

-- 3. Процедура возвращает информацию обо всех барберах, которые могут предоставить услугу стрижки бороды
CREATE PROCEDURE dbo.GetBarbersByTrimBeard
AS
BEGIN
    SELECT DISTINCT b.*
    FROM Barbers b
    INNER JOIN BarberServices bs ON b.BarberId = bs.BarberId
    INNER JOIN Services s ON bs.ServiceId = s.ServiceId
    WHERE s.ServiceName = 'Men Beard Trim';
END;
GO

-- 4. Процедура возвращает информацию о всех парикмахерах, которые могут предоставить конкретную услугу
CREATE PROCEDURE dbo.GetBarbersBySpecificService
    @ServiceName NVARCHAR(100)
AS
BEGIN
    SELECT DISTINCT b.*
    FROM Barbers b
    INNER JOIN BarberServices bs ON b.BarberId = bs.BarberId
    INNER JOIN Services s ON bs.ServiceId = s.ServiceId
    WHERE s.ServiceName = @ServiceName;
END;
GO

-- 5. Процедура возвращает информацию о всех парикмахерах, работающих свыше указанного количества лет
CREATE PROCEDURE dbo.GetBarbersByExperience
    @Years INT
AS
BEGIN
    SELECT *
    FROM Barbers
    WHERE DATEDIFF(YEAR, HiringDate, GETDATE()) > @Years;
END;
GO

-- 6. Процедура возвращает количество сеньор-барберов и количество джуниор-барберов

CREATE PROCEDURE dbo.GetBarberJAndSCounts
AS
BEGIN
    SELECT 
        SUM(CASE WHEN Position = 'Senior' THEN 1 ELSE 0 END) AS SeniorCount,
        SUM(CASE WHEN Position = 'Junior' THEN 1 ELSE 0 END) AS JuniorCount
    FROM Barbers;
END;
GO

-- 7. Процедура возвращает информацию о постоянных клиентах
CREATE PROCEDURE dbo.GetLoyalClients
    @VisitCount INT
AS
BEGIN
    SELECT c.*
    FROM Clients c
    INNER JOIN Appointments a ON c.ClientId = a.ClientId
    GROUP BY c.ClientId, c.FirstName, c.Surname, c.Patronymic, c.PhoneNumber, c.Email
    HAVING COUNT(a.AppointmentId) >= @VisitCount;
END;
GO

-- 8. Триггер запрещает удалять информацию о чиф-барбере, если не добавлен второй чиф-барбер
CREATE TRIGGER trg_PreventChiefBarberDeletion
ON Barbers
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Barbers
        WHERE Position = 'Chief'
    ) AND (
        SELECT COUNT(*)
        FROM Barbers
        WHERE Position = 'Chief'
    ) <= 1
    BEGIN
        RAISERROR('Cannot delete the last Chief Barber!', 16, 1);
        ROLLBACK;
    END
    ELSE
    BEGIN
        DELETE FROM Barbers
        WHERE BarberId IN (SELECT BarberId FROM deleted);
    END
END;
GO


-- 9. Триггер запрещает добавление барберов младше 21 года
CREATE TRIGGER trg_PreventYoungBarberInsertion
ON Barbers
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE DATEDIFF(YEAR, DateOfBirth, GETDATE()) < 21
    )
    BEGIN
        RAISERROR('Barbers under 21 years old cannot be added!', 16, 1);
        ROLLBACK;
    END
    ELSE
    BEGIN
        INSERT INTO Barbers (FirstName, Surname, Patronymic, Gender, PhoneNumber, Email, DateOfBirth, HiringDate, Position, RatingsAverage)
        SELECT FirstName, Surname, Patronymic, Gender, PhoneNumber, Email, DateOfBirth, HiringDate, Position, RatingsAverage
        FROM inserted;
    END
END;
GO




-- 1. -возвращает ФИО всех парикмахеров салона
SELECT * FROM dbo.GetAllBarbersSurNamePatr();

-- 2. -возвращает информацию о всех сеньор-барберах
SELECT * FROM dbo.GetSeniorBarbers();

-- 3. -возвращает информацию обо всех парикмахерах, которые могут предоставить услугу стрижки бороды ('Men Beard Trim')
EXEC dbo.GetBarbersByTrimBeard;

-- 4. -возвращает информацию о всех парикмахерах, которые могут предоставить услугу 'Women Hair Coloring'
EXEC dbo.GetBarbersBySpecificService @ServiceName = 'Women Hair Coloring';

-- 5. -возвращает информацию о всех парикмахерах, работающих свыше 3-х лет
EXEC dbo.GetBarbersByExperience @Years = 3;

-- 6. -возвращает количество сеньор-барберов и количество джуниор-барберов
EXEC dbo.GetBarberJAndSCounts;

-- 7. -возвращает информацию о постоянных клиентах
EXEC dbo.GetLoyalClients @VisitCount = 1;

-- 8. демонстрируем работу триггера
DELETE FROM Barbers WHERE Position = 'Chief Barber';

-- 9. демонстрируем работу триггера
INSERT INTO Barbers (FirstName, Surname, Patronymic, Gender, PhoneNumber, Email, DateOfBirth, HiringDate, Position)
VALUES ('Yaroslav', 'Lukashevich', 'Andreevich', 'Male', '+380973222567', 'yaroslav.lukashevich@barbershop.ua', '2007-07-06', '2022-09-01', 'Junior Barber');

