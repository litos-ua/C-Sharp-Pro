# C-Sharp-Pro

## Д.З. 1 Реалізовано наступний функціонал консольного калькулятора:

- При запуску калькулятора користувач отримує меню де він повинен ввести тип математичної дії ("What action 
  do you want to do? Add, Diff, Mult, Div, Sqrt, Sin, Cos");
- При вводі типу дії введені дані повинні співпадати з пропонуємими. Регістр не має значення. При помилковому
  вводі з'являється повідомлення про повторний ввод ("Unknown operation. Please enter a valid action (Add, Diff, 
  Mult, Div, Sqrt, Sin, Cos) or 'Esc' to exit.);
- У залежності від обраної дії користувач вводить одне або два числа, які валідуються при вводі. Якщо введені
  некоректні дані, то пропонується ввести їх ще раз ("Invalid number. Please enter a valid number.);
- Якщо введена некоректна математична дія, то вводиться повіщення ("Unknown operation. Please enter a valid action
  (Add, Diff, Mult, Div, Sqrt, Sin, Cos) or 'Esc' to exit."). Треба ввести коректну дію або натиснути "Esc", після
  чого користувач потрапляє у меню виходу ("Do you want to continue working? Y/N").
- Після коректного виконання дії користувач потрапляє у меню виходу. Якщо він ввів "Y", то повертаэться до головного
  меню, якщо "N", то виходить з прогами.

## Весь код розділено на окремі класи, які знаходяться в окремих файлах:
- Program - місце входу в програму;
- Calculatot - Головна частина;
- InputAndValidation - ввод математичних операцій та їх аргументів з валідацією;
- public class MathOperations - методи с математичними функціями;


У програмі використані словники, які містять операції як посилання делегатів. Коли користувач вводить дію 
("Add", "Diff", ...), програма використовує її як ключ для пошуку відповідного методу. 


## Д.З. 2 Принципи ООП.

### Завдання 1.
  В завданні реалізовано два класи: Money, Product.
  Клас Product імітує товар. Цей клас має наступні поля та методи:
  - ProductName - поле яке містить назву товара;
  - ProductCategory - поле яке містить ктегорію товара (необов'язкове);
  - ProductDescription - поле яке містить опис товара (необов'язкове);
  - ProductPrice - поле яке містить ціну товара;
  - ProductQuantity - поле яке містить кількість товара;
  - ProductDiscount - поле яке містить знижку на ціну товара (необов'язкове)
  - QuantityDiff - метод, який зменьшує кількість товара, яке зазначене в полі ProductQuantity;
  - IsValidProduct - метод перевірки коректності даних продукту;
  Клас Money імітує банківську картку покупця. Цей клас має наступні поля та методи:
  - EuroRubles - поле яке містить суму євро на рахунку;
  - EuroCoins - поле яке містить суму дрібних центів на рахунку;
  - AddMoney - метод, який додає гроші на рахунок (поповнення рахунку) після чого у консоль виводиться стан 
    рахунку;
  - DiffMoney - метод, який зменьшує кількість грошей на рахунку (зняття грошей з рахунку або покупка) після 
    чого у консоль виводиться стан рахунку. Додатково перевіряємо достатність коштів на рахунку;
  - HowMuchMoney - метод, який виводить у консоль стан рахунку; 
  - BuyProduct - метод, який здійснює купівлю товара.

    Метод для покупки продуктів працює в такий спосіб. Обчислюємо повну вартість з урахуванням знижки. Здійснюємо 
    перевірку наявності достатньої кількості товару для купівлі та наявності необхідної кількості грошей. Для 
    оцінки кількості коштів переводимо все до центів. У разі невиконання умов виводимо у консоль відповідні 
    повідомлення. Якщо покупка відбулася успішною, виводимо в повідомлення в консоль повідомлення і баланс коштів 
    на рахунку.
  - 
### Завдання 2.
  В завданні реалізовано базовий клас MusicalInstrument, та чотире похідних класи (Violin, Trombone, Ukulele, 
  Cello). В базовому класі реалізовані поля NameOfMusInstrument, HistoryOfMusInstrument, DescribeOfMusInstrument,
  SoundOfMusInstrument та методи Sound, Show, Desc, History. Поле NameOfMusInstrument є обов'язковим, інші поля
  опціональні. У базовому класі створено конструктор де обов'язковим є тільки поле name, інші є опціональними
  параметрами. Конструктори у нащадках наслідують базовий конструктор та дозволють перевизначати будь-які поля.
  
### Завдання 3.
   Структура DecNumberConversion служить для конвертування десяткових чисел в бінарні (Bin), восьмеричні (Oct) та
   шістнадцяткові (Hex) числа. Інтерфейс користувача для конвертування десяткових чисел схожий на попереднє (д.з. 1)
   завдання. Треба ввести вид конвертування, а потім саме десяткове число. При вводі дані валідуються. У консоль
   результат.
   Для конвертування у восьмеричні та шістнадцяткові числа використані вбудовані методи. Для бінарних використуван
   самописний метод ConvertToBin.

## Д.З. 3 Абстрактні класи та інтерфейси.
   Створено клас Myist (замість MyArray), кий має поле - список з цілими числовими значеннями.
### Завдання 1.
   Створено інтерфейс IOutput. Він забов'язує зробити два методи:
   - void Show() — відображає інформацію;
   - void Show(string info) — відображає інформацію та інформаційне повідомлення, зазначене у параметрі info.

   До класу MyList додана імплементація інтерфейсу IOutput з відповідними методами:
  - Метод Show() — відображає на екран елементи списку.
  - Метод Show(string info) — відображає на екрані елементи списку та інформаційне повідомлення, яке є параметром
  info в екземплярі класу "The list of integers (_кількість елементів списку_):".

### Завдання 2.
   Створено інтерфейс IMath. Він забов'язує зробити чотире методи:
   - int Max() — повертає максимум;
   - int Min() — повертає мінімум;
   - float Avg() — повертає середньоарифметичне;
   - bool Search(int valueToSearch) — шукає valueSearch всередині контейнера даних, та повертає true, якщо значення
     знайдено або false, якщо значення не знайдено.
     До класу MyList додана імплементація інтерфейсу IMath з відповідними методами.
     Для перевірки останнього метода треба ввести в консолі значення за яким проводиться пошук у списку.

### Завдання 3.
   Створено інтерфейс ISort. Він забов'язує зробити три методи.
   - void SortAsc() — сортує за зростанням;
   - void SortDesc() — сортує за зменшенням;
   - void SortByParam(bool isAsc) — сортує за зростанням або за зменшенням залежно від переданого параметра.
   До класу MyList додана імплементація інтерфейсу ISort з відповідними методами.


## Д.З. 4  Перевантаження операторів.
### Завдання 1.
Створено базовий клас «Співробітник» - «BaseEmploee». Він має три обов'язкові властивості:
  - name;
  - email;
  - department;
  Також клас має відповідні властивості де виконується валідація.

Створено клас-нащадок «Співробітник» - «Emploee»  У новому класі додана властивість salary (заробітну плата
працівника). Також у цьому класі виконано перевантаження методів

  - \+ - (для збільшення/зменшення зарплати на вказану кількість),
  - == != (перевірка на рівність зарплат працівників),
  - < і > (перевірка на меншу чи більшу кількість зарплат працівників),
  - Equals, GetHashCode - обов'язково при перевантаженні == та !=,
  - ToString - для організації зручного виводу значення полів у консоль.

### Завдання 2.
Створено відразу клас «Місто» - «City». Він має чотире обов'язкові властивості:
  - cityName;
  - country;
  - population;
  - budget;
    Клас має відповідні властивості де виконується валідація. Також у цьому класі виконано перевантаження методів:

  - \+ - (для збільшення/зменшення жителів на вказану кількість),
  - == != (перевірка на рівність двох міст за кількістю жителів),
  - < і > (перевірка на меншу чи більшу кількість мешканців),
  - Equals, GetHashCode - обов'язково при перевантаженні == та !=,
  - ToString - для організації зручного виводу значення полів у консоль.

### Завдання 3.
Створено відразу клас «Кредитна картка» - «CreditCard». Він має п'ять обов'язкових властивостей:
  - cardNumber;
  - cardOwner;
  - validDate;
  - PaymentSystem { get; set; }
  - cvcCode;
    Клас має відповідні властивості де виконується валідація.

Розширення класа виконано за рахунок розділення (partial). Додана властивість amountOfMoney (кількість грошей
на рахунку). Також у цьому класі виконано перевантаження методів:

- \+ - (для збільшення/зменшення грошей на вказану кількість),
- == != (перевірка на рівність CVC коду),
- < і > (перевірка на меншу чи більшу кількість суми грошей),
- Equals, GetHashCode - обов'язково при перевантаженні == та !=,
- ToString - для організації зручного виводу значення полів у консоль.

### Завдання 4.
Створено базовий клас «Матриця» - «Matrix». У цьому класі виконано перевантаження методів:
- + (для додавання матриць),
- – (для віднімання матриць).
- == != (перевірка матриць на рівність/нерівність)
- Equals, GetHashCode - обов'язково при перевантаженні == та !=,
- PrintMatrix - для організації зручного виводу значення полів у консоль.

Два варіанти множення матриць реалізовано у двох класах нащадках.
- * У класі MatrixScMult - множення матриці на число (скалярне множення);
- * У класі MatrixFullMult - множення матриць одна на одну (повне множення).

## Д.З. 5 Збирання сміття.
### Завдання 1:

Створіть клас «П'єса» («Play»), який має наступні поля:
- Title (назва п'єси);
- Author (П.І.Б. автора);
- Genre (жанр);
- Year (рік); 
 Реалізовано методи:
- GetAge (вираховую скількі років п'єсі);
- IsClassic (визначае чи є п'єса класичною (більше 100 років));
- DisplayInfo (виводить поля класа);

До класу додано деструктор.

## Завдання 2:

Створіть клас «Магазин» («Store»), який має наступні поля:
StoreName (назва магазину);
Address = (адреса магазину);
StoreType = (тип магазину);
IsOpen = (булеве значення чи відкритий магазин);

Реалізовано методи:
- OpenStore (відкриває магазин);
- CloseStore (закриває магазин);
- ServeCustomer (визначає чи можна зараз обслужити конкретного покупця);
- DisplayInfo (виводить поля класа).
- 
У класі реалізовувано інтерфейс IDisposable та написано код для виклику методу Dispose.

## Завдання 3:

Створено класи нащадки SuccessorPlay (Play) а SuccessorStore (Store)

Додано до класу SuccessorPlay  реалізацію інтерфейсу IDisposable.

Додано до класу SuccessorStore реалізацію деструктора.


## Д.З 6  DoctorAppointment.
- Створено інтерфейс користувача у консолі де можна вибрати тип даних(JSON, XML ...) та тип акцї.
- Безпосередньо обробку даних з консолі виконують менеджери (PatientManager, DoctorManager, AppointmentManager).
- DoctorService, PatientService, та AppointmentService — це сервіси для керування даними про лікарів,
  пацієнтів і зустрічі відповідно. Зроблено базовий інтерфейс IGenericService для усіх сервісних інтерфейсів.
- усі сутності (Patient, Doctor, Appointment) зберігаються в репозіторіях (PatientRepository, DoctorRepository,
  AppointmentRepository) які походять від базового GenericRepository
- Репозіторії працюють зі стандартними методами (Creat, Delete, GetAll, GetById ...) серелізуя дані
  в залежності від переданого типу.
- Серелізація/десерелізація даних виконується за допомогою  JsonDataSerializerService,  XmlDataSerializerService
- для роботи з xml для всих сутностей створені відповідні колекції.
- за допомогою класу PathHelper реалізовано використання відносних замість абсолютних шляхів.
- додані нові типи до існуючих Enum, а також створено нові (DataFormatEnum, MenuAction).
- Щоб уникнути dynamic створено клас AppSettings.

## Д.З. 7 Threading

- Є перукарня, в якій працює один перукар (Barber).
- у перукарні є три крісла для очікування (waitingRoom).
- На початку робочого дня: програма виводить повідомлення про початок роботи.
- На початку дня клієнтів немає і перукар (Barber) спочатку засинає в очікуванні першого клієнта.
- Протягом робочого дня приходить 10 клієнтів. Спочатку приходить 5 клієнтів, потім є пауза, після якої приходять 
  ще 5 клієнтів. Перший клієнт будить перукаря, після чого займає крісло для стрижки та перукар його стриже. 
  Інші займають чергу, і три з них можуть розташуватись у залі очікування.
- Якщо клієнт будить перукаря, то виводиться повідомлення про пробудження перукаря клієнтом.
- У процесі стрижки виводиться відповідне повідомлення.
- Клієнт (Customer) перевіряє наявність місць у залі очікування. Якщо місць немає (всі три крісла зайняті), 
  він йде, і виводиться повідомлення про його звільнення.
- Якщо місце є, клієнт стає в чергу, якщо перукар спить, клієнт будить його.
- Перукар перевіряє, чи є клієнти у черзі. Якщо черга порожня, перукар засинає, та виводиться відповідне повідомлення.
- Якщо є клієнт який чекає на стрижку, перукар пересаджує його у своє крісло та починає стрижку.
- Черга клієнтів (customerQueue) використовується для зберігання Id клієнтів.
- У консоль виводиться з Id всіх клієнтів, які чекають у черзі.
- Всього на день приходить 10 клієнтів, тобто коли якщо вже немає клієнтів і вже створено останнього (10), то
  перукар завершує роботу, перукарнюя зачиняється  та виводиться відповідне повідомлення.

## Д.З. 8 MS SQL Server. Queries.

Опис структури бази даних University:

### Таблиця Students – містить інформацію про студентів:

- StudentID (PK): Ідентифікатор студента.
- FirstName, Patronymic, Surname: Ім'я, по батькові, прізвище.
- BirthDate: Дата народження.
- City: Місто проживання.
- Email: Електронна пошта.
- Phone: Телефон.
- CountryID (FK): Посилання на країну (з таблиці Countries).
- GroupID (FK): Посилання на назву групу (з таблиці Groups).

### Таблиця Countries – містить інформацію про країни звідки студенти
- CountryID (PK): Ідентифікатор країни.
- CountryName: Назва країни (унікальна).

### Таблиця Groups – містить інформацію про групи студентів
- GroupID (PK): Ідентифікатор групи.
- GroupName: Назва групи (унікальна).

### Таблиця Subjects – містить інформацію про предмети, які вивчають студенти
- SubjectID (PK): Унікальний ідентифікатор предмета.
- SubjectName: Назва предмета (унікальна).

### Таблиця StudentGrades – містить інформацію про оцінки та предмети з максимальними та мінімальними оцінками, 
  середні оцінки для кожного студента:
- StudentGradeID (PK): Ідентифікатор запису про оцінки.
- StudentID (FK): Посилання на студента (з таблиці Students).
- AverageGrade: Середня оцінка студента.
- MinSubjectID (FK): Посилання на предмет з мінімальною оцінкою (з таблиці Subjects).
- MaxSubjectID (FK): Посилання на предмет з максимальною оцінкою (з таблиці Subjects).



## Д.З. 10 MS SQL Server. Queries. BarberShop

### Таблиця Barbers (Перукарі)
Зберігає інформацію про всіх працівників-перукарів.

BarberId: Унікальний ідентифікатор перукаря (первинний ключ).
FirstName: Ім’я перукаря (обов’язкове).
Surname: Прізвище перукаря (обов’язкове).
Patronymic: По-батькові (необов’язкове).
Gender: Стать перукаря (Чоловік або Жінка) (обов’язкове).
PhoneNumber: Номер телефону (унікальний).
Email: Електронна адреса (унікальна, необов’язкова).
DateOfBirth: Дата народження (необов’язкова, вік має бути >= 21 року).
HiringDate: Дата прийняття на роботу (обов’язкова).
Position: Позиція у барбершопі (Шеф (тільки один), Сеньйор, Джуніор) (обов’язкова).
RatingsAverage: Середня оцінка перукаря (дефолтне значення — 0).

### Таблиця Services (Послуги)
Зберігає інформацію про всі послуги, які надає салон.
ServiceId: Унікальний ідентифікатор послуги (первинний ключ).
ServiceName: Назва послуги (обов’язкова).
DurationMinutes: Тривалість послуги у хвилинах (обов’язкова).
Price: Вартість послуги у форматі DECIMAL (обов’язкова).

### Таблиця BarberServices (Послуги перукарів)
Зберігає інформацію про те, які послуги може виконувати кожен перукар.

BarberServiceId: Унікальний ідентифікатор (первинний ключ).
BarberId: Ідентифікатор перукаря (зовнішній ключ).
ServiceId: Ідентифікатор послуги (зовнішній ключ).
Унікальне поєднання BarberId та ServiceId.

### Таблиця Schedules (Розклад роботи)
Зберігає інформацію про робочі графіки перукарів.

ScheduleId: Унікальний ідентифікатор графіка (первинний ключ).
BarberId: Ідентифікатор перукаря (зовнішній ключ).
DayOfWeek: День тижня (Понеділок, Вівторок тощо).
AvailableTimeStart: Час початку роботи.
AvailableTimeEnd: Час закінчення роботи.
Час початку роботи має бути меншим за час закінчення.


### Таблиця Clients (Клієнти)
Зберігає інформацію про клієнтів салону.

ClientId: Унікальний ідентифікатор клієнта (первинний ключ).
FirstName: Ім’я клієнта (обов’язкове).
Surname: Прізвище клієнта (обов’язкове).
Patronymic: По-батькові (необов’язкове).
PhoneNumber: Номер телефону (унікальний).
Email: Електронна адреса (унікальна, необов’язкова).

### Таблиця Appointments (Записи на послуги)
Зберігає інформацію про всі записи клієнтів до перукарів.

AppointmentId: Унікальний ідентифікатор запису (первинний ключ).
ClientId: Ідентифікатор клієнта (зовнішній ключ).
BarberId: Ідентифікатор перукаря (зовнішній ключ).
AppointmentDate: Дата запису.
AppointmentTime: Час запису.
TotalPrice: Загальна вартість послуг.
Status: Статус запису (0 — незавершений, 1 — завершений).

### Таблиця Feedbacks (Відгуки)
Зберігає відгуки клієнтів про надані послуги.

FeedbackId: Унікальний ідентифікатор відгуку (первинний ключ).
ClientId: Ідентифікатор клієнта (зовнішній ключ).
BarberId: Ідентифікатор перукаря (зовнішній ключ).
Rating: Оцінка клієнта (2–10).
Comment: Коментар клієнта.

### Реалізовано:
### Функції користувача:

- Функцію, яка повертає ПІБ всіх барберів салону.
- Функцію, яка повертає інформацію про всіх синьйор-барберів.
- Функцію, яка повертає вітання в стилі «Hello, ІМ'Я!» Де ІМ'Я передається як параметр. 
- Функцію, яка повертає інформацію про поточну кількість хвилин;
- Функцію, яка повертає інформацію про поточний рік;
- Функцію, яка повертає інформацію про те: парний або непарний рік;
- Функцію, яка приймає число і повертає yes, якщо число просте і no, якщо число не просте;
- Функцію, яка приймає як параметри п'ять чисел. Повертає суму мінімального та максимального значення з 
  переданих п'яти параметрів;
- Функцію, яка показує всі парні або непарні числа в переданому діапазоні. Функція приймає три параметри: 
  початок діапазону, кінець діапазону, парне чи непарне показувати.

### Збережені процедури

- Процедуру, яка повертає інформацію про всіх синьйор-барберів.
- Процедуру, яка повертає інформацію про всіх барберів, які можуть надати послугу традиційного гоління бороди.
- Процедуру, яка повертає інформацію про всіх барберів, які можуть надати конкретну послугу. 
  Інформація про потрібну послугу надається як параметр.
- Процедуру, яка повертає інформацію про всіх барберів, які працюють понад зазначену кількість років. 
  Кількість років передається як параметр.
- Процедуру, яка повертає кількість синьйор-барберів та кількість джуніор-барберів.
- Процедуру, яка повертає інформацію про постійних клієнтів. Критерій постійного клієнта: був у салоні задану 
  кількість разів. Кількість передається як параметр.
- Процедуру, яка приймає строку та виводить її (приймає та виводить «Hello, world!»);
- Процедуру, яка повертає інформацію про поточний час;
- Процедуру, яка повертає інформацію про поточну дату;
- Процедуру, яка приймає три числа і повертає їхню суму;
- Процедуру, яка приймає три числа і повертає середньоарифметичне трьох чисел;
- Процедуру, яка приймає три числа і повертає максимальне значення;
- Процедуру, яка приймає три числа і повертає мінімальне значення;
- Процедуру, яка приймає число та символ та відображається  кількість символів, що дорівнює числу. 
- Процедуру, яка приймає як параметр число і повертає його факторіал.
- Процедуру, яка приймає два числові параметри. Перший параметр – це число. Другий параметр – це ступінь. 
  Процедура повертає число, зведене до ступеня. 

## Тригери

- Тригер, який забороняє можливість видалення інформації про чиф-барбер, якщо не додано другий чиф-барбер.
- Тригер, який забороняє додавати барберів молодше 21 року

Увесь код розділено на шість файлів.
- SQLQuery1_creating_table  - містить код для створення бази та таблиць;
- SQLQuery2_filling_data - містить код для наповнення таблиць данними;
- SQLQuery3_filling_proc - містить код допоміжної процедури, яка додає барбера з можливими для нього послугами;
- SQLQuery4_func - містить код функцій, які треба реалізувати у другому блоку завданнь;
- SQLQuery5_proc - містить код процедур, які треба реалізувати у третьому блоку завданнь
- SQLQuery6_trig_proc_func - містить код функцій, процедур, тригерів, які треба реалізувати у першому 
  блоку завданнь


## Д.З. 12 Cinema poster. (Киноафиша)
Основные сущности проекта:
### Movie (Фильм):
- Id — идентификатор фильма. (PK)
- Title — название фильма.
- Description — описание фильма.
- Genre — жанр.
- DirectorId — идентификатор режиссера. (FK)
- Sessions — сеансы, на которых показывается фильм.

### Director (Режиссер):
- Id — идентификатор режиссера. (PK)
- Name — имя режиссера.
- Movies — фильмы режиссера.
-
- Session (Сеанс):

- Id — идентификатор сеанса. (PK)
- MovieId — идентификатор фильма. (АЛ)
- StartTime — время начала сеанса.
- Hall — номер зала, где идет фильм.

## Реализованные функции
- Пользователь может просматривать список доступных фильмов с кратким описанием и списком сеансов.
  Дополнительная информация открывается в модальном окне при нажатии на фильм в списке.
- Пользователь может просматривать список режиссеров.
- Пользователь может просматривать список сеансов.
- Пользователь может искать фильмы по названию, режиссеру или жанру.
  Поиск производится как по полному совпадению, так и по части фразы.

## Админпанель:

Функционал для администраторов, позволяющий:
- Добавлять, редактировать и удалять фильмы.
- Управлять сеансами (добавление, изменение, удаление).
- Управлять режиссерами (добавление, изменение, удаление).




## Д.З. 13  Internet-shop Web API.

Проект в целом соответствует принципам REST API.
Решение разделено на четыре слоя (API, Domain, Service, Repository).
Разделение использования сущностей Data и Domain выполнено на уровне сервисов.
Для этого в слое сервисов созданы кастомные методы ручного маппинга. Репозиторий работает с сущностями Data
выполненяя операций взаимодействия с базой данных, а сервис — выполняет преобразуование их в сущности Domain.
Контроллеры данные из сервисов и работают только с сущностями из слоя Domain.

Ниже приведено описание основных возможностей API:

### Категории (Categories) Методы:
- GET /api/categories  Получить список всех категорий.
- GET /api/categories/{id} Получить информацию о категорию по ее идентификатору.
- POST /api/categories  Добавить новой категории.
- PUT /api/categories/{id}  Обновить информацию о категории.
- DELETE /api/categories/{id} Удалить категорию по ID.
- GET api/Category/{categoryId}/with-products Возвращает категорию (categoryId), со всеми ее продуктами.

### Склад (Stocks) Методы:
- GET /api/stocks  Получить список всех товаров на складе.
- GET /api/stocks/{id} Получить информацию о товаре по его идентификатору.
- POST /api/stocks  Добавить новый товар на складе.
- PUT /api/stocks/{id}  Обновить информацию о товаре на складе.
- DELETE /api/stocks/{id} Удалить товар на складе по ID.

### Продукты (Products) Методы:
- GET /api/products  Получить список всех продуктов.
- GET /api/products/{id} Получить информацию о продукте по его идентификатору.
- POST /api/products  Добавить новый продукт.
- PUT /api/products/{id}  Обновить информацию о продукте.
- DELETE /api/products/{id} Удалить продукт по ID.
- GET api/Product/ByCategory/{categoryId} Возвращает список продуктов, указанной категории (categoryId (int)).
- GET api/Product/ByName/{name}  Возвращает список продуктов, по имени (name(string)) точно или содержит его.

### Пользователи (Users) Методы:

- GET /api/users Получить список всех пользователей.
- GET /api/users/{id} Получить информацию о пользователе по ID.
- POST /api/users Создать нового пользователя.
- PUT /api/users/{id} Изменить информацию о пользователе.
- DELETE /api/users/{id} Удалить пользователя.
- GET api/Product/ByCategory/{categoryId} Возвращает список продуктов, принадлежащих указанной категории (categoryId (int)).

### Корзина (Cart) Методы:
- GET /api/Cart Получить список всех корзин.
- GET: api/Cart/carts-by-product/{productId} Возвращает все корзины, в которых есть указанный продукт
  (Product по его Id).
- GET: api/Cart/{id} Возвращает корзину (Cart) по её идентификатору (id).
- POST: api/Cart/find Этот метод позволяет выполнять поиск корзин (Cart) по заданному условию,
  переданному в теле запроса в виде выражения.
- CreateCart
- POST: api/Cart Создаёт новую корзину (Cart).
- PUT: api/Cart/{id} Обновляет корзину с указанным идентификатором (id).
- DELETE: api/Cart/{id} Удаляет корзину по её идентификатору (id).

### Элементы корзины (CartItem) Методы:
- GET: api/CartItem Возвращает список всех элементов корзины, содержащихся в системе.
- GET: api/CartItem/{id} Возвращает элемент корзины с указанным идентификатором.
- POST: api/CartItem Добавляет новый элемент в корзину, используя данные из тела запроса.
- PUT: api/CartItem/{id} Обновляет данные элемента корзины с указанным идентификатором.
- DELETE: api/CartItem/{id} Удаляет элемент корзины с указанным идентификатором из системы.
- GET: api/CartItem/items-in-cart/{cartId} Получение всех элементов корзины для определённой корзины (по id)

### Заказы (Orders) Методы:
- GET /api/orders Получить список всех заказов.
- GET /api/orders/{id} Получить информацию о заказе по ID.
- POST /api/orders Создать новый заказ.
- PUT /api/orders/{id} Обновить информацию о заказе.
- DELETE /api/orders/{id} Удалить заказ.
- GET: api/Order/{id}/items-in-order Этот метод получает подробную информацию о заказе с указанным id,
  отдает список элементов заказа (OrderItems).

### Элементы заказа (Order Items) Методы:
- GET /api/order-items Получить список всех элементов всех заказов.
- GET /api/order-items/{id} Получить информацию о элементе заказа по ID.
- POST /api/order-items Добавить новый элемент в заказ.
- PUT /api/order-items/{id} Обновить элемент заказа.
- DELETE /api/order-items/{id} Удалить элемент заказа.






## Д.З. 14   Web site card.

### Структура проекту:

- index.html
#### Головна HTML-сторінка сайту, яка включає:
- Заголовок
- Бокове меню
- Основний контент
- Футер

- styles.cs
#### Стилі для всіх елементів сайту:

- Стилі для заголовка та основного меню.
- Стилі для бокового меню та його підменю.
- Стилі для розділів контенту

-  changeColor.js
#### Скрипт для плавної зміни фону основного контенту (<main>). 
- Скрипт змінює фоновий колір кожні 15 секунд.
- Підтримує плавний перехід кольорів за допомогою CSS.

- myphoto.jpg  
#### Фотографія власника, що відображається в заголовку.