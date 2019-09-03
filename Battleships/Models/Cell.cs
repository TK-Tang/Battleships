using System;

namespace Battleships.Models
{
    public class Cell
    {
        public int X;
        public int Y;
        public bool Hit;
        public Ship Ship;
        public Board Board;

        public static string NoMarker = "-";
        public static string MissMarker = "o";
        public static string HitMarker = "X";
        public static string FriendlyMarker = "=";

        public Cell(Board board, int x, int y)
        {
            X = x;
            Y = y;
            Hit = false;
            Ship = null;
            Board = board;
        }

        public string GetCoords()
        {
            return X + "-" + Y;
        }

        public string ToString(Board board)
        {
            if (Hit && Ship != null)
            {
                return "[" + HitMarker + "]";
            }

            if (Ship != null && Board == board)
            {
                return "[" + FriendlyMarker + "]";
            }

            if (Hit)
            {
                return "[" + MissMarker + "]";
            }

            return "[" + NoMarker + "]";
        }
    }
}
