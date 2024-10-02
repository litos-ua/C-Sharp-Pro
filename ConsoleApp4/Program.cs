using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
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

                Console.WriteLine(comEmp2 == comEmp3 ? $"{comEmp3.Name} salary is equal to {comEmp1.Name} salary" :
                                                       $"{comEmp3.Name} salary is not equal to {comEmp1.Name} salary");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error creating object: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
