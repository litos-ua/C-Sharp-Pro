USE CinemaDb;

-- Сеансы (уникальное расписание на 2 недели)
-- Переменные для расписания
DECLARE @startDate DATETIME = '2024-12-18'; -- Начальная дата
DECLARE @endDate DATETIME = DATEADD(DAY, 13, @startDate); -- Конечная дата через две недели

-- Списки фильмов
DECLARE @movies TABLE (Id INT);
INSERT INTO @movies (Id) VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10);

-- Списки залов
DECLARE @rooms TABLE (RoomName NVARCHAR(50));
INSERT INTO @rooms (RoomName) VALUES ('Red'), ('Green'), ('Blue'), ('Yellow');

-- Расписание будние дни
DECLARE @weekdaySessions TABLE (Hour INT);
INSERT INTO @weekdaySessions (Hour) VALUES (16), (18), (20), (22);

-- Расписание выходные дни
DECLARE @weekendSessions TABLE (Hour INT);
INSERT INTO @weekendSessions (Hour) VALUES (11), (13), (15), (17), (19), (21);

-- Цикл для создания расписания на две недели
DECLARE @currentDate DATETIME = @startDate;

WHILE @currentDate <= @endDate
BEGIN
    -- Выбираем расписание для буднего или выходного дня
    IF DATEPART(WEEKDAY, @currentDate) IN (1, 7) -- Воскресенье и суббота
    BEGIN
        INSERT INTO Sessions (StartTime, Price, MovieId, RoomName)
        SELECT 
            DATEADD(HOUR, Hour, @currentDate) AS StartTime,
            100.0 AS Price,
            m.Id AS MovieId,
            r.RoomName AS RoomName
        FROM @weekendSessions
        CROSS JOIN @movies m
        CROSS JOIN @rooms r
        WHERE m.Id % 4 + 1 = (SELECT ROW_NUMBER() OVER (ORDER BY RoomName) FROM @rooms r2 WHERE r2.RoomName = r.RoomName);
    END
    ELSE
    BEGIN
        INSERT INTO Sessions (StartTime, Price, MovieId, RoomName)
        SELECT 
            DATEADD(HOUR, Hour, @currentDate) AS StartTime,
            80.0 AS Price,
            m.Id AS MovieId,
            r.RoomName AS RoomName
        FROM @weekdaySessions
        CROSS JOIN @movies m
        CROSS JOIN @rooms r
        WHERE m.Id % 4 + 1 = (SELECT ROW_NUMBER() OVER (ORDER BY RoomName) FROM @rooms r2 WHERE r2.RoomName = r.RoomName);
    END

    -- Переход на следующий день
    SET @currentDate = DATEADD(DAY, 1, @currentDate);
END;

