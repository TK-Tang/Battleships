using System;
using Battleships.Models;

namespace Battleships.Services
{
    public class BoardMicroservice
    {
        public (bool, Ship) Fire(Board b, string input)
        {
            int x;
            int y;

            // Validation Block
            var inputArray = input.Split("-");
            if (inputArray.Length != 2)
            {
                return (false, null);
            }

            var isXValid = Int32.TryParse(inputArray[0], out x);
            var isYValid = Int32.TryParse(inputArray[1], out y);

            if (!isXValid || !isYValid)
            {
                return (false, null);
            }
            // Validation Block

            var cell = b.Field[x, y];
            cell.Hit = true;

            if (cell.Ship != null)
            {
                cell.Ship.Hitbox.Remove(cell);
                return (true, cell.Ship);
            }

            return (true, null);
        }

        public (Player, Player, Board, Board, GameMode) SetupPvEBoards()
        {
            var board1 = new Board();
            var player1 = new Player("Red Fleet", board1, false);
            board1.Owner = player1;

            var board2 = new Board();
            var player2 = new Player("Blue Fleet", board2, true);
            board2.Owner = player2;

            return (player1, player2, board1, board2, GameMode.PvE);
        }

        public (Player, Player, Board, Board, GameMode) SetupPvPBoards()
        {
            var board1 = new Board();
            var player1 = new Player("Red Fleet", board1, false);
            board1.Owner = player1;

            var board2 = new Board();
            var player2 = new Player("Blue Fleet", board2, false);
            board2.Owner = player2;

            return (player1, player2, board1, board2, GameMode.PvP);
        }
    }
}
