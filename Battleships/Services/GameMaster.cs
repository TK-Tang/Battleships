using System;
using System.Threading;
using Battleships.Models;

namespace Battleships.Services
{
    public class GameMaster
    {
        private GameMode _gameMode;
        private Board _board1;
        private Board _board2;
        private Player _player1;
        private Player _player2;
        private int _gameFleetCap;
        private int _gameShipSize;

        private readonly ShipPlacementService _shipPlacementService;
        private readonly BoardMicroservice _boardService;
        private readonly ConsoleMicroservice _consoleMicroservice;

        public GameMaster()
        {
            _shipPlacementService = new ShipPlacementService();
            _consoleMicroservice = new ConsoleMicroservice();
            _boardService = new BoardMicroservice();
        }

        public void Introductions()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            _consoleMicroservice.GameMasterSpeech("Welcome to TK's Battleship Arena! Behold!\n");
            _consoleMicroservice.GameMasterSpeech("The mightiest C# console navy fleets brawl with each other on the high seas!\n");
            _consoleMicroservice.GameMasterSpeech("First, setup. If you wish to duel with another human intellectual, type 'PVP'!\n");
            _consoleMicroservice.GameMasterSpeech("However, if you have no rivals, then type 'PVE' and fight against an AI!\n");
        }

        public void GameModeQuestion()
        {
            var input = _consoleMicroservice.GetInput("What was that? I didn't catch that");

            switch (input.ToLower())
            {
                case "pvp":
                    _consoleMicroservice.GameMasterSpeech("PvP it is then.\n");
                    (_player1, _player2, _board1, _board2, _gameMode) = _boardService.SetupPvPBoards();
                    break;
                case "pve":
                    _consoleMicroservice.GameMasterSpeech("You cannot win against the AI. Feel free to try anyway.\n");
                    (_player1, _player2, _board1, _board2, _gameMode) = _boardService.SetupPvEBoards();
                    break;
                default:
                    _consoleMicroservice.GameMasterSpeech("What was that? I didn't catch that. Let's get this going already.\n");
                    _consoleMicroservice.GameMasterSpeech("I think I'll just go ahead and pin you into the arena against the AI.\n");
                    (_player1, _player2, _board1, _board2, _gameMode) = _boardService.SetupPvEBoards();
                    break;
            }
        }

        public void FleetSettingsQuestion()
        {
            _consoleMicroservice.GameMasterSpeech("Alrighty, now I'd like you to decide how many ships we shall field in the seas.\n");
            _consoleMicroservice.GameMasterSpeech("Our Arena only permits at most " + GameSettings.FleetCap + " and at least " + GameSettings.FleetMinimum + ". \n");
            _consoleMicroservice.GameMasterSpeech("Warships are expensive hardware after all.\n");

            var input = _consoleMicroservice.GetInput("Pick a number between " + GameSettings.FleetCap + " and " + GameSettings.FleetMinimum + ".\n");

            int fleetCap;
            var isInt = Int32.TryParse(input, out fleetCap);

            if (isInt && fleetCap >= GameSettings.FleetMinimum && fleetCap <= GameSettings.FleetCap)
            {
                _gameFleetCap = fleetCap;
            }
            else
            {
                _consoleMicroservice.GameMasterSpeech("What is this? Can't you even bang in a proper number between " + GameSettings.FleetMinimum +" and " + GameSettings.FleetCap + "?\n");
                _consoleMicroservice.GameMasterSpeech("Bah. As GameMaster, I will decide the fleet cap shall be " + GameSettings.FleetCap + ". Let's move on.\n");

                _gameFleetCap = GameSettings.FleetCap;
            }

            _consoleMicroservice.GameMasterSpeech("Okay, both sides will get a fleet of " + fleetCap + " ships.\n");
        }

        public void ShipSettingsQuestion()
        {
            _consoleMicroservice.GameMasterSpeech("Ships come in different sizes. Corvettes. Frigates. Cruisers. Battleships.\n");
            _consoleMicroservice.GameMasterSpeech("You can decide how big your ships are.\n");
            _consoleMicroservice.GameMasterSpeech("Just pick any number between " + GameSettings.MinShipSize +" to " + GameSettings.MaxShipSize + ".\n");

            var input = _consoleMicroservice.GetInput("Pick a number between " + GameSettings.MinShipSize + " and " + GameSettings.MaxShipSize + ".\n");

            int shipSize;
            var isInt = Int32.TryParse(input, out shipSize);

            if (isInt && shipSize >= GameSettings.MinShipSize && shipSize <= GameSettings.MaxShipSize)
            {
                _gameShipSize = shipSize;
            }
            else
            {
                _consoleMicroservice.GameMasterSpeech(input + " isn't a number between two and five. You can count with your fingers right?\n");
                _consoleMicroservice.GameMasterSpeech("I wanted a number between " + GameSettings.MinShipSize + " and " + GameSettings.MaxShipSize + " right?\n");
                _consoleMicroservice.GameMasterSpeech("Forget it. I will decide the ship size for you and I choose " + GameSettings.MaxShipSize + ". Let's move on.\n");
                Thread.Sleep(3000);

                _gameShipSize = GameSettings.MaxShipSize;
            }

            _consoleMicroservice.Clear();
        }

        public void FleetPlacementQuestion()
        {
            _consoleMicroservice.GameMasterSpeech("Get your fleet in formation. You have " + _gameFleetCap + " ships to command.\n");
            _consoleMicroservice.GameMasterSpeech("Enter coordinates in this formation: x-y [n,s,e,w]\n");
            _consoleMicroservice.GameMasterSpeech("This will be the coordinates of the aft end of your ship. \n");
            _consoleMicroservice.GameMasterSpeech("An example: '3-5-n' will place the ship facing north.\n");
            _consoleMicroservice.GameMasterSpeech("You can choose to have the ships placed randomly as well. Just enter 'r'\n");

            _consoleMicroservice.GameMasterSpeech(_player1.Name +". You first.\n\n");
            _consoleMicroservice.ShowBattleMap(_board1.Owner, _board1, ConsoleColor.Cyan);
            _shipPlacementService.PlaceFleet(_board1, _board2, _gameFleetCap, _gameShipSize, "Yeah. Even I can't be bothered placing ships one at a time.\n");

            _consoleMicroservice.GameMasterSpeech(_player2.Name +". You next.\n\n");
            _consoleMicroservice.ShowBattleMap(_board2.Owner, _board2, ConsoleColor.Cyan);
            _shipPlacementService.PlaceFleet(_board2, _board1, _gameFleetCap, _gameShipSize, "Yeah too huh? Sure\n");
        }

        public void BeginGame()
        {
            _consoleMicroservice.GameMasterSpeech("All is ready. Good luck.\n");
            Thread.Sleep(3000);
            _consoleMicroservice.Clear();
            while (true)
            {
                Round(_player1, _player2);
                Round(_player2, _player1);
            }
        }

        private void Round(Player attackingPlayer, Player victimPlayer)
        {
            _consoleMicroservice.GameMasterSpeech(attackingPlayer.Name + "'s Round.\n");
            _consoleMicroservice.ReadyFire(attackingPlayer.Name);
            _consoleMicroservice.Print("[Current Fleet Positions]:\n");
            _consoleMicroservice.ShowBattleMap(attackingPlayer, attackingPlayer.Board, ConsoleColor.Cyan);
            _consoleMicroservice.Print("[Enemy Fleet Positions]:\n");
            _consoleMicroservice.ShowBattleMap(attackingPlayer, victimPlayer.Board, ConsoleColor.DarkBlue);

            var valid = false;
            Ship target = null;
            while (!valid)
            {
                Console.Write("Coordinates [x-y]: ");
                var input = _consoleMicroservice.GetInput("Invalid coordinates.");
                (valid, target) = _boardService.Fire(victimPlayer.Board, input);

                if (!valid)
                {
                    _consoleMicroservice.InvalidFire(attackingPlayer.Name);
                }
            }

            _consoleMicroservice.Firing(attackingPlayer.Name);
            _consoleMicroservice.Tension();

            if (target == null)
            {
                _consoleMicroservice.Miss(attackingPlayer.Name);
            }
            else if (target.Hitbox.Count > 1)
            {
                _consoleMicroservice.EnemyShipHit(attackingPlayer.Name);
            }
            else if (target.Hitbox.Count == 1)
            {
                _consoleMicroservice.EnemyShipHitCritical(attackingPlayer.Name);
            }
            else
            {
                _consoleMicroservice.EnemyShipSunk(attackingPlayer.Name);
            }

            Thread.Sleep(3000);
            _consoleMicroservice.Clear();
        }
    }
}
