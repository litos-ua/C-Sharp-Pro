USE University;
GO
-- Вставка данных в таблицу студентов
INSERT INTO Students (FirstName, Patronymic, Surname, BirthDate, City, Email, Phone, CountryID, GroupID) 
VALUES 
-- Группа A (12 студентов): Украина, Польша, Германия, Молдова
('Olena', 'Petrovna', 'Ivanova', '2000-05-14', 'Kyiv', 'olena.ivanova@ukr.net', '+380501234567', 1, 1),
('Tetyana', 'Andriivna', 'Kovalenko', '2001-03-12', 'Lviv', 'tetyana.kovalenko@gmail.com', '+380504567890', 1, 1),
('Karolina', NULL, 'Nowak', '2000-09-22', 'Warsaw', 'karolina.nowak@wp.pl', '+481234567123', 2, 1),
('Iwona', NULL, 'Wisniewska', '1999-12-18', 'Gdansk', 'iwona.wisniewska@gmail.com', '+481234564321', 2, 1),
('Ilona', NULL, 'Dashkiewicz', '2001-01-15', 'Poznan', 'ilona.dashkiewicz@onet.pl', '+481234569876', 2, 1),
('Johann', NULL, 'Schmidt', '1999-11-07', 'Berlin', 'johann.schmidt@yahoo.com', '+491234567890', 3, 1),
('Iliana', 'Stefanovna', 'Popescu', '2001-02-17', 'Chisinau', 'iliana.popescu@yahoo.com', '+373123456789', 4, 1),
('Yuriy', 'Mykolayovych', 'Boyko', '1999-11-25', 'Kyiv', 'yuriy.boyko@ukr.net', '+380505678123', 1, 1),
('Oleg', 'Ivanovych', 'Shevchenko', '2000-04-21', 'Odessa', 'oleg.shevchenko@ukr.net', '+380504567345', 1, 1),
('Samantha', NULL, 'Mbenga', '2001-05-30', 'Libreville', 'samantha.mbenga@gmail.com', '+241123456789', 5, 1),
('Dmitry', 'Olehovych', 'Krivets', '2000-03-17', 'Dnipro', 'dmitry.krivets@ukr.net', '+380501239876', 1, 1),
('Piotr', NULL, 'Kaminski', '1999-10-09', 'Poznan', 'piotr.kaminski@wp.pl', '+481234567123', 2, 1),

-- Группа B (16 студентов): Украина, Польша, Германия, Молдова, Габон
('Karolina', NULL, 'Wojcik', '2000-08-20', 'Warsaw', 'karolina.wojcik@wp.pl', '+481234569123', 2, 2),
('Ilona', NULL, 'Kaminski', '1999-10-09', 'Poznan', 'ilona.kaminski@onet.pl', '+481234567222', 2, 2),
('Ilyana', 'Vasilievna', 'Grigorescu', '2001-09-10', 'Chisinau', 'ilyana.grigorescu@yahoo.com', '+373123456123', 4, 2),
('Tetiana', 'Volodymyrivna', 'Pavlenko', '2000-12-02', 'Chernihiv', 'tetiana.pavlenko@ukr.net', '+380503214567', 1, 2),
('Anna', NULL, 'Mbenga', '2001-05-30', 'Libreville', 'anna.mbenga@gmail.com', '+241123456789', 5, 2),
('Hans', NULL, 'Fischer', '2000-01-10', 'Hamburg', 'hans.fischer@gmail.com', '+491234567654', 3, 2),
('Elena', 'Ionovna', 'Balan', '2000-04-25', 'Chisinau', 'elena.balan@yahoo.com', '+373123456789', 4, 2),
('Bogdan', 'Olehovych', 'Petrenko', '2001-06-07', 'Lviv', 'bogdan.petrenko@ukr.net', '+380501234568', 1, 2),
('Oksana', 'Petrovna', 'Hrytsenko', '2000-07-12', 'Kharkiv', 'oksana.hrytsenko@ukr.net', '+380504567890', 1, 2),
('Barbara', NULL, 'Kaczmarek', '2001-01-15', 'Warsaw', 'barbara.kaczmarek@onet.pl', '+481234568765', 2, 2),
('Piotr', NULL, 'Grabowski', '1999-06-22', 'Gdansk', 'piotr.grabowski@wp.pl', '+481234569123', 2, 2),
('Marcin', NULL, 'Nowicki', '2000-09-28', 'Poznan', 'marcin.nowicki@gmail.com', '+481234567098', 2, 2),
('Oleh', 'Mykolayovych', 'Ivanov', '1999-11-10', 'Kyiv', 'oleh.ivanov@ukr.net', '+380501234876', 1, 2),
('Katarzyna', NULL, 'Lewandowski', '2001-07-25', 'Wroclaw', 'katarzyna.lewandowski@onet.pl', '+481234567876', 2, 2),
('Malgorzata', NULL, 'Lukiewicz', '2000-06-08', 'Krakow', 'gosia.lcz@onet.pl', '+481234568765', 2, 1),
('Vitaliy', 'Andriivych', 'Stepanenko', '2000-05-05', 'Dnipro', 'vitaliy.stepanenko@ukr.net', '+380501239876', 1, 2),

-- Группа C (14 студентов): Украина, Польша, Германия, Габон
('Yuriy', 'Petrovych', 'Kovalchuk', '2001-04-01', 'Kyiv', 'yuriy.kovalchuk@gmail.com', '+380501234765', 1, 3),
('Barbara', NULL, 'Kwiatkowski', '1999-10-04', 'Krakow', 'barbara.kwiatkowski@wp.pl', '+481234561234', 2, 3),
('Katarzyna', NULL, 'Nowak', '2000-02-15', 'Warsaw', 'katarzyna.nowak@onet.pl', '+481234567567', 2, 3),
('Ilona', NULL, 'Majewska', '1999-06-08', 'Gdansk', 'ilona.majewska@gmail.com', '+481234567987', 2, 3),
('Samantha', NULL, 'Mbengo', '2001-05-13', 'Libreville', 'samantha.mbengo@yahoo.com', '+241123456789', 5, 3),
('Tetiana', 'Serhiivna', 'Lysenko', '2000-07-09', 'Kyiv', 'tetiana.lysenko@ukr.net', '+380507654321', 1, 3),
('Aleksander', NULL, 'Schmidt', '2000-08-17', 'Berlin', 'aleksander.schmidt@yahoo.com', '+491234567890', 3, 3),
('Ivan', 'Petrovych', 'Koval', '1999-11-05', 'Lviv', 'ivan.koval@ukr.net', '+380505678123', 1, 3),
('Karolina', NULL, 'Zielinska', '2001-09-15', 'Poznan', 'karolina.zielinska@onet.pl', '+481234567123', 2, 3),
('Mvuma', NULL, 'Mbina', '2002-05-11', 'Oyem', 'nvuma.mbina@gmail.com', '+241123456789', 5, 3),
('Ndongo', NULL, 'Ekouaga', '2003-07-02', 'Port-Gentil', 'ndongo.ekouaga@gmail.com', '+243113756789', 5, 3),
('Sophie', NULL, 'Mouyeli', '2001-11-22', 'Nyanga', 'sophie.mouyeli@gmail.com', '+247145556789', 5, 3),
('Julie', NULL, 'Nguema', '2000-05-30', 'Port-Gentil', 'julie.nguema@gmail.com', '+24715388789', 5, 3),
('Zofia', NULL, 'Kaminska', '1999-12-21', 'Warsaw', 'zofia.kaminska@wp.pl', '+481234568876', 2, 3),

-- Вставка данных для группы D (17 студентов): Украина, Польша, Германия, Молдова, Габон

('Olena', 'Petrovna', 'Melnyk', '2000-02-04', 'Kyiv', 'olena.melnyk@ukr.net', '+380501234321', 1, 4),
('Tetyana', 'Ivanivna', 'Bondarenko', '2001-07-11', 'Lviv', 'tetyana.bondarenko@gmail.com', '+380504567123', 1, 4),
('Ilona', NULL, 'Nowak', '1999-12-09', 'Warsaw', 'ilona.nowak@onet.pl', '+481234567123', 2, 4),
('Barbara', NULL, 'Wisniewska', '2000-03-17', 'Krakow', 'barbara.wisniewska@wp.pl', '+481234567456', 2, 4),
('Iwona', NULL, 'Zielinska', '1999-06-21', 'Poznan', 'iwona.zielinska@gmail.com', '+481234567789', 2, 4),
('Samantha', NULL, 'Okeke', '2001-01-25', 'Libreville', 'samantha.okeke@yahoo.com', '+241123456789', 5, 4),
('Piotr', NULL, 'Kowalski', '2000-05-08', 'Warsaw', 'piotr.kowalski@onet.pl', '+481234567345', 2, 4),
('Johann', NULL, 'Mueller', '1999-08-19', 'Berlin', 'johann.mueller@gmail.com', '+491234567890', 3, 4),
('Iliana', 'Vasylivna', 'Petrescu', '2001-04-15', 'Chisinau', 'iliana.petrescu@yahoo.com', '+373123456123', 4, 4),
('Yuriy', 'Mykolayovych', 'Sydorenko', '2000-11-30', 'Kyiv', 'yuriy.sydorenko@ukr.net', '+380507654321', 1, 4),
('Dmytro', 'Andriyovych', 'Tkachenko', '1999-10-22', 'Odessa', 'dmytro.tkachenko@ukr.net', '+380504567789', 1, 4),
('Karolina', NULL, 'Gorska', '2001-05-12', 'Gdansk', 'karolina.gorska@wp.pl', '+481234567098', 2, 4),
('Marcin', NULL, 'Lis', '2000-08-18', 'Poznan', 'marcin.lis@gmail.com', '+481234567876', 2, 4),
('Oksana', 'Petrovna', 'Dovzhenko', '2001-09-03', 'Kharkiv', 'oksana.dovzhenko@ukr.net', '+380501234567', 1, 4),
('Hans', NULL, 'Schneider', '1999-12-07', 'Hamburg', 'hans.schneider@yahoo.com', '+491234567654', 3, 4),
('Vasyl', 'Oleksandrovych', 'Krivets', '2000-06-28', 'Dnipro', 'vasyl.krivets@ukr.net', '+380501234876', 1, 4),
('Anna', NULL, 'Mbongo', '2001-03-10', 'Libreville', 'anna.mbongo@gmail.com', '+241987654321', 5, 4),

-- Вставка данных для группы E (15 студентов): Украина, Польша, Германия, Молдова, Габон

('Iryna', 'Serhiivna', 'Kostenko', '2001-04-05', 'Kyiv', 'iryna.kostenko@ukr.net', '+380507654321', 1, 5),
('Tetyana', 'Andriivna', 'Lytvyn', '2000-03-25', 'Lviv', 'tetyana.lytvyn@gmail.com', '+380504567890', 1, 5),
('Karolina', NULL, 'Sikorska', '1999-05-13', 'Warsaw', 'karolina.sikorska@onet.pl', '+481234567567', 2, 5),
('Barbara', NULL, 'Zawadzki', '2000-02-19', 'Gdansk', 'barbara.zawadzki@wp.pl', '+481234567123', 2, 5),
('Samantha', NULL, 'Bongo', '1999-09-18', 'Libreville', 'samantha.bongo@yahoo.com', '+241123456789', 5, 5),
('Ilona', NULL, 'Lewandowska', '2001-11-08', 'Poznan', 'ilona.lewandowska@gmail.com', '+481234567890', 2, 5),
('Bohdan', 'Ivanovych', 'Lopach', '2000-10-12', 'Kharkiv', 'bohdan.lopach@ukr.net', '+380501234567', 1, 5),
('Ilya', 'Mykolayovych', 'Volkov', '2000-01-15', 'Odessa', 'ilya.volkov@ukr.net', '+380504567123', 1, 5),
('Johann', NULL, 'Mayer', '1999-07-07', 'Berlin', 'johann.mayer@yahoo.com', '+491234567890', 3, 5),
('Iliana', 'Mikhailivna', 'Cojocaru', '2001-06-28', 'Chisinau', 'iliana.cojocaru@gmail.com', '+373123456789', 4, 5),
('Volodymyr', 'Petrovych', 'Melnyk', '2000-08-17', 'Kyiv', 'volodymyr.melnyk@ukr.net', '+380507654321', 1, 5),
('Hans', NULL, 'Keller', '2001-09-03', 'Hamburg', 'hans.keller@gmail.com', '+491234567654', 3, 5),
('Zofia', NULL, 'Kaminska', '1999-12-20', 'Warsaw', 'zofia.kaminska@onet.pl', '+481234568876', 2, 5),
('Petro', 'Olehovych', 'Sydorchuk', '2000-11-27', 'Dnipro', 'petro.sydorchuk@ukr.net', '+380501239876', 1, 5),
('Aline', NULL, 'Ndong', '2001-03-23', 'Libreville', 'aline.ndong@gmail.com', '+241987654321', 5, 5);

GO

