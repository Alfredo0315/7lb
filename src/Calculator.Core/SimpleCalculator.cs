namespace Calculator.Core;

/// <summary>
/// Простой калькулятор с базовыми арифметическими операциями.
/// </summary>
public class SimpleCalculator
{
    public double Add(double a, double b) => a + b;

    public double Subtract(double a, double b) => a - b;

    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Деление на ноль невозможно.");

        return a / b;
    }

    public double Power(double baseValue, int exponent) => Math.Pow(baseValue, exponent);

    public long Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Факториал определён только для n >= 0.");

        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;

        return result;
    }

    public bool IsEven(int number) => number % 2 == 0;

    /// <summary>
    /// Выполняет операцию по символу: +, -, *, /, ^.
    /// </summary>
    public double Calculate(double a, string operation, double b) => operation switch
    {
        "+" => Add(a, b),
        "-" => Subtract(a, b),
        "*" => Multiply(a, b),
        "/" => Divide(a, b),
        "^" => Power(a, (int)b),
        _ => throw new ArgumentException($"Неизвестная операция: {operation}", nameof(operation))
    };
}
