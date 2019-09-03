using System;
using System.Collections.Generic;
using System.Threading;
using Battleships.Models;

namespace Battleships.Services
{
    public class ConsoleMicroservice
    {
        private readonly Random _random;

        public ConsoleMicroservice()
        {
            _random = new Random();
        }

        public void Print(string text)
        {
            foreach (var c in text.ToCharArray())
            {
                Console.Write(c);
                Thread.Sleep(5);
            }

            Thread.Sleep(300);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ShowBattleMap(Board currentBoard, Board viewingBoard, ConsoleColor c)
        {
            Console.ForegroundColor = c;

            for (var y = GameSettings.MaxBoardSize - 1; y > -1; y--)
            {
                Console.Write(y + " ");
                for (var x = 0; x < GameSettings.MaxBoardSize; x++)
                {
                    Console.Write(viewingBoard.Field[x, y].ToString(currentBoard) + " ");
                    Thread.Sleep(10);
                }
                Console.WriteLine("\n");
            }

            // Y Axis
            for (var x = 0; x < GameSettings.MaxBoardSize; x++)
            {
                Console.Write("   " + x);
            }
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public string GetInput(string error)
        {
            var input = "";
            while (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Print("\n");
                input = Console.ReadLine();
                Print("\n");

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Game Master");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("]: ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    Print(error);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            return input;
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

            Print(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RadarOperatorAlliedBoard(string name)
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(name + " | Radar Operator");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            var i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RadarOperatorEnemyBoard(string name)
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(name + " | Radar Operator");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            var i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShipInPosition(int shipsRemaining, string name)
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
            Console.Write(name + " | Captain");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            var i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ReadyFire(string name)
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
            Console.Write(name + " | " + character[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
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
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
