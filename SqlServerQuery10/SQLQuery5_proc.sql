USE BarberShop;
GO

/*
-- Процедура выводит принятую как параметр строку (Hello, world!)
CREATE PROCEDURE dbo.PrintString
	@Message VARCHAR(50)
AS
BEGIN
    PRINT @Message;
END;
GO

-- Процедура возвращает информацию о текущем времени
CREATE PROCEDURE dbo.GetCurrentTime
AS
BEGIN
    SELECT CONVERT(TIME, GETDATE()) AS CurrentTime;
END;
GO

-- Поцедура возвращает информацию о текущей дате
CREATE PROCEDURE dbo.GetCurrentDate
AS
BEGIN
    SELECT CAST(GETDATE() AS DATE) AS CurrentDate;
END;
GO

-- Процедура принимает три числа и возвращает их сумму
CREATE PROCEDURE dbo.SumOfThreeNumbers
    @Number1 INT,
    @Number2 INT,
    @Number3 INT
AS
BEGIN
    SELECT @Number1 + @Number2 + @Number3 AS Sum;
END;
GO

-- Процедура принимает три числа и возвращает среднее арифметическое
CREATE PROCEDURE dbo.AverageOfThreeNumbers
    @Number1 INT,
    @Number2 INT,
    @Number3 INT
AS
BEGIN
    SELECT (@Number1 + @Number2 + @Number3) / 3.0 AS Average;
END;
GO

-- Процедура принимает три числа и возвращает максимальное значение
CREATE PROCEDURE dbo.MaxOfThreeNumbers
    @Number1 INT,
    @Number2 INT,
    @Number3 INT
AS
BEGIN
    SELECT MAX(Value) AS MaxValue
    FROM (VALUES (@Number1), (@Number2), (@Number3)) AS Numbers(Value);
END;
GO

-- Процедура принимает три числа и возвращает минимальное значение
CREATE PROCEDURE dbo.GetMinOfThreeNumbers
    @Number1 INT,
    @Number2 INT,
    @Number3 INT
AS
BEGIN
    SELECT MIN(Value) AS MinValue
    FROM (VALUES (@Number1), (@Number2), (@Number3)) AS Numbers(Value);
END;
GO

-- Процедура принимает число и символ, отображая символ количеством раз равным числу
CREATE PROCEDURE dbo.CharacterLine
    @Length INT,
    @Character CHAR(1)
AS
BEGIN
    DECLARE @Line NVARCHAR(MAX) = REPLICATE(@Character, @Length);
    PRINT @Line;
END;
GO

-- Процедура принимает число и возвращает его факториал
CREATE PROCEDURE dbo.Factorial
    @Number INT
AS
BEGIN
    DECLARE @Factorial INT = 1;
    DECLARE @i INT = 1;

    WHILE @i <= @Number
    BEGIN
        SET @Factorial = @Factorial * @i;
        SET @i = @i + 1;
    END;

    SELECT @Factorial AS Factorial;
END;
GO

--Процедура возводит число встепень
CREATE PROCEDURE dbo.RaisingToPower
    @BaseNum FLOAT,
    @Exp INT
AS
BEGIN
    SELECT POWER(@BaseNum, @Exp) AS Exponentiation;
END;
GO
*/



EXEC dbo.PrintString 'Hello, world!'; -- Процедура выводит принятую как параметр строку (Hello, world!)

EXEC dbo.GetCurrentTime; -- Процедура возвращает информацию о текущем времени

EXEC dbo.GetCurrentDate; -- -- Поцедура возвращает информацию о текущей дате

EXEC dbo.SumOfThreeNumbers 5, 100, 15; -- Процедура принимает три числа и возвращает их сумму

EXEC dbo.AverageOfThreeNumbers 75, 102, -15; -- Процедура принимает три числа и возвращает среднее арифметическое

EXEC dbo.MaxOfThreeNumbers -5, 111, 158; -- Процедура принимает три числа и возвращает максимальное значение

EXEC dbo.MinOfThreeNumbers 75, -12, 327; -- Процедура принимает три числа и возвращает минимальное значение

EXEC dbo.CharacterLine 5, '#'; -- Процедура принимает число и символ, отображая символ количеством раз равным числу

EXEC dbo.CharacterLine 15, '-';

EXEC dbo.CharacterLine 32, 3;

EXEC dbo.Factorial 7;

EXEC dbo.RaisingToPower 5, 3; --Процедура возводит число встепень
