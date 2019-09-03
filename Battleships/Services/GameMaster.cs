using System;
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

        private Player _round;

        private readonly ShipPlacementService _shipPlacementService;
        private readonly FlavourTextService _flavourTextService;
        private readonly BoardMicroservice _boardService;
        private readonly ConsoleMicroservice _consoleSubroutine;

        public GameMaster()
        {
            _shipPlacementService = new ShipPlacementService();
            _consoleSubroutine = new ConsoleMicroservice();
            _flavourTextService = new FlavourTextService();
            _boardService = new BoardMicroservice();
        }

        public void Introductions()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            _flavourTextService.GameMasterSpeech("Welcome to TK's Battleship Arena! Behold!\n");
            _flavourTextService.GameMasterSpeech("The mightiest C# console navy fleets brawl with each other on the high seas!\n");
            _flavourTextService.GameMasterSpeech("First, setup. If you wish to duel with another human intellectual, type 'PVP'!\n");
            _flavourTextService.GameMasterSpeech("However, if you have no rivals, then type 'PVE' and fight against an AI!\n");
        }

        public void GameModeQuestion()
        {
            var input = _consoleSubroutine.GetInput("What was that? I didn't catch that");

            switch (input.ToLower())
            {
                case "pvp":
                    _flavourTextService.GameMasterSpeech("PvP it is then.\n");
                    _boardService.SetupPvPBoards();
                    break;
                case "pve":
                    _flavourTextService.GameMasterSpeech("You cannot win against the AI. Feel free to try anyway.\n");
                    _boardService.SetupPvEBoards();
                    break;
                default:
                    _flavourTextService.GameMasterSpeech("What was that? I didn't catch that. Let's get this going already.\n");
                    _flavourTextService.GameMasterSpeech("I think I'll just go ahead and pin you into the arena against the AI.\n");
                    _boardService.SetupPvEBoards();
                    break;
            }
        }

        public void FleetSettingsQuestion()
        {
            _flavourTextService.GameMasterSpeech("Alrighty, now I'd like you to decide how many ships we shall field in the seas.\n");
            _flavourTextService.GameMasterSpeech("Our Arena only permits at most " + GameSettings.FleetCap + " and at least " + GameSettings.FleetMinimum + ". \n");
            _flavourTextService.GameMasterSpeech("Warships are expensive hardware after all.\n");

            var input = _consoleSubroutine.GetInput("Pick a number between " + GameSettings.FleetCap + " and " + GameSettings.FleetMinimum + ".\n");

            int fleetCap;
            var isInt = Int32.TryParse(input, out fleetCap);

            if (isInt && fleetCap >= GameSettings.FleetMinimum && fleetCap <= GameSettings.FleetCap)
            {
                _gameFleetCap = fleetCap;
            }
            else
            {
                _flavourTextService.GameMasterSpeech("What is this? Can't you even bang in a proper number between " + GameSettings.FleetMinimum +" and " + GameSettings.FleetCap + "?\n");
                _flavourTextService.GameMasterSpeech("Bah. As GameMaster, I will decide the fleet cap shall be " + GameSettings.FleetCap + ". Let's move on.\n");

                _gameFleetCap = GameSettings.FleetCap;
            }

            _flavourTextService.GameMasterSpeech("Okay, both sides will get a fleet of " + fleetCap + " ships.\n");
        }

        public void ShipSettingsQuestion()
        {
            _flavourTextService.GameMasterSpeech("Ships come in different sizes. Corvettes. Frigates. Cruisers. Battleships.\n");
            _flavourTextService.GameMasterSpeech("You can decide how big your ships are.\n");
            _flavourTextService.GameMasterSpeech("Just pick any number between " + GameSettings.MinShipSize +" to " + GameSettings.MaxShipSize + ".\n");

            var input = _consoleSubroutine.GetInput("Pick a number between " + GameSettings.MinShipSize + " and " + GameSettings.MaxShipSize + ".\n");

            int shipSize;
            var isInt = Int32.TryParse(input, out shipSize);

            if (isInt && shipSize >= GameSettings.MinShipSize && shipSize <= GameSettings.MaxShipSize)
            {
                _gameShipSize = shipSize;
            }
            else
            {
                _flavourTextService.GameMasterSpeech(input + " isn't a number between two and five. You can count with your fingers right?\n");
                _flavourTextService.GameMasterSpeech("I wanted a number between " + GameSettings.MinShipSize + " and " + GameSettings.MaxShipSize + " right?\n");
                _flavourTextService.GameMasterSpeech("Forget it. I will decide the ship size for you and I choose " + GameSettings.MaxShipSize + ". Let's move on.\n");

                _gameShipSize = GameSettings.MaxShipSize;
            }

            _consoleSubroutine.Clear();
        }

        public void FleetPlacementQuestion()
        {
            _flavourTextService.GameMasterSpeech("Get your fleet in formation. You have " + _gameFleetCap + " ships to command.\n");
            _flavourTextService.GameMasterSpeech("Enter coordinates in this formation: x-y [n,s,e,w]\n");
            _flavourTextService.GameMasterSpeech("This will be the coordinates of the aft end of your ship. \n");
            _flavourTextService.GameMasterSpeech("An example: '3-5-n' will place the ship facing north.\n");
            _flavourTextService.GameMasterSpeech("You can choose to have the ships placed randomly as well. Just enter 'r'\n");

            _flavourTextService.GameMasterSpeech("\n " + _player1.Name +". You first.\n");
            _shipPlacementService.PlaceFleet(_board1, _board2, _gameFleetCap, _gameShipSize, "Yeah. Even I can't be bothered placing ships one at a time.\n");

            _flavourTextService.GameMasterSpeech("\n " + _player2.Name +". You next.\n");
            _shipPlacementService.PlaceFleet(_board2, _board1, _gameFleetCap, _gameShipSize, "Yeah too huh? Sure\n");
        }

        public void BeginGame()
        {
            _flavourTextService.GameMasterSpeech("All is ready. Good luck.");
            _consoleSubroutine.Print("5");
            _consoleSubroutine.Print("4");
            _consoleSubroutine.Print("3");
            _consoleSubroutine.Print("2");
            _consoleSubroutine.Print("1");
            _consoleSubroutine.Clear();
            while (true)
            {
                Round(_player1, _player2);
                Round(_player2, _player1);
            }
        }

        private void Round(Player attackingPlayer, Player victimPlayer)
        {
            _flavourTextService.GameMasterSpeech(attackingPlayer.Name + "'s Round.");
            _flavourTextService.ReadyFire();
            _consoleSubroutine.Print("[Current Fleet Positions]:");
            _consoleSubroutine.ShowBattleMap(attackingPlayer.Board, attackingPlayer.Board, ConsoleColor.Cyan);
            _consoleSubroutine.Print("\n\n");
            _consoleSubroutine.Print("[Enemy Fleet Positions]:");
            _consoleSubroutine.ShowBattleMap(attackingPlayer.Board, victimPlayer.Board, ConsoleColor.DarkBlue);
            _consoleSubroutine.Print("\n\n");

            var input = _consoleSubroutine.GetInput("Invalid coordinates.");
            var valid = false;
            Ship target = null;
            while (!valid)
            {
                (valid, target) = _boardService.Fire(victimPlayer.Board, input);

                if (!valid)
                {
                    _flavourTextService.InvalidFire();
                }
            }

            if (target == null)
            {
                _flavourTextService.Miss();
            }
            else if (target.Hitbox.Count > 1)
            {
                _flavourTextService.EnemyShipHit(target);
            }
            else if (target.Hitbox.Count == 1)
            {
                _flavourTextService.EnemyShipHitCritical(target);
            }
            else
            {
                _flavourTextService.EnemyShipSunk(target);
            }
        }
    }
}
