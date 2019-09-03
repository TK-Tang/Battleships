namespace Battleships.Models
{
    public class Player
    {
        public string Name;
        public Board Board;
        public bool Automated;

        public Player(string name, Board board, bool automated)
        {
            Name = name;
            Board = board;
            Automated = automated;
        }
    }
}
