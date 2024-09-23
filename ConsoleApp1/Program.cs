



using System;
using System.Collections.Generic;

public class Calculator
{
    private delegate float TwoNumberOperation(float a, float b);
    private delegate float OneNumberOperation(float a);

    public void Start()
    {
        Dictionary<string, TwoNumberOperation> twoNumberOperations = new Dictionary<string, TwoNumberOperation>()
        {
            { "add", MathOperations.Add },
            { "diff", MathOperations.Diff },
            { "mult", MathOperations.Mult },
            { "div", MathOperations.Div }
        };

        Dictionary<string, OneNumberOperation> oneNumberOperations = new Dictionary<string, OneNumberOperation>()
        {
            { "sqrt", MathOperations.Sqrt },
            { "sin", MathOperations.Sin },
            { "cos", MathOperations.Cos }
        };

        while (true)
        {
            Console.WriteLine("What action do you want to do? Add, Diff, Mult, Div, Sqrt, Sin, Cos");

            string action = ValidateActionInput(twoNumberOperations, oneNumberOperations);

            if (twoNumberOperations.ContainsKey(action))
            {
                float firstNumber = GetValidNumber("Enter first number:");
                float secondNumber = GetValidNumber("Enter second number:");
                float result = twoNumberOperations[action](firstNumber, secondNumber);
                Console.WriteLine($"Result: {result}");
            }
            else if (oneNumberOperations.ContainsKey(action))
            {
                float number = GetValidNumber("Enter number:");
                float result = oneNumberOperations[action](number);
                Console.WriteLine($"Result: {result}");
            }

            if (!AskToContinue())
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }

    // Method for inputting a mathematical operation with validation

    private string ValidateActionInput(Dictionary<string, TwoNumberOperation> twoNumberOps, Dictionary<string, OneNumberOperation> oneNumberOps)
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
                else
                {
                    // Return to the beginning of the program, re-request for action input
                    Console.WriteLine("What action do you want to do? Add, Diff, Mult, Div, Sqrt, Sin, Cos");
                    continue; 
                }
            }

            if (string.IsNullOrEmpty(KindOfAction) || (!twoNumberOps.ContainsKey(KindOfAction) && !oneNumberOps.ContainsKey(KindOfAction)))
            {
                Console.WriteLine("Unknown operation. Please enter a valid action (Add, Diff, Mult, Div, Sqrt, Sin, Cos) or enter 'Esc' to exit.");
            }
            else
            {
                return KindOfAction;
            }
        }
    }



    // Method for entering numbers with validation
    private float GetValidNumber(string prompt)
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
                Console.WriteLine("This is bad digit. Please enter correct digit.");
            }
        }
    }

    // Method for the question of continuation of work

    private bool AskToContinue()
    {
        while (true)
        {
            Console.WriteLine("Do you want to continue working with me? Y/N");
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



public class MathOperations
{
    public static float Add(float a, float b) => a + b;

    public static float Diff(float a, float b) => a - b;

    public static float Mult(float a, float b) => a * b;

    public static float Div(float a, float b)
    {
        if (b == 0)
        {
            Console.WriteLine("Cannot divide by zero.");
            return float.NaN;
        }
        return a / b;
    }

    public static float Sqrt(float a)
    {
        if (a < 0)
        {
            Console.WriteLine("It is impossible to extract the square root of a negative number");
            return float.NaN;
        }
        return (float)Math.Sqrt(a);
    }

    public static float Sin(float a) => (float)Math.Sin(a);

    public static float Cos(float a) => (float)Math.Cos(a);
}




class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        calculator.Start();
    }
}