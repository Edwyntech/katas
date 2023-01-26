using Katas.GameOfLife;

namespace Katas.Tests;

[TestFixture]
public class GameOfLifeTests
{
    private static readonly int[,] TestGrid =
    {
        {1, 1, 1, 1, 0, 1, 1, 0, 0, 0},
        {1, 1, 1, 1, 0, 1, 1, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
        {0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
        {0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 1, 0, 0, 0, 0, 0, 0, 1, 1},
        {1, 1, 0, 0, 0, 0, 0, 0, 1, 1}
    };

    private static readonly int[,] ExpectedGrid =
    {
        {1, 0, 0, 1, 0, 1, 1, 0, 0, 0},
        {1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
        {1, 0, 0, 1, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
        {0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 1, 0, 0, 0, 0, 0, 0, 1, 1},
        {1, 1, 0, 0, 0, 0, 0, 0, 1, 1}
    };

    [Test]
    public void TestRandomWithZeroSize()
    {
        Assert.Throws<ArgumentException>(() => Board.Random(0, 0));
    }

    [Test]
    public void TestConstructorWithNullInitialState()
    {
        Assert.Throws<ArgumentNullException>(() => new Board(null));
    }

    [Test]
    public void TestConstructorWithInvalidValues()
    {
        int[,] arr = {{0, 0, 0, 0, 1}, {2, 0, 1, -1, 3}};
        Assert.Throws<ArgumentException>(() => new Board(arr));
    }

    [Test]
    public void TestConstructorWithInvalidSize()
    {
        var state = new int[0, 0];
        Assert.Throws<ArgumentException>(() => new Board(state));
    }

    [Test]
    public void TestEvolve()
    {
        var board = new Board(TestGrid);
        board.Evolve();
        Assert.That(ExpectedGrid, Is.EqualTo(board.GetGridState()));
    }
}