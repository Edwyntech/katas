namespace Katas.GameOfLife
{
    public class Board
    {
        private const int DeadCell = 0;
        private const int AliveCell = 1;

        private int[,] _gridState;
        private int _rows;
        private int _columns;

        public Board(int[,] initialGridState)
        {
            if (initialGridState == null)
            {
                throw new ArgumentNullException(nameof(initialGridState), "Value cannot be NULL");
            }

            if (!IsValid(initialGridState))
            {
                throw new ArgumentException("initialState must be a 2D array with at least 1 row and 1 column with values of 0 and 1",
                    nameof(initialGridState));
            }

            _gridState = initialGridState;
            _rows = initialGridState.GetLength(0);
            _columns = initialGridState.GetLength(1);
        }

        private bool IsValid(int[,] grid)
        {
            if (grid.GetLength(0) < 1 || grid.GetLength(1) < 1)
            {
                return false;
            }

            foreach (var cell in grid)
            {
                if (cell is < 0 or > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public int[,] GetGridState()
        {
            return _gridState;
        }

        public void Evolve()
        {
            // TODO : add your code
            throw new NotImplementedException();
        }

        private int NextStateForCell(int i, int j)
        {
            // TODO : add your code
            throw new NotImplementedException();
        }

        private int CalculateLivingNeighbors(int i, int j)
        {
            // TODO : add your code
            throw new NotImplementedException();
        }

        public static Board Random(int rows = 10, int columns = 10)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var state = new int[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    state[i, j] = random.Next(0, 2);
                }
            }

            return new Board(state);
        }
    }
}