USE BarberShop; 
GO

CREATE PROCEDURE dbo.AddBarberWithServices
    @FirstName NVARCHAR(50),
    @Surname NVARCHAR(50),
    @Patronymic NVARCHAR(50) = NULL,
    @Gender NVARCHAR(10),
    @PhoneNumber NVARCHAR(15),
    @Email NVARCHAR(100) = NULL,
    @DateOfBirth DATE,
    @HiringDate DATE,
    @Position NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    -- Вставляем нового парикмахера
    INSERT INTO dbo.Barbers (FirstName, Surname, Patronymic, Gender, PhoneNumber, Email, DateOfBirth, HiringDate, Position)
    VALUES (@FirstName, @Surname, @Patronymic, @Gender, @PhoneNumber, @Email, @DateOfBirth, @HiringDate, @Position);

    -- Получаем ID нового парикмахера
    DECLARE @BarberId INT = SCOPE_IDENTITY();

    -- Генерация услуг
    INSERT INTO dbo.BarberServices (BarberId, ServiceId)
    SELECT @BarberId, ServiceId
    FROM dbo.Services
    WHERE
        (
            -- Chief Barber и Senior Barber могут предоставлять все услуги
            @Position IN ('Chief Barber', 'Senior Barber')
            OR
            -- Junior Barber: ограничения по услугам
            (
                @Position = 'Junior Barber'
                AND
                (
                    (ServiceName LIKE '%woman%' AND @Gender = 'Female') -- женщинам Junior Barber доступны только женские услуги 
                    OR
                    (ServiceName LIKE '%man%' AND @Gender = 'Male') -- мужчинам Junior Barber доступны только мужские услуги 
                    OR
                    ServiceId = 1 -- "Детская стрижка" доступна всем
                )
                AND ServiceId NOT IN ( -- Исключить недоступные услуги для юниоров
                    CASE 
                        WHEN @Gender = 'Female' THEN 2 -- "Women Scalp Massage"
                        WHEN @Gender = 'Male' THEN 4 -- "Men Scalp Massage"
                    END,
                    3 -- "Свадебная укладка волос"
                )
            )
        )
        OR
        -- Услуги "Классическое бритье" и "Коррекция бровей" доступны только Chief и Senior
        (ServiceId IN (5, 6) AND @Position IN ('Chief Barber', 'Senior Barber'))
        AND NOT EXISTS (
            SELECT 1
            FROM dbo.BarberServices
            WHERE BarberId = @BarberId AND ServiceId = dbo.Services.ServiceId
        );
END;
GO

