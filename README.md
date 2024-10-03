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




