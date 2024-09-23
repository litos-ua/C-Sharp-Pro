using System;
using System.Collections.Generic;

public class Calculator
{
    public delegate float MultiNumberOperation(float a, float b);
    public delegate float SingleNumberOperation(float a);

    public static void StartToCalculate()
    {
        Dictionary<string, MultiNumberOperation> twoNumberOperations = new Dictionary<string, MultiNumberOperation>()
        {
            { "add", MathOperations.Add },
            { "diff", MathOperations.Diff },
            { "mult", MathOperations.Mult },
            { "div", MathOperations.Div }
        };

        Dictionary<string, SingleNumberOperation> oneNumberOperations = new Dictionary<string, SingleNumberOperation>()
        {
            { "sqrt", MathOperations.Sqrt },
            { "sin", MathOperations.Sin },
            { "cos", MathOperations.Cos }
        };

        while (true)
        {
            Console.WriteLine("What action do you want to do? Add, Diff, Mult, Div, Sqrt, Sin, Cos");

            string action = InputAndValidation.ValidateActionInput(twoNumberOperations, oneNumberOperations);

            if (twoNumberOperations.ContainsKey(action))
            {
                float firstNumber = InputAndValidation.GetValidNumber("Enter first number:");
                float secondNumber = InputAndValidation.GetValidNumber("Enter second number:");
                float result = twoNumberOperations[action](firstNumber, secondNumber);
                Console.WriteLine($"Result: {result}");
            }
            else if (oneNumberOperations.ContainsKey(action))
            {
                float number = InputAndValidation.GetValidNumber("Enter number:");
                float result = oneNumberOperations[action](number);
                Console.WriteLine($"Result: {result}");
            }

            if (!InputAndValidation.AskToContinue())
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}

