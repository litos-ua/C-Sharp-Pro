USE BarberShop; 
GO

/*
--Функція користувача повертає вітання в стилі «Hello, ІМ'Я!»
CREATE FUNCTION dbo.GetGreetingName (@Name NVARCHAR(50))
RETURNS NVARCHAR(100)
AS
BEGIN
    RETURN CONCAT('Hello, ', @Name, '!');
END;
GO

--Функція користувача повертає інформацію про поточну кількість хвилин
CREATE FUNCTION dbo.GetCurrentMinutes ()
RETURNS INT
AS
BEGIN
    RETURN DATEPART(MINUTE, GETDATE());
END;
GO

--Функція користувача повертає інформацію про поточний рік
CREATE FUNCTION dbo.GetCurrentYear ()
RETURNS INT
AS
BEGIN
    RETURN DATEPART(YEAR, GETDATE());
END;
GO



--Функція користувача повертає інформацію про те: парний або непарний рік
CREATE FUNCTION dbo.IsYearEvenOrOdd ()
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @Res NVARCHAR(10);
    IF (DATEPART(YEAR, GETDATE()) % 2 = 0)
        SET @Res = 'Even'; -- Четный год
    ELSE
        SET @Res = 'Odd';  -- Нечетный год
	RETURN @Res;
END;
GO


--Функція користувача приймає число і повертає yes, якщо число просте і no, якщо число не просте
CREATE FUNCTION dbo.IsPrimeNumber (@Number INT)
RETURNS NVARCHAR(3)
AS
BEGIN
    IF @Number <= 1
        RETURN 'No'; -- Числа 1 и меньше не являются простыми

    DECLARE @i INT = 2;

    WHILE @i <= SQRT(@Number)
    BEGIN
        IF @Number % @i = 0
            RETURN 'No'; -- Если есть делитель, число не простое
        SET @i = @i + 1;
    END

    RETURN 'Yes'; -- Если делителей нет, число простое
END;
GO


--Функція користувача приймає п'ять чисел та повертає суму мінімального та максимального значення 
CREATE FUNCTION dbo.SumMinAndMax (
    @Number1 INT, @Number2 INT, @Number3 INT, @Number4 INT, @Number5 INT
)
RETURNS INT
AS
BEGIN
    DECLARE @MinValue INT = (SELECT MIN(Value) FROM (VALUES (@Number1), (@Number2), (@Number3), (@Number4), (@Number5)) AS Numbers(Value));
    DECLARE @MaxValue INT = (SELECT MAX(Value) FROM (VALUES (@Number1), (@Number2), (@Number3), (@Number4), (@Number5)) AS Numbers(Value));
    RETURN @MinValue + @MaxValue;
END;
GO

-- Функція користувача показує всі парні або непарні числа в переданому діапазоні. 
-- Функція приймає три параметри: початок діапазону, кінець діапазону, парне чи непарне показувати.



CREATE FUNCTION dbo.ParityCheck (
    @FirstNumber INT,
    @EndNumber INT,
    @Type NVARCHAR(5) -- 'Even' или 'Odd'
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Result NVARCHAR(MAX) = '';
    DECLARE @i INT;

    -- Начинаем с ближайшего корректного числа
    IF @Type = 'Even' 
        SET @i = CASE WHEN @FirstNumber % 2 = 0 THEN @FirstNumber ELSE @FirstNumber + 1 END;
    ELSE
        SET @i = CASE WHEN @FirstNumber % 2 <> 0 THEN @FirstNumber ELSE @FirstNumber + 1 END;

    -- Идем с шагом 2
    WHILE @i <= @EndNumber
    BEGIN
        SET @Result = @Result + CAST(@i AS NVARCHAR) + ', ';
        SET @i = @i + 2;
    END;

    -- Убираем последнюю запятую
    IF LEN(@Result) > 0
        SET @Result = LEFT(@Result, LEN(@Result) - 1);

    RETURN @Result;
END;
GO
*/




SELECT dbo.GetGreetingName('Nickolas!'); --Приветствие

SELECT dbo.GetCurrentMinutes();  --Текущее количество минут

SELECT dbo.GetCurrentYear();  --Текущий год

SELECT dbo.IsYearEvenOrOdd();  --Четный или нечетный год

SELECT dbo.IsPrimeNumber(7);   --  Простое число
SELECT dbo.IsPrimeNumber(286); 

SELECT dbo.SumMinAndMax(11, 7, -2, 18, 25); --  Сумма минимального и максимального значения диапазона

SELECT dbo.ParityCheck(3, 22, 'Even');   --  Вывод четных или нечетных чисел в диапазоне
SELECT dbo.ParityCheck(1, 12, 'Odd');  


