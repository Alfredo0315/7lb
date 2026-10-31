using Calculator.Core;

namespace Calculator.Tests;

public class SimpleCalculatorTests
{
    private readonly SimpleCalculator _calculator = new();

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(0.5, 0.25, 0.75)]
    public void Add_ReturnsSum(double a, double b, double expected)
    {
        Assert.Equal(expected, _calculator.Add(a, b), 5);
    }

    [Fact]
    public void Subtract_ReturnsDifference()
    {
        Assert.Equal(6, _calculator.Subtract(10, 4));
    }

    [Theory]
    [InlineData(3, 4, 12)]
    [InlineData(-2, 5, -10)]
    [InlineData(7, 0, 0)]
    public void Multiply_ReturnsProduct(double a, double b, double expected)
    {
        Assert.Equal(expected, _calculator.Multiply(a, b));
    }

    [Fact]
    public void Divide_ReturnsQuotient()
    {
        Assert.Equal(2.5, _calculator.Divide(10, 4));
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
    }

    [Theory]
    [InlineData(2, 10, 1024)]
    [InlineData(5, 0, 1)]
    [InlineData(2, -1, 0.5)]
    public void Power_ReturnsCorrectValue(double baseValue, int exponent, double expected)
    {
        Assert.Equal(expected, _calculator.Power(baseValue, exponent));
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(5, 120)]
    [InlineData(10, 3628800)]
    public void Factorial_ReturnsCorrectValue(int n, long expected)
    {
        Assert.Equal(expected, _calculator.Factorial(n));
    }

    [Fact]
    public void Factorial_NegativeNumber_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Factorial(-3));
    }

    [Theory]
    [InlineData(4, true)]
    [InlineData(7, false)]
    [InlineData(0, true)]
    [InlineData(-2, true)]
    public void IsEven_ReturnsCorrectResult(int number, bool expected)
    {
        Assert.Equal(expected, _calculator.IsEven(number));
    }

    [Theory]
    [InlineData(6, "+", 2, 8)]
    [InlineData(6, "-", 2, 4)]
    [InlineData(6, "*", 2, 12)]
    [InlineData(6, "/", 2, 3)]
    [InlineData(3, "^", 2, 9)]
    public void Calculate_PerformsOperation(double a, string op, double b, double expected)
    {
        Assert.Equal(expected, _calculator.Calculate(a, op, b));
    }

    [Fact]
    public void Calculate_UnknownOperation_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.Calculate(1, "%", 2));
    }
}
