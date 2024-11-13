USE Hospital;

-- 1.Генерация данных для таблицы Departments
INSERT INTO Departments (Building, Financing, Name)
VALUES 
    (1, 20000, 'Reception'),
    (2, 30000, 'Intensive Care'),
    (4, 25000, 'Urology'),
    (4, 22000, 'Gynecology'),
    (4, 18000, 'Dermatology'),
    (1, 31000, 'Polytrauma'),
    (2, 27000, 'Surgery'),
    (2, 29000, 'Therapy'),
    (4, 24000, 'Pulmonology'),
    (5, 26000, 'Ophthalmology'),
    (5, 21000, 'Psychiatry'),
    (1, 23000, 'Traumatology'),
    (3, 14000, 'Physiotherapy'),
    (3, 33000, 'Toxicology'),
    (3, 35000, 'Infectious Diseases'),
    (2, 32000, 'Cardiology');

GO

INSERT INTO Diseases (Name, Severity)
VALUES
    ('Kidney Stones', 3),
    ('Bladder Infection', 2),
    ('Gynecological Infection', 2),
    ('Skin Allergy', 1),
    ('Burns', 4),
    ('Fractures', 3),
    ('Appendicitis', 3),
    ('Chronic Bronchitis', 2),
    ('Glaucoma', 3),
    ('Bipolar Disorder', 4),
    ('Arthritis', 2),
    ('Inhalation Therapy', 1),
    ('Poisoning', 5),
    ('Viral Infection', 3),
    ('Heart Attack', 4);

GO

-- Генерация данных для таблицы Doctors
INSERT INTO Doctors (Name, Surname, Phone, Salary, AllowancePercent)
VALUES
    ('Aleksander', 'Nowak', '1234567890', 1500, 10),
    ('Maria', 'Kowalska', '0987654321', 1800, 15),
    ('Ivan', 'Nikolaev', '1234509876', 1600, 12),
    ('Olga', 'Shevchenko', '0987612345', 2200, 20),
    ('Nina', 'Novikova', '1122334455', 1900, 8),
    ('Oleh', 'Kravchenko', '6677889900', 2700, 30),
    ('Natalia', 'Borysova', '5566778899', 800, 5),
    ('Szymon', 'Nowakowski', '9988776655', 1500, 10),
    ('Pavlo', 'Nikitin', '8877665544', 2500, 18),
    ('Katarzyna', 'Niemiec', '5566443322', 1200, 6),
    ('Mikhail', 'Nazarov', '9988442211', 2300, 12),
    ('Anna', 'Popovych', '3344556677', 900, 7),
    ('Piotr', 'Zielinski', '1122554433', 1800, 15),
    ('Yulia', 'Nechyporenko', '4433221100', 3000, 50),
    ('Mykhailo', 'Novak', '2233445566', 1100, 9),
    ('Sergey', 'Nikitin', '5544332211', 1400, 5),
    ('Tatyana', 'Nazarenko', '9988998877', 2700, 25),
    ('Bohdan', 'Nowacki', '3322114455', 2000, 20),
    ('Andrii', 'Nikitina', '6655443322', 850, 10),
    ('Hanna', 'Orlova', '1122112233', 1200, 8),
    ('Yuriy', 'Ostapchuk', '3344112233', 1750, 17),
    ('Larysa', 'Kuchma', '8899776655', 2450, 28),
    ('Oksana', 'Radchenko', '1122778899', 2650, 12),
    ('Krzysztof', 'Kaczmarek', '9988223344', 1100, 6),
    ('Volodymyr', 'Nekrasov', '4455778899', 2300, 22),
    ('Zoya', 'Nalivayko', '6677889988', 1500, 10),
    ('Roman', 'Norovsky', '5544339900', 1800, 8),
    ('Oleksii', 'Kyrychuk', '7788991122', 2900, 45),
    ('Tamara', 'Nevzorova', '4433223344', 1350, 7),
    ('Viktoria', 'Nikulina', '9988112233', 1950, 15),
    ('Vasyl', 'Chornyi', '5566771100', 1100, 5),
    ('Tomasz', 'Piotrowski', '2233447788', 2600, 30),
    ('Ewa', 'Kowal', '4455667788', 2050, 16),
    ('Jan', 'Nadolny', '6655447788', 900, 4),
    ('Marta', 'Nalewska', '7788995544', 2800, 32),
    ('Denys', 'Pavlenko', '9988221133', 2100, 23),
    ('Anatolii', 'Nedashkovsky', '4455661133', 950, 3),
    ('Vitaliy', 'Nikon', '5566772244', 2400, 18),
    ('Yaryna', 'Niemir', '3344556688', 1400, 11),
    ('Lesya', 'Nazarova', '8899005566', 1300, 10),
    ('Vladyslav', 'Nosko', '2233114455', 2750, 27),
    ('Larisa', 'Kovalchuk', '9988001122', 1900, 12),
    ('Iryna', 'Norova', '3344551122', 1750, 14),
    ('Artem', 'Nazarenko', '6677885566', 2350, 9),
    ('Natalia', 'Nikitina', '4455662244', 1600, 8),
    ('Miroslav', 'Novak', '2233441122', 1500, 10),
    ('Daria', 'Karpenko', '8899112233', 2100, 6),
    ('Borys', 'Nosenko', '9988774433', 2900, 45),
    ('Olena', 'Nepomnyashchaya', '2233224455', 2000, 19),
    ('Maksym', 'Nechyporuk', '1122553322', 2650, 25);

GO
-- Генерация данных для таблицы Wards с учетом корпусов, этажей и нумерации палат
DECLARE @departmentId INT = 1;
DECLARE @floor INT;
DECLARE @wardNumber INT;
DECLARE @wardId INT = 1;

WHILE @departmentId <= 5 -- Отделения 1-5
BEGIN
    SET @floor = 1;
    WHILE @floor <= 3 -- Каждый этаж в отделении
    BEGIN
        SET @wardNumber = 1;
        WHILE @wardNumber <= 10 -- 10 палат на каждом этаже
        BEGIN
            INSERT INTO Wards (Building, Floor, Name)
            VALUES 
            (
                @departmentId,
                @floor,
                CONCAT('Ward ', @departmentId, '-', @floor, '-', @wardNumber)
            );

            SET @wardNumber = @wardNumber + 1;
        END;
        SET @floor = @floor + 1;
    END;
    SET @departmentId = @departmentId + 1;
END;

GO

-- Временная задержка 2 секунды
WAITFOR DELAY '00:00:02';

-- Генерация данных для таблицы Examinations
INSERT INTO Examinations (Name, DayOfWeek, StartTime, EndTime)
VALUES 
    ('Initial Consultation', 1, '09:00', '10:00'),
    ('Follow-up Examination', 2, '11:00', '12:00'),
    ('Diagnostic Assessment', 3, '13:00', '14:00'),
    ('Specialist Consultation', 4, '15:00', '16:00'),
    ('Advanced Screening', 5, '10:00', '11:30'),
    ('Physical Therapy Session', 6, '09:30', '11:00'),
    ('Psychiatric Evaluation', 7, '14:00', '15:30');
