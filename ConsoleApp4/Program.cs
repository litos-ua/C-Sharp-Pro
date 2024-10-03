using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Enter of the homework number ('1', '2', '3', '4').");
            Int32.TryParse(Console.ReadLine(), out int taskNumber);

            switch (taskNumber)
            {
                case 1:
                    Console.WriteLine("Task 4.1");

                    try
                    {
                        Employee comEmp1 = new Employee("Mykola", "mykola79@gmail.com", "System Programming", 30000);
                        Employee comEmp2 = new Employee("Andriy", "mykola81@gmail.com", "System Programming", 35000);
                        Employee comEmp3 = new Employee("Katerina", "katerina91@gmail.com", "System Programming", 32000);

                        Console.WriteLine(comEmp1);
                        Console.WriteLine(comEmp2);
                        Console.WriteLine(comEmp3);

                        comEmp1 += 5000;
                        comEmp2 -= 3000;

                        Console.WriteLine(comEmp1);
                        Console.WriteLine(comEmp2);

                        if (comEmp1 > comEmp2)
                            Console.WriteLine($"{comEmp1.Name} earns more than {comEmp2.Name}");
                        else if (comEmp1 < comEmp2)
                            Console.WriteLine($"{comEmp2.Name} earns more than {comEmp1.Name}");
                        else
                            Console.WriteLine($"{comEmp2.Name} salary is equal to {comEmp1.Name} salary");

                        Console.WriteLine(comEmp1 == comEmp2 ? $"{comEmp2.Name} salary is equal to {comEmp1.Name} salary" :
                                                               $"{comEmp2.Name} salary is not equal to {comEmp1.Name} salary");

                        Console.WriteLine(comEmp2 == comEmp3 ? $"{comEmp3.Name} salary is equal to {comEmp2.Name} salary" :
                                                               $"{comEmp3.Name} salary is not equal to {comEmp2.Name} salary");

                        Console.WriteLine(comEmp2 != comEmp3 ? $"{comEmp3.Name} salary is not equal to {comEmp2.Name} salary" :
                                                               $"{comEmp3.Name} salary is equal to {comEmp2.Name} salary");

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error creating object: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                case 2:
                    Console.WriteLine("\n Task 4.2");

                    try
                    {
                        City city1 = new City("Kharkiv", "Ukraine", 2800000, 2500000000);
                        City city2 = new City("Gdansk", "Polska", 720000, 5100000000);
                        City city3 = new City("Odessa", "Ukraine", 1000000, 21000000000);

                        Console.WriteLine(city1);
                        Console.WriteLine(city2);
                        Console.WriteLine(city3);

                        city1 += 110000;
                        city2 -= 70200;
                        city3 += 77000;

                        Console.WriteLine(city1);
                        Console.WriteLine(city2);
                        Console.WriteLine(city3);

                        if (city1 > city2)
                            Console.WriteLine($"{city1.CityName} has a larger population than {city2.CityName}");
                        else if (city1 < city2)
                            Console.WriteLine($"{city2.CityName} has a larger population than {city1.CityName}");
                        else
                            Console.WriteLine($"{city1.CityName} and {city2.CityName} have the same population");

                        Console.WriteLine(city3 == city2 ? $"{city3.CityName} has the same population as {city2.CityName}" :
                                                           $"{city3.CityName} does not have the same population as {city2.CityName}");

                        Console.WriteLine(city3 != city2 ? $"{city3.CityName} does not have the same population as {city2.CityName}" :
                                                           $"{city3.CityName} has the same population as {city2.CityName}");

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error: {ex.Message}");
                    }
                    break;
                case 3:
                    Console.WriteLine("\n Task 4.3");

                    try
                    {
                        CreditCard card1 = new CreditCard("1234 5678 9101 1121", "Marina", new DateTime(2025, 12, 22), 123, "Visa", 5021);
                        CreditCard card2 = new CreditCard("4321 8765 0191 2111", "Dmiriy", new DateTime(2027, 06, 21), 456, "Mastercard", 3100);
                        CreditCard card3 = new CreditCard("1234 7154 2201 1129", "Marina", new DateTime(2027, 07, 11), 871, "Visa", 1021);

                        Console.WriteLine(card1);
                        Console.WriteLine(card2);
                        Console.WriteLine(card3);

                        card1 += 2000;
                        card2 -= 1500;
                        card3 += 771;

                        Console.WriteLine(card1);
                        Console.WriteLine(card2);
                        Console.WriteLine(card3);

                        if (card1 > card2)
                            Console.WriteLine($"{card1.CardNumber} has more money than {card2.CardNumber}");
                        else if (card1 < card2)
                            Console.WriteLine($"{card2.CardNumber} has more money than {card1.CardNumber}");
                        else
                            Console.WriteLine($"Both cards have the same amount of money.");

                        Console.WriteLine(card3 == 871 ? $"CVC codes of the {card3.CardNumber} is correct" :
                            $"CVC codes of the {card3.CardNumber} doesn't match");

                        Console.WriteLine(card1 != 871 ? $"CVC codes of the {card1.CardNumber} doesn't match" :
                            $"CVC codes of the {card1.CardNumber} is correct");

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                case 4:
                    Console.WriteLine("\n Task 4.4");


                    try
                    {
                        Matrix matrix1 = new Matrix(3, 3);

                        matrix1[0, 0] = 1;
                        matrix1[0, 1] = 2;
                        matrix1[0, 2] = 3;
                        matrix1[1, 0] = 4;
                        matrix1[1, 1] = 5;
                        matrix1[1, 2] = 6;
                        matrix1[2, 0] = 7;
                        matrix1[2, 1] = 8;
                        matrix1[2, 2] = 9;

                        matrix1.PrintMatrix();

                        Matrix matrix2 = new Matrix(3, 3);
                        Console.WriteLine();

                        matrix2[0, 0] = 11;
                        matrix2[0, 1] = 12;
                        matrix2[0, 2] = 13;
                        matrix2[1, 0] = 14;
                        matrix2[1, 1] = 15;
                        matrix2[1, 2] = 16;
                        matrix2[2, 0] = 17;
                        matrix2[2, 1] = 18;
                        matrix2[2, 2] = 19;

                        matrix2.PrintMatrix();
                        Console.WriteLine();

                        Matrix matrix = new Matrix(3, 3);
                        matrix = matrix1 + matrix2;
                        matrix.PrintMatrix();
                        Console.WriteLine();
                        matrix = matrix1 - matrix2;
                        matrix.PrintMatrix();

                        Console.WriteLine();
                        matrix = matrix1 * 7;
                        matrix.PrintMatrix();
                        Console.WriteLine();

                        if (matrix1 == matrix2)
                        {
                            Console.WriteLine("The matrices are equal");
                        }

                        else
                        {
                            Console.WriteLine("The matrices are not equal");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    break;
                default:
                    Console.WriteLine("Invalid task number.");
                    return;
            }



            
        }
    }
}
