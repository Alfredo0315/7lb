# CalculatorApp

Простое решение на C# (.NET 8) для лабораторной работы по GitHub Actions.

## Структура

```
CalculatorApp.sln
├── src/
│   ├── Calculator.Core/        — библиотека классов (SimpleCalculator)
│   └── Calculator.ConsoleApp/  — консольное приложение
└── tests/
    └── Calculator.Tests/       — unit-тесты (xUnit)
```

## Команды

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/Calculator.ConsoleApp
```

Пример работы консольного приложения:

```
> 6 * 7
Результат: 42
> 10 / 0
Ошибка: Деление на ноль невозможно.
```
