using Katas.LINQ;

namespace Katas.Tests;

[TestFixture]
public class NewLinqTests
{
    private NewLinq _newLinq;
    
    [SetUp]
    public void Setup()
    {
        _newLinq = new NewLinq();
    }

    [Test]
    public void SelectIntSquareTest()
    {
        var list = new List<int> {1, 2, 3, 4};
        var expectedList = new List<int> {1, 4, 9, 16};
        
        Assert.That(_newLinq.Select(list, x => x * x), Is.EquivalentTo(expectedList));
    }
    
    [Test]
    public void WhereIntEvenTest()
    {
        var list = new List<int> {1, 2, 3, 4};
        var expectedList = new List<int> { 2, 4};
        
        Assert.That(_newLinq.Where(list, x => x % 2 == 0), Is.EquivalentTo(expectedList));
    }
    
    [Test]
    public void AnyIntEvenTest()
    {
        var list1 = new List<int> {1, 2, 3, 5};
        var list2 = new List<int> {1, 3, 5, 9};
        
        Assert.That(_newLinq.Any(list1, x => x % 2 == 0), Is.True);
        Assert.That(_newLinq.Any(list2, x => x % 2 == 0), Is.False);
    }
}