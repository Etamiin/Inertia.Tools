﻿namespace Inertia.Tools
{
    public sealed class MapGrid<T> where T : Cell
    {
        public readonly bool UseDiagonal;
        public int Width => _cells.GetLength(0);
        public int Height => _cells.GetLength(1);
        public int MaxSize => Width * Height;
        
        private T[,] _cells;
        
        public MapGrid(T[,] cells, bool diagonal)
        {
            _cells = cells;
            UseDiagonal = diagonal;

            foreach (var cell in _cells)
            {
                cell.LoadNeighbours(this);
            }
        }

        public T[,] GetCells()
        {
            return _cells;
        }

        public T GetCellByIndexes(int x, int y)
        {
            if (x < 0 || x >= _cells.GetLength(0) || y < 0 || y >= _cells.GetLength(1)) return null;

            return _cells[x, y];
        }
    }
}
