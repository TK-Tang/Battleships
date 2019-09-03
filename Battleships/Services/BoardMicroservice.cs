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

            Console.Write("Coordinates [x-y]: ");

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

            return (false, null);
        }

        public (Player, Player, Board, Board, GameMode) SetupPvEBoards()
        {
            var board1 = new Board();
            var player1 = new Player("Player 1", board1, false);

            var board2 = new Board();
            var player2 = new Player("Player 2", board2, true);

            return (player1, player2, board1, board2, GameMode.PvE);
        }

        public (Player, Player, Board, Board, GameMode) SetupPvPBoards()
        {
            var board1 = new Board();
            var player1 = new Player("Player 1", board1, false);

            var board2 = new Board();
            var player2 = new Player("Player 2", board2, false);

            return (player1, player2, board1, board2, GameMode.PvP);
        }
    }
}
