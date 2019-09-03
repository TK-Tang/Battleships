using System;
using System.Collections.Generic;

namespace Battleships.Models
{
    public class Board
    {
        public Cell[,] Field;
        public List<Ship> Fleet;
        public Player Owner { get; set; }

        public Board()
        {
            Fleet = new List<Ship>();
            Field = new Cell[GameSettings.MaxBoardSize, GameSettings.MaxBoardSize];

            var rows = Field.GetLength(0);
            var cols = Field.GetLength(1);

            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < cols; ++j)
                {
                    Field[i, j] = new Cell(this, i, j);
                }
            }
        }

        public bool HasFleet()
        {
            return Fleet.Count > 0;
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || x > GameSettings.MaxBoardSize - 1 || y < 0 || y > GameSettings.MaxBoardSize - 1)
            {
                return null;
            }

            return Field[x, y];
        }

        public Cell GoNorth(int x, int y, int cells)
        {
            try
            {
                return Field[x, y + cells];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Cell GoSouth(int x, int y, int cells)
        {
            try
            {
                return Field[x, y - cells];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Cell GoEast(int x, int y, int cells)
        {
            try
            {
                return Field[x + cells, y];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Cell GoWest(int x, int y, int cells)
        {
            try
            {
                return Field[x - cells, y];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
