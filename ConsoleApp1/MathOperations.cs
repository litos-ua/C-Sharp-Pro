using System;


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
