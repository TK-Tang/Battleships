using Battleships.Models;
using Battleships.Services;
using NUnit.Framework;

namespace Battleships.Tests
{
    [TestFixture]
    public class ShipPlacementServiceTest
    {
        private BoardMicroservice _boardService;
        private ShipPlacementService _shipPlacementService;
        private Board _board1;
        private Board _board2;
        private Player _player1;
        private Player _player2;
        private GameMode _gameMode;

        [SetUp]
        public void SetUp()
        {
            _boardService = new BoardMicroservice();
            _shipPlacementService = new ShipPlacementService();
            (_player1, _player2, _board1, _board2, _gameMode) = _boardService.SetupPvEBoards();
        }

        [Test]
        public void PlaceShipTest()
        {
            Assert.IsTrue(_shipPlacementService.PlaceShip(_board1, "1-1-n", 5)); // Legit placement
            Assert.IsFalse(_shipPlacementService.PlaceShip(_board1, "0-0-s", 5)); // Outside map boundaray
            Assert.IsFalse(_shipPlacementService.PlaceShip(_board1, "5-1-w", 5)); // Ship collision
            Assert.IsFalse(_shipPlacementService.PlaceShip(_board1, "asdf-asdf-asdf", 5)); // Invalid input
        }
    }
}