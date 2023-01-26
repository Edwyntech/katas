namespace Katas.Tests;

public class FizzBuzzTests
{
    private FizzBuzz _fizzBuzz;
    
    [SetUp]
    public void Setup()
    {
        _fizzBuzz = new FizzBuzz();
    }

    [TestCase(1, "1")]
    [TestCase(3, "Fizz")]
    [TestCase(5, "Buzz")]
    [TestCase(10, "Buzz")]
    [TestCase(15, "FizzBuzz")]
    [TestCase(27, "Fizz")]
    [TestCase(30, "FizzBuzz")]
    public void Test(int n, string expected)
    {
        Assert.That(_fizzBuzz.Print(n), Is.EqualTo(expected));
    }
}