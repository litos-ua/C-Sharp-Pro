
USE BarberShop;

/*
--Генерация данных для таблицы Barbers

INSERT INTO Barbers (FirstName, Surname, Patronymic, Gender, PhoneNumber, Email, DateOfBirth, HiringDate, Position)
VALUES 
-- Chief Barber
('Jan', 'Kowalski', NULL, 'Male', '+48123456789', 'jan.kowalski@barbershop.pl', '1978-03-15', '2005-06-01', 'Chief Barber'),

-- Senior Barbers
('Oleksiy', 'Hrytsenko', 'Ivanovych', 'Male', '+380501234567', 'oleksiy.hrytsenko@barbershop.ua', '1986-10-21', '2015-04-10', 'Senior Barber'),
('Anka', 'Jovanovic', NULL, 'Female', '+385912345678', 'anka.jovanovic@barbershop.hr', '1983-05-17', '2013-02-20', 'Senior Barber'),
('Marta', 'Nowak', NULL, 'Female', '+48234567890', 'marta.nowak@barbershop.pl', '1989-07-05', '2018-08-15', 'Senior Barber'),

-- Junior Barbers
('Ihor', 'Tkachenko', 'Petrovych', 'Male', '+380671234567', 'ihor.tkachenko@barbershop.ua', '2001-09-12', '2022-09-01', 'Junior Barber'),
('Daryna', 'Shevchenko', 'Olehivna', 'Female', '+380731234567', 'daryna.shevchenko@barbershop.ua', '2003-01-23', '2023-01-10', 'Junior Barber'),
('Zofia', 'Wisniewska', NULL, 'Female', '+48123412345', 'zofia.wisniewska@barbershop.pl', '2000-06-30', '2022-05-12', 'Junior Barber'),
('Ivan', 'Kovalenko', 'Mykolaiovych', 'Male', '+380931234567', 'ivan.kovalenko@barbershop.ua', '1999-12-14', '2023-02-01', 'Junior Barber'),
('Lidija', 'Milic', NULL, 'Female', '+385991234567', 'lidija.milic@barbershop.hr', '2002-03-28', '2022-07-20', 'Junior Barber'),
('Barbara', 'Kowalczyk', NULL, 'Female', '+48456789012', 'barbara.kowalczyk@barbershop.pl', '2001-10-10', '2023-06-10', 'Junior Barber');


--Генерация данных для таблицы Services

INSERT INTO Services (ServiceName, DurationMinutes, Price)
VALUES 
('Men Haircut', 30, 200),
('Women Haircut', 45, 300),
('Men Beard Trim', 20, 150),
('Men Mustache Trim', 15, 100),
('Women Hair Styling', 60, 500),
('Kids Haircut', 30, 150),
('Eyebrows Correction', 20, 120),
('Men Head Shave', 25, 200),
('Women Hair Coloring', 60, 700),
('Men Hair Coloring', 40, 400),
('Women Perm', 50, 600),
('Women Hair Treatment', 40, 550),
(TotalPrice, 20, 100),
('Women Hair Wash', 25, 120),
('Men Scalp Massage', 30, 250),
('Women Scalp Massage', 30, 250),
('Bridal Hair Styling', 90, 700),
('Classic Shave', 30, 250);


--Генерация данных для таблицы Clients

INSERT INTO Clients (FirstName, Surname, Patronymic, PhoneNumber, Email)
VALUES 
('Mateusz', 'Zielinski', NULL, '+48123456789', 'mateusz.zielinski@gmail.com'),
('Maria', 'Ciobanu', NULL, '+37322123456', 'maria.ciobanu@ukr.net'),
('Victor', 'Popa', NULL, '+37312345678', 'victor.popa@yahoo.com'),
('Akua', 'Mensah', NULL, '+233241234567', 'akua.mensah@gmail.com'),
('Tetiana', 'Shevchenko', 'Olehivna', '+380671234567', 'tetiana.shevchenko@ukr.net'),
('Zuzanna', 'Kaminska', NULL, '+48234567890', 'zuzanna.kaminska@wp.pl'),
('Joao', 'Silva', NULL, '+244912345678', 'joao.silva@gmail.com'),
('Oleg', 'Kovalenko', 'Ivanovych', '+380501234567', 'oleg.kovalenko@gmail.com'),
('Yaw', 'Mensah', NULL, '+233541234567', 'yaw.mensah@yahoo.com'),
('Ana', 'Martins', NULL, '+244911234567', 'ana.martins@gmail.com'),
('Vlad', 'Petrov', 'Sergeevich', '+380732345678', 'vlad.petrov@ukr.net'),
('Elena', 'Ivanova', NULL, '+37322134567', 'elena.ivanova@yahoo.com'),
('Peter', 'Nowak', NULL, '+48123456780', 'peter.nowak@onet.pl'),
('Nadia', 'Tkachenko', 'Petrovna', '+380972345678', 'nadia.tkachenko@ukr.net'),
('Kwame', 'Boateng', NULL, '+233321123456', 'kwame.boateng@gmail.com'),
('Anna', 'Kowalska', NULL, '+48234567801', 'anna.kowalska@wp.pl'),
('Bogdan', 'Hrytsenko', 'Mykhailovych', '+380951234567', 'bogdan.hrytsenko@ukr.net'),
('John', 'Mensah', NULL, '+233551234567', 'john.mensah@gmail.com'),
('Natalia', 'Smirnova', NULL, '+37312123456', 'natalia.smirnova@yahoo.com'),
('Paweł', 'Kaminski', NULL, '+48113456789', 'pawel.kaminski@onet.pl'),
('Olena', 'Chernyak', 'Volodymyrivna', '+380503456789', 'olena.chernyak@ukr.net'),
('Kwesi', 'Amoah', NULL, '+233241234678', 'kwesi.amoah@gmail.com'),
('Marta', 'Nowakowska', NULL, '+48234567802', 'marta.nowakowska@wp.pl'),
('Alex', 'Popescu', NULL, '+37322156789', 'alex.popescu@gmail.com'),
('Iryna', 'Tkachenko', 'Olehivna', '+380632345678', 'iryna.tkachenko@ukr.net'),
('Joshua', 'Mensah', NULL, '+233541345678', 'joshua.mensah@yahoo.com'),
('Barbara', 'Zielinska', NULL, '+48113456780', 'barbara.zielinska@onet.pl'),
('Marcin', 'Kowalski', NULL, '+48234567803', 'marcin.kowalski@wp.pl'),
('Tetiana', 'Kravchenko', 'Ivanivna', '+380502345678', 'tetiana.kravchenko@ukr.net'),
('Carlos', 'Martinez', NULL, '+244912345679', 'carlos.martinez@gmail.com'),
('Olga', 'Ivanova', NULL, '+37312156789', 'olga.ivanova@yahoo.com'),
('Patryk', 'Nowakowski', NULL, '+48112456789', 'patryk.nowakowski@wp.pl'),
('Anna', 'Kovalenko', 'Mykolayivna', '+380672345678', 'anna.kovalenko@ukr.net'),
('Emmanuel', 'Boateng', NULL, '+233551456789', 'emmanuel.boateng@gmail.com'),
('Maria', 'Kaminska', NULL, '+48114567890', 'maria.kaminska@onet.pl'),
('Oksana', 'Shevchuk', 'Petrovna', '+380642345678', 'oksana.shevchuk@ukr.net'),
('Moses', 'Owusu', NULL, '+233551567890', 'moses.owusu@gmail.com'),
('Igor', 'Tkachenko', 'Olehivich', '+380752345678', 'igor.tkachenko@ukr.net'),
('Anna', 'Kaminska', NULL, '+48115467890', 'anna.kaminska@gmail.com'),
('George', 'Mensah', NULL, '+233651234567', 'george.mensah@yahoo.com'),
('Inna', 'Kravchenko', 'Volodymyrivna', '+380682345678', 'inna.kravchenko@ukr.net'),
('Victoria', 'Ivanova', NULL, '+37322167890', 'victoria.ivanova@gmail.com'),
('Jan', 'Zielinski', NULL, '+48116456789', 'jan.zielinski@onet.pl'),
('Olga', 'Shevchenko', 'Olehivna', '+380732456789', 'olga.shevchenko@ukr.net'),
('Patrick', 'Amoah', NULL, '+233651567890', 'patrick.amoah@gmail.com'),
('Oleh', 'Kravets', 'Serhiyovych', '+380702345678', 'oleh.kravets@ukr.net'),
('Sandra', 'Kaminska', NULL, '+48117456789', 'sandra.kaminska@gmail.com'),
('Angela', 'Martins', NULL, '+244912678901', 'angela.martins@yahoo.com'),
('Mykola', 'Hrytsenko', 'Ivanovych', '+380743456789', 'mykola.hrytsenko@ukr.net'),
('Patrycja', 'Nowakowska', NULL, '+48118456789', 'patrycja.nowakowska@wp.pl'),
('James', 'Mensah', NULL, '+233751234567', 'james.mensah@yahoo.com'),
('Hanna', 'Kravchenko', 'Petrovna', '+380752456789', 'hanna.kravchenko@ukr.net'),
('David', 'Boateng', NULL, '+233751567890', 'david.boateng@gmail.com'),
('Alex', 'Martinez', NULL, '+244912789012', 'alex.martinez@yahoo.com'),
('Maria', 'Zielinska', NULL, '+48119456789', 'maria.zielinska@wp.pl'),
('Ihor', 'Tkachenko', 'Volodymyrovych', '+380762345678', 'ihor.tkachenko@ukr.net'),
('Linda', 'Mensah', NULL, '+233651678901', 'linda.mensah@gmail.com'),
('Kateryna', 'Kravets', 'Volodymyrivna', '+380772345678', 'kateryna.kravets@ukr.net'),
('Barbara', 'Kaminska', NULL, '+48120456789', 'barbara.kaminska@gmail.com'),
('Sophia', 'Owusu', NULL, '+233751789012', 'sophia.owusu@yahoo.com'),
('Maksym', 'Tkachenko', 'Petrovych', '+380782345678', 'maksym.tkachenko@ukr.net');


--Генерация данных для таблицы BarberServices

DECLARE @BarberId INT;
DECLARE @Gender NVARCHAR(10);
DECLARE @Position NVARCHAR(20);

-- Получаем первый BarberId
DECLARE BarberCursor CURSOR FOR
SELECT BarberId, Gender, Position
FROM dbo.Barbers;

OPEN BarberCursor;

FETCH NEXT FROM BarberCursor INTO @BarberId, @Gender, @Position;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Генерация услуг для Chief Barber и Senior Barbers
    IF @Position IN ('Chief Barber', 'Senior Barber')
    BEGIN
        INSERT INTO dbo.BarberServices (BarberId, ServiceId)
        SELECT @BarberId, ServiceId
        FROM dbo.Services
        WHERE NOT EXISTS (
            SELECT 1 
            FROM dbo.BarberServices 
            WHERE BarberId = @BarberId AND ServiceId = dbo.Services.ServiceId
        );
    END
    -- Генерация услуг для Junior Barbers
    ELSE IF @Position = 'Junior Barber'
    BEGIN
        IF @Gender = 'Female'
        BEGIN
            INSERT INTO dbo.BarberServices (BarberId, ServiceId)
            SELECT @BarberId, ServiceId 
            FROM dbo.Services
            WHERE (ServiceName LIKE '%woman%' OR ServiceId = 1) -- 1 = 'Детская стрижка'
              AND ServiceId NOT IN (2, 3) -- Исключить услуги: 2 = 'Женский массаж кожи головы', 3 = 'Свадебная укладка волос'
              AND NOT EXISTS (
                  SELECT 1 
                  FROM dbo.BarberServices 
                  WHERE BarberId = @BarberId AND ServiceId = dbo.Services.ServiceId
              );
        END
        ELSE IF @Gender = 'Male'
        BEGIN
            INSERT INTO dbo.BarberServices (BarberId, ServiceId)
            SELECT @BarberId, ServiceId 
            FROM dbo.Services
            WHERE (ServiceName LIKE '%man%' OR ServiceId = 1) -- 1 = 'Детская стрижка'
              AND ServiceId NOT IN (4) -- Исключить услугу: 4 = 'Мужской массаж кожи головы'
              AND NOT EXISTS (
                  SELECT 1 
                  FROM dbo.BarberServices 
                  WHERE BarberId = @BarberId AND ServiceId = dbo.Services.ServiceId
              );
        END
    END

    -- Генерация для "Классическое бритье" и "Коррекция бровей" только для Chief Barber и Senior Barbers
    IF @Position IN ('Chief Barber', 'Senior Barber')
    BEGIN
        INSERT INTO dbo.BarberServices (BarberId, ServiceId)
        SELECT @BarberId, ServiceId
        FROM dbo.Services
        WHERE ServiceId IN (5, 6) -- 5 = 'Классическое бритье', 6 = 'Коррекция бровей'
          AND NOT EXISTS (
              SELECT 1 
              FROM dbo.BarberServices 
              WHERE BarberId = @BarberId AND ServiceId = dbo.Services.ServiceId
          );
    END

    FETCH NEXT FROM BarberCursor INTO @BarberId, @Gender, @Position;
END;

CLOSE BarberCursor;
DEALLOCATE BarberCursor;




--Генерация данных для таблицы Shedules
-- Создание временной таблицы с расписанием для категорий барберов
CREATE TABLE #BarberWorkSchedule (
    Position NVARCHAR(50),
    Gender NVARCHAR(10),
    DayOfWeek NVARCHAR(20),
    AvailableTimeStart TIME,
    AvailableTimeEnd TIME
);

-- Вставка данных о расписании
INSERT INTO #BarberWorkSchedule (Position, Gender, DayOfWeek, AvailableTimeStart, AvailableTimeEnd)
VALUES 
    -- Chief Barber
    ('Chief Barber', NULL, 'Monday', '10:00', '19:00'),
    ('Chief Barber', NULL, 'Tuesday', '10:00', '19:00'),
    ('Chief Barber', NULL, 'Thursday', '10:00', '19:00'),
    ('Chief Barber', NULL, 'Friday', '10:00', '19:00'),

    -- Senior Barber
    ('Senior Barber', NULL, 'Tuesday', '10:00', '19:00'),
    ('Senior Barber', NULL, 'Wednesday', '10:00', '19:00'),
    ('Senior Barber', NULL, 'Thursday', '10:00', '19:00'),
    ('Senior Barber', NULL, 'Friday', '10:00', '19:00'),
    ('Senior Barber', NULL, 'Saturday', '10:00', '14:00'),

    -- Junior Barber (Male)
    ('Junior Barber', 'Male', 'Monday', '10:00', '19:00'),
    ('Junior Barber', 'Male', 'Tuesday', '10:00', '19:00'),
    ('Junior Barber', 'Male', 'Wednesday', '10:00', '19:00'),
    ('Junior Barber', 'Male', 'Friday', '10:00', '19:00'),
    ('Junior Barber', 'Male', 'Sunday', '10:00', '14:00'),

    -- Junior Barber (Female)
    ('Junior Barber', 'Female', 'Monday', '10:00', '19:00'),
    ('Junior Barber', 'Female', 'Wednesday', '10:00', '19:00'),
    ('Junior Barber', 'Female', 'Thursday', '10:00', '19:00'),
    ('Junior Barber', 'Female', 'Friday', '10:00', '19:00'),
    ('Junior Barber', 'Female', 'Saturday', '10:00', '14:00');

-- Генерация данных для таблицы Schedules
INSERT INTO dbo.Schedules (BarberId, DayOfWeek, AvailableTimeStart, AvailableTimeEnd)
SELECT 
    B.BarberId,
    WS.DayOfWeek,
    WS.AvailableTimeStart,
    WS.AvailableTimeEnd
FROM 
    Barbers B
JOIN 
    #BarberWorkSchedule WS
ON 
    B.Position = WS.Position
    AND (WS.Gender IS NULL OR B.Gender = WS.Gender);

-- Удаление временной таблицы
DROP TABLE #BarberWorkSchedule;



--Генерация данных для таблицы Appointments (без статуса)

-- Создаём временную таблицу для хранения записей услуг за визит
DECLARE @TempAppointments TABLE (
    AppointmentId INT,
    ClientId INT,
    BarberId INT,
    AppointmentDate DATE,
    AppointmentTime TIME,
    TotalPrice DECIMAL(8, 2)
);

-- Перебираем всех клиентов из таблицы dbo.Clients
DECLARE @ClientId INT, @IsCompleted BIT, @BarberId INT, @ServiceIds NVARCHAR(MAX), @TotalPrice DECIMAL(8, 2);

DECLARE ClientCursor CURSOR FOR
SELECT ClientId
FROM dbo.Clients;

OPEN ClientCursor;
FETCH NEXT FROM ClientCursor INTO @ClientId;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Определяем, завершён ли визит (по чётности ClientId)
    SET @IsCompleted = CASE WHEN @ClientId % 2 = 0 THEN 1 ELSE 0 END;

    -- Назначаем барбера (случайным образом для демонстрации)
    SELECT TOP 1 @BarberId = BarberId
    FROM dbo.Barbers
    WHERE EXISTS (
        SELECT 1
        FROM dbo.BarberServices
        WHERE dbo.BarberServices.BarberId = dbo.Barbers.BarberId
    )
    ORDER BY NEWID();

    -- Выбираем услуги, доступные этому барберу
    SELECT @ServiceIds = STRING_AGG(ServiceId, ',')
    FROM dbo.BarberServices
    WHERE BarberId = @BarberId;

    -- Рассчитываем стоимость визита
    SELECT @TotalPrice = SUM(Price)
    FROM dbo.Services
    WHERE ServiceId IN (SELECT VALUE FROM STRING_SPLIT(@ServiceIds, ','));

    -- Выбираем дату и время записи
	INSERT INTO @TempAppointments (ClientId, BarberId, AppointmentDate, AppointmentTime, TotalPrice)
	VALUES (
		@ClientId,
		@BarberId,
		CASE WHEN @IsCompleted = 1 THEN DATEADD(DAY, -1 * ABS(CHECKSUM(NEWID()) % 30), GETDATE())
			ELSE DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 30), GETDATE()) END,
		CONVERT(TIME, DATEADD(HOUR, 10 + ABS(CHECKSUM(NEWID()) % 9), CAST('00:00:00' AS DATETIME))),
		@TotalPrice
	);

    FETCH NEXT FROM ClientCursor INTO @ClientId;
END;

CLOSE ClientCursor;
DEALLOCATE ClientCursor;

-- Вставляем данные из временной таблицы в основную таблицу
INSERT INTO dbo.Appointments (ClientId, BarberId, AppointmentDate, AppointmentTime, TotalPrice)
SELECT ClientId, BarberId, AppointmentDate, AppointmentTime, TotalPrice
FROM @TempAppointments;

-- Очистка временной таблицы
DELETE FROM @TempAppointments;



--Генерация данных для таблицы Appointments

DECLARE @ClientId INT, @BarberId INT, @ServiceId INT, @IsCompleted BIT, @AppointmentDate DATE, @AppointmentTime TIME;
DECLARE @TotalPrice DECIMAL(8, 2);

-- Цикл по всем клиентам
DECLARE ClientsCursor CURSOR FOR
SELECT ClientId FROM Clients;

OPEN ClientsCursor;

FETCH NEXT FROM ClientsCursor INTO @ClientId;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Назначаем парикмахера
    SET @BarberId = (SELECT TOP 1 BarberId 
                     FROM BarberServices 
                     WHERE ServiceId IN (SELECT ServiceId FROM Services) 
                     AND BarberId IN (SELECT BarberId FROM Barbers)
                     ORDER BY NEWID());

    -- Назначаем дату и время
    SET @AppointmentDate = CASE 
        WHEN @ClientId % 2 = 0 THEN DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 30), GETDATE()) -- Чётные (прошлые записи)
        ELSE DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 30), GETDATE()) -- Нечётные (будущие записи)
    END;

    SET @AppointmentTime = CONVERT(TIME, DATEADD(HOUR, 10 + ABS(CHECKSUM(NEWID()) % 9), CAST('00:00:00' AS DATETIME)));

    -- Рассчитываем стоимость
    SET @TotalPrice = (SELECT SUM(Price) 
                       FROM Services 
                       WHERE ServiceId IN (SELECT ServiceId 
                                           FROM BarberServices 
                                           WHERE BarberId = @BarberId));

    -- Определяем статус записи
    SET @IsCompleted = CASE 
        WHEN @ClientId % 2 = 0 THEN 1 -- Чётные завершённые
        ELSE 0 -- Нечётные незавершённые
    END;

    -- Вставляем запись
    INSERT INTO Appointments (ClientId, BarberId, AppointmentDate, AppointmentTime, TotalPrice, Status)
    VALUES (@ClientId, @BarberId, @AppointmentDate, @AppointmentTime, @TotalPrice, @IsCompleted);

    FETCH NEXT FROM ClientsCursor INTO @ClientId;
END;

CLOSE ClientsCursor;
DEALLOCATE ClientsCursor;

*/

--Генерация данных для таблицы Feadbecks

DECLARE @AppointmentId INT, @ClientId INT, @BarberId INT;
DECLARE @Rating NVARCHAR(10), @Comment NVARCHAR(MAX);

-- Комментарии для положительных и отрицательных отзывов
DECLARE @PositiveComments TABLE (Comment NVARCHAR(MAX));
INSERT INTO @PositiveComments (Comment)
VALUES 
    ('Excellent service, highly recommend!'),
    ('Barber was very skilled and friendly.'),
    ('Amazing haircut, thank you!'),
    ('Best barbershop experience ever!'),
    ('Very professional, will return soon.'),
    ('Great atmosphere and service!'),
    ('Super satisfied with my haircut.'),
    ('Barber went above and beyond.'),
    ('Perfect haircut, thank you!'),
    ('Fantastic service, worth every penny.');

DECLARE @NegativeComments TABLE (Comment NVARCHAR(MAX));
INSERT INTO @NegativeComments (Comment)
VALUES 
    ('Not satisfied with the service.'),
    ('The haircut was below average.'),
    ('Barber seemed rushed and inattentive.'),
    ('Not worth the price I paid.'),
    ('The experience could have been better.'),
    ('Too much waiting time, not happy.'),
    ('The haircut didn’t meet my expectations.'),
    ('Poor communication from the barber.'),
    ('Felt like the barber was in a hurry.'),
    ('Disappointed with the outcome.');

-- Курсор для обработки завершённых записей
DECLARE AppointmentCursor CURSOR FOR
SELECT AppointmentId, ClientId, BarberId
FROM Appointments
WHERE Status = 1;

OPEN AppointmentCursor;

FETCH NEXT FROM AppointmentCursor INTO @AppointmentId, @ClientId, @BarberId;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Генерация случайной оценки от 2 до 10
    SET @Rating = CAST(2 + ABS(CHECKSUM(NEWID()) % 9) AS NVARCHAR(10));

    -- Генерация комментария в зависимости от оценки
    IF CAST(@Rating AS INT) >= 6
    BEGIN
        SET @Comment = (SELECT TOP 1 Comment FROM @PositiveComments ORDER BY NEWID());
    END
    ELSE
    BEGIN
        SET @Comment = (SELECT TOP 1 Comment FROM @NegativeComments ORDER BY NEWID());
    END

    -- Вставка записи в таблицу Feedbacks
    INSERT INTO Feedbacks (ClientId, BarberId, Rating, Comment)
    VALUES (@ClientId, @BarberId, @Rating, @Comment);

    FETCH NEXT FROM AppointmentCursor INTO @AppointmentId, @ClientId, @BarberId;
END;

CLOSE AppointmentCursor;
DEALLOCATE AppointmentCursor;
