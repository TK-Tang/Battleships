using System.Collections.Generic;

namespace Battleships.Models
{
    public class Ship
    {
        public Board Board;
        public List<Cell> Hitbox;
        public ShipStatus Status;

        public Ship(Board board)
        {
            Board = board;
            Hitbox = new List<Cell>();
            Status = ShipStatus.Operational;
        }
    }
}
