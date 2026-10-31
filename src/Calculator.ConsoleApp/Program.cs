using System.Globalization;
using Calculator.Core;

var calculator = new SimpleCalculator();

Console.WriteLine("=== Простой калькулятор ===");
Console.WriteLine("Формат ввода: <число> <операция> <число>, например: 2 + 3");
Console.WriteLine("Операции: + - * / ^   |   Для выхода введите: exit");

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();

    if (input is null || input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length != 3
        || !double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var a)
        || !double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var b))
    {
        Console.WriteLine("Неверный формат. Пример: 10 / 4");
        continue;
    }

    try
    {
        var result = calculator.Calculate(a, parts[1], b);
        Console.WriteLine($"Результат: {result.ToString(CultureInfo.InvariantCulture)}");
    }
    catch (Exception ex) when (ex is ArgumentException or DivideByZeroException)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

Console.WriteLine("До свидания!");
