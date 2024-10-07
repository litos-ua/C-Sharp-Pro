using System;
using System.Collections.Generic;

public class InputAndValidation
{
    public static string ValidateActionInput(Dictionary<string, Calculator.MultiNumberOperation> twoNumberOps, Dictionary<string, Calculator.SingleNumberOperation> oneNumberOps)
    {
        while (true)
        {
            string KindOfAction = Console.ReadLine()?.ToLower();

            if (KindOfAction == "esc")
            {
                if (!AskToContinue())
                {
                    Console.WriteLine("Good bye, see you later.");
                    Environment.Exit(0); 
                }
                else                /* Возврат к вводу математического действия */
                {
                    Console.WriteLine("What action do you want to do? Add, Diff, Mult, Div, Sqrt, Sin, Cos");
                    continue;
                }
            }

            if (string.IsNullOrEmpty(KindOfAction) || (!twoNumberOps.ContainsKey(KindOfAction) && !oneNumberOps.ContainsKey(KindOfAction)))
            {
                Console.WriteLine("Unknown operation. Please enter a valid action (Add, Diff, Mult, Div, Sqrt, Sin, Cos) or 'Esc' to exit.");
            }
            else
            {
                return KindOfAction;
            }
        }
    }

   
    public static float GetValidNumber(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string InputNumber = Console.ReadLine();

            if (InputNumber == null)
            {
                throw new Exception("Good bye, see you later.");
            }

            if (float.TryParse(InputNumber, out float number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter a valid number.");
            }
        }
    }

    
    public static bool AskToContinue()
    {
        while (true)
        {
            Console.WriteLine("Do you want to continue working? Y/N");
            string answer = Console.ReadLine();

            if (answer == null || answer.ToLower() == "n")
            {
                return false;
            }
            else if (answer.ToLower() == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter Y or N.");
            }
        }
    }
}

