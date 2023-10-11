using Katas.MaxOccurenceChar;

namespace Katas.Tests;

[TestFixture]
public class MaxOccurenceCharTests
{
    private MaxOccurenceCharComputer _maxOccurenceCharComputer;
    
    [SetUp]
    public void Setup()
    {
        _maxOccurenceCharComputer = new MaxOccurenceCharComputer();
    }

    [TestCase("aabbbc", 'b')]
    [TestCase("abccbc", 'c')]
    [TestCase("abc", 'a')]
    public void SelectIntSquareTest(string input, char expectedResult)
    {
        Assert.That(_maxOccurenceCharComputer.ComputeMaxOccurenceChar(input), Is.EqualTo(expectedResult));
    }
}