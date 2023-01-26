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
            var newState = new int[_rows, _columns];
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    newState[i, j] = NextStateForCell(i, j);
                }
            }

            _gridState = newState;
        }

        private int NextStateForCell(int i, int j)
        {
            var neighborsAlive = CalculateLivingNeighbors(i, j);
            var cellValue = _gridState[i, j];
            switch (cellValue)
            {
                case DeadCell when neighborsAlive == 3:
                    return AliveCell;
                case AliveCell when neighborsAlive is < 2 or > 3:
                    return DeadCell;
                default:
                    return cellValue;
            }
        }

        private int CalculateLivingNeighbors(int i, int j)
        {
            var neighborsAlive = 0;
            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    //Edge
                    if (i + x < 0 || i + x > _rows - 1 || y + j < 0 || y + j > _columns - 1)
                    {
                        continue;
                    }

                    neighborsAlive += _gridState[i + x, y + j];
                }
            }

            neighborsAlive -= _gridState[i, j];
            return neighborsAlive;
        }

        private bool Equals(Board other)
        {
            return _gridState.Equals(other._gridState) && _rows == other._rows && _columns == other._columns;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Board) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _gridState.GetHashCode();
                hashCode = (hashCode * 397) ^ _rows;
                hashCode = (hashCode * 397) ^ _columns;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(_gridState)}: {_gridState}, {nameof(_rows)}: {_rows}, {nameof(_columns)}: {_columns}";
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