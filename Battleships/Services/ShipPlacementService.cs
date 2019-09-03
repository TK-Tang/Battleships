using System;
using Battleships.Models;

namespace Battleships.Services
{
    public class ShipPlacementService
    {
        private readonly ConsoleMicroservice _consoleSubroutine;
        private readonly FlavourTextService _flavourTextService;

        public ShipPlacementService()
        {
            _consoleSubroutine = new ConsoleMicroservice();
            _flavourTextService = new FlavourTextService();
        }

        public bool PlaceFleet(Board board1, Board board2, int fleetCap, int shipSize, string gmSassyRemark)
        {
            var shipsLeftToPlace = fleetCap;

            while (shipsLeftToPlace != 0)
            {
                var input = _consoleSubroutine.GetInput("Invalid coordinates. Ships must be within the field of operations. Try again mate.\n");

                if (input.ToLower() == "r")
                {
                    _flavourTextService.GameMasterSpeech(gmSassyRemark);
                    shipsLeftToPlace = 0;
                    board1 = PlaceShipsRandomly(board1, shipSize, shipsLeftToPlace);

                    _flavourTextService.RadarOperatorAlliedBoard();
                    _consoleSubroutine.ShowBattleMap(board1, board1, ConsoleColor.Cyan);
                    _flavourTextService.RadarOperatorEnemyBoard();
                    _consoleSubroutine.ShowBattleMap(board1, board2, ConsoleColor.DarkBlue);

                    return true;
                }

                var result = PlaceShip(board1, input, shipSize);
                if (result)
                {
                    shipsLeftToPlace = shipsLeftToPlace - 1;
                    _flavourTextService.ShipInPosition(shipsLeftToPlace);
                }
                else
                {
                    _flavourTextService.GameMasterSpeech("Invalid coordinates. Put your ship within the board.\n");
                }

                _flavourTextService.RadarOperatorAlliedBoard();
                _consoleSubroutine.ShowBattleMap(board1, board1, ConsoleColor.Cyan);
            }

            return true;
        }

        public bool PlaceShip(Board board, string input, int shipSize)
        {
            var inputArray = input.Split("-");
            if (inputArray.Length != 3)
            {
                return false;
            }

            var xCoord = inputArray[0];
            var yCoord = inputArray[1];
            var nsew = inputArray[2]; // north, south, east, west

            var (result, x, y) = ValidateShipPlacement(board, xCoord, yCoord, nsew, shipSize);
            if (!result)
            {
                return false;
            }

            var ship = new Ship(board);
            board.Fleet.Add(ship);

            for (var i = 0; i < shipSize; i++)
            {
                Cell cell;
                switch (nsew)
                {
                    case "n":
                        cell = board.Field[x, y + i];
                        cell.Ship = ship;
                        ship.Hitbox.Add(cell);
                        break;
                    case "s":
                        cell = board.Field[x, y - i];
                        cell.Ship = ship;
                        ship.Hitbox.Add(cell);
                        break;
                    case "e":
                        cell = board.Field[x + i, y];
                        cell.Ship = ship;
                        ship.Hitbox.Add(cell);
                        break;
                    case "w":
                        cell = board.Field[x - i, y];
                        cell.Ship = ship;
                        ship.Hitbox.Add(cell);
                        break;
                    default:
                        throw new Exception();
                }
            }

            return true;
        }

        private Board PlaceShipsRandomly(Board board, int shipSize, int fleetCap)
        {
            var gen = new Random();

            while (fleetCap != 0)
            {
                var input = gen.Next(0, GameSettings.MaxBoardSize) + "-" + gen.Next(0, GameSettings.MaxBoardSize);

                switch (gen.Next(0, 3))
                {
                    case 0:
                        input = input + "-n";
                        break;
                    case 1:
                        input = input + "-s";
                        break;
                    case 2:
                        input = input + "-e";
                        break;
                    case 3:
                        input = input + "-w";
                        break;
                    default:
                        input = input + "-n";
                        break;
                }

                var result = PlaceShip(board, input, shipSize);
                if (result)
                {
                    fleetCap = fleetCap - 1;
                }
            }

            return board;
        }

        private (bool, int, int) ValidateShipPlacement(Board board, string xCoord, string yCoord, string orientation, int shipSize)
        {

            int x;
            var isXInt = Int32.TryParse(xCoord, out x);

            int y;
            var isYInt = Int32.TryParse(yCoord, out y);

            if (!isXInt || !isYInt || x < 0 || x > GameSettings.MaxBoardSize - 1 || y < 0 || y > GameSettings.MaxBoardSize - 1)
            {
                return (false, 0 , 0);
            }
            
            try
            {
                // Check ship's hitbox are within in the board
                switch (orientation)
                {
                    case "n":
                        if (y + shipSize - 1 < 0 || y + shipSize - 1 > GameSettings.MaxBoardSize - 1)
                        {
                            return (false, 0, 0);
                        }
                        break;
                    case "s":
                        if (y - shipSize - 1 < 0 || y - shipSize - 1 > GameSettings.MaxBoardSize - 1)
                        {
                            return (false, 0, 0);
                        }
                        break;
                    case "e":
                        if (x + shipSize - 1 < 0 || x + shipSize - 1 > GameSettings.MaxBoardSize - 1)
                        {
                            return (false, 0, 0);
                        }
                        break;
                    case "w":
                        if (x - shipSize - 1 < 0 || x - shipSize - 1 > GameSettings.MaxBoardSize - 1)
                        {
                            return (false, 0, 0);
                        }
                        break;
                    default:
                        throw new Exception();
                }


                // Check if ship is colliding another ship
                for (var i = 0; i < shipSize; i++)
                {
                    switch (orientation)
                    {
                        case "n":
                            if (board.Field[x, y + i].Ship != null)
                            {
                                return (false, 0, 0);
                            }
                            break;
                        case "s":
                            if (board.Field[x, y - i].Ship != null)
                            {
                                return (false, 0, 0);
                            }
                            break;
                        case "e":
                            if (board.Field[x + i, y].Ship != null)
                            {
                                return (false, 0, 0);
                            }
                            break;
                        case "w":
                            if (board.Field[x - i, y].Ship != null)
                            {
                                return (false, 0, 0);
                            }
                            break;
                        default:
                            throw new Exception();
                    }
                }

                return (true, x, y);
            }
            catch (Exception)
            {
                return (false, 0, 0);
            }
        }
    }
}
