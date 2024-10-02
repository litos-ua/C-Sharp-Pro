using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Enter of the homework number ('1', '2', '3').");
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
                    break;

                default:
                    Console.WriteLine("Invalid task number.");
                    return;
            }



            
        }
    }
}
