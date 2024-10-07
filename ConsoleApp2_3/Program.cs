
using System;

class Program
{
    static void Main()
    {
        var DecInputNumber = new DecNumberConversion();
        DecInputNumber.ChooseNumberSystem();
    }
}

struct DecNumberConversion
{
    private int DecNumber { get; set; }

    
    public void ChooseNumberSystem()
    {
        while (true)
        {
            Console.WriteLine("Enter the number system for conversion: Hex, Oct, Bin. Press Esc to exit.");

            string choice = Console.ReadLine()?.ToLower();

            if (choice == "esc")
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0); 
            }

            if (choice == "hex" || choice == "oct" || choice == "bin")
            {
                GetValidNumber("Please enter the number.");
                DisplayNumber(choice, DecNumber);
                return; 
            }
            else
            {
                Console.WriteLine("Unknown choice. Please enter Hex, Oct, Bin or Esc.");
            }
        }
    }

    
    private void GetValidNumber(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string inputNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputNumber))
            {
                Console.WriteLine("Please enter a number.");
                continue;
            }

            if (Int32.TryParse(inputNumber, out int number))
            {
                DecNumber = number;
                return;
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter a valid number.");
            }
        }
    }



    private void DisplayNumber(string system, int decNumber)
    {
        string convertedNumber;

        
        switch (system.ToLower())  
        {
            case "hex":
                convertedNumber = Convert.ToString(decNumber, 16);  break;
            case "oct":
                convertedNumber = Convert.ToString(decNumber, 8);   break;
            case "bin":
                //convertedNumber = Convert.ToString(decNumber, 2);   break;
                convertedNumber = ConvertToBin(decNumber); break;
            default:
                Console.WriteLine("Invalid number system");
                return;
        }

        Console.WriteLine($"DecNumber: {decNumber} = {system.ToUpper()}Number: {convertedNumber}");
    }

     private String ConvertToBin(int decNumber)
    {
        if (decNumber == 0) return "0";  
        String resBin = "";
        for (int current = decNumber; current > 0; current /= 2)
        {
            resBin = (current % 2) + resBin;
        }
        return resBin;
    }


}

