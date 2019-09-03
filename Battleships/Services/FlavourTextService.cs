using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Battleships.Services
{
    public class FlavourTextService
    {
        private readonly Random _random;
        private readonly ConsoleService _consoleService;

        public FlavourTextService()
        {
            _random = new Random();
            _consoleService = new ConsoleService();
        }

        public void GameMasterSpeech(string str)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Game Master");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            _consoleService.Print(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RadarOperatorAlliedBoard()
        {
            var speech = new List<string>
            {
                "Analysing our field of operations.",
                "Current sitrep of our fleet.",
                "Fleet. Report in.",
                "Attention all ships.",
                "All captains. Check in ship status.",
                "Our current fleet situation",
                "Fire control, awaiting orders.",
                "Fleet status."
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Radar Operator");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            var i = _random.Next(0, speech.Count - 1);
            _consoleService.Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RadarOperatorEnemyBoard()
        {
            var speech = new List<string>
            {
                "Scanners active. Searching for targets.",
                "Radar returning field of operations.",
                "Enemies are out there, scanning for contacts",
                "Don't take your eyes off the scanner even for a second, you don't want them to get the jump you.",
                "Sonar sweeping the seas.",
                "On guard. Scoping for contacts.",
                "Analysing enemy field of operations.",
                "Current situation of enemy field of operations",
                "Revealing known enemy positions",
                "Gathering intelligence data.",
                "Air scout team taking off.",
                "Retrieving our enemy strike options",
                "Full sweep, conducting scan now."
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Radar Operator");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            var i = _random.Next(0, speech.Count - 1);
            _consoleService.Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShipInPosition(int shipsRemaining)
        {
            var speech = new List<string>
            {
                "We're in position. " + shipsRemaining +  " ships to follow.",
                "Way point reached. " + shipsRemaining + " more ships following up.",
                "Coordinates confirmed, we're here. " + shipsRemaining + " on their way.",
                "Awaiting " + shipsRemaining + " more ships to gete into position",
                shipsRemaining + " remaining ships. Form up."
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Captain");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            var i = _random.Next(0, speech.Count - 1);
            _consoleService.Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ReadyFire()
        {
            var character = new List<string>
            {
                "Captain",
                "Fire Control",
                "Tactical Officer",
                "Commanding Officer"
            };

            var speech = new List<string>
            {
                "Standby firing coordinates.",
                "Our time to strike.",
                "All systems armed and primed.",
                "Awaiting strike orders.",
                "Awaiting strike coordinates.",
                "Ready to open fire.",
                "Give us a target.",
                "All batteries armed.",
                "Lethal force authorized.",
                "Preparing to engage.",
                "All ships, standby firing coordinates.",
                "Ready for orders.",
                "Go for strike.",
                "Operation update. We're ready to pick a target.",
                "Ships reporting in, ready to attack."
            };

            var i = _random.Next(0, speech.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(character[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            _consoleService.Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InvalidFire()
        {
            var character = new List<string>
            {
                "Captain",
                "Fire Control",
                "Tactical Officer",
                "Commanding Officer"
            };

            var speech = new List<string>
            {
                "Invalid firing coordinates.",
                "These strike coordinates are outside the field of operations.",
                "This data can't be right. Request for a new firing orders.",
                "There's no target in these coordinates. There's no way enemy ships are out that far.",
                "That's way outside the firing perimeters. Get us new coordinates. Immediately."
            };

            var i = _random.Next(0, speech.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(character[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            _consoleService.Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
