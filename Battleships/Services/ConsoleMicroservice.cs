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

        public void ShowBattleMap(Player player, Board viewingBoard, ConsoleColor c, string str)
        {
            Console.ForegroundColor = c;
            Console.Write("\n");
            Print(str);

            for (var y = GameSettings.MaxBoardSize - 1; y > -1; y--)
            {
                Console.Write(" " + y + " ");
                for (var x = 0; x < GameSettings.MaxBoardSize; x++)
                {
                    Console.Write(viewingBoard.Field[x, y].ToString(player) + " ");
                    Thread.Sleep(10);
                }
                Console.WriteLine("\n");
            }

            // Y Axis
            Console.Write(" ");

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
                "Awaiting " + shipsRemaining + " more ships to get into position",
                shipsRemaining + " remaining ships. Form up.",
                "New heading set. " + shipsRemaining + " still to reach their rendezvous point."
            };

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkGray;
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

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InvalidFire(string name)
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

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Firing(string name)
        {
            var character = new List<string>
            {
                "Fire Control",
                "Tactical Officer",
                "Commanding Officer"
            };

            var speech = new List<string>
            {
                "We have our strike coordinates. Open up with a barrage.",
                "Green for missile launch.",
                "Confirmed missile launch. Target designated.",
                "Strike orders are in. Bring our cannons to bear.",
                "Torpedoes away.",
                "Hit that zone with a heavy burst.",
                "Missiles away.",
                "Bearing down on target.",
                "Thirty degrees starboard. Angle it up fourty five degrees. Get ready.",
                "Engaging.",
                "Strike craft away.",
                "Strike craft on deck runway. Launching.",
                "Bomber on deck. Green for take off",
                "Gunship on deck. Strike coordinates confirmed",
                "Strike order confirmed. Go for Bomber.",
                "Roger that, firing salvo.",
                "Coordinates confirmed. Firing salvo.",
                "Coordinates verified. Open fire. All cannons.",
                "Coordinates recieved. Opening fire.",
                "Dumping torpedoes. Vectoring in on target.",
                "Target designated. Launching missiles.",
                "Coordinates confirmed. Bring in the rain.",
                "Orders recieved. Artillery targeting strike coordinates.",
                "Understood. Bombarding coordinates.",
                "Roger. Strike coordinates confirmed",
                "Confirmed. Firing artillery."
            };

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Miss(string name)
        {
            var character = new List<string>
            {
                "Captain",
                "Fire Control",
                "Tactical Officer",
                "Commanding Officer",
                "Helmsman"
            };

            var speech = new List<string>
            {
                "Dead water. We missed",
                "No smoke detected. We didn't hit anything.",
                "No targets in that area. Reload the cannons for next round.",
                "I don't see anything on the sensors. We must have missed.",
                "No contact in that sector.",
                "Wasted. Prep for next salvo.",
                "No contacts. Rearm for next volley.",
                "Hydrophones aren't picking anything up. Just splash downs.",
                "We have visual. No targets hit. Enemy fleet still at large.",
                "Nothing hit. Prepare to fire again.",
                "Sonar registering nothing. We missed our shots.",
                "Whiskey. Tango. Foxtrot. We missed our targets",
                "No targets detected. Scratch it off the tactical map.",
                "No encounters. Strike fighters refueling for next attack run.",
                "Bombers returning. Report is in. All quiet. No enemy contacts.",
                "Torpedoes zipped through the strike coordinates without any contact. Reload the tubes.",
                "Contact negative. Coordinates are all clear",
                "Tactical update. No enemy ships in the area."
            };

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void EnemyShipHit(string name)
        {
            var character = new List<string>
            {
                "Captain",
                "Fire Control",
                "Tactical Officer",
                "Commanding Officer",
                "Helmsman"
            };

            var speech = new List<string>
            {
                "We have visual, enemy ship hit.",
                "Enemy ship struck. Smoke column in the horizon.",
                "Enemy target sustained damage. Excellent work fleet.",
                "We have a strike. Enemy target positions compromised.",
                "Target ship profiles identified. Enemy ship hit.",
                "Enemy ship sustained moderate damage. We have a hit.",
                "Score. Enemy ship taking damage.",
                "Smoke sighted. Enemy ship on fire.",
                "Hydrophones detect underwater explosions. We got 'em.",
                "We have a contact on radar. Enemy ship hit.",
                "Strike fighters report successful sortie. Enemy ships have sustained damage.",
                "Bombers returning. We have a damaged enemy ship located here.",
                "Right there. You see it? We have enemy targets in sight.",
                "Tactical reports. Enemy ship struck.",
                "Torpedo volley has hit something. We have enemy contact."
            };

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void EnemyShipHitCritical(string name)
        {
            var character = new List<string>
            {
                "Captain",
                "Fire Control",
                "Tactical Officer",
                "Commanding Officer",
                "Helmsman"
            };

            var speech = new List<string>
            {
                "They're on the run. Enemy ship sustained heavy damage.",
                "Enemy target dead in the water. One more strike and they're finished.",
                "Enemy ship taking substantial damage. Their whole ship is on fire.",
                "Successful strike. Let's finish this.",
                "Enemy ship hit. We almost have them.",
                "Enemy ship severely damaged. We have the advantage"
            };

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void EnemyShipSunk(string name)
        {
            var character = new List<string>
            {
                "Fire Control",
                "Tactical Officer",
                "Helmsman"
            };

            var speech = new List<string>
            {
                "Kill confirmed. Great work fleet.",
                "Target eliminated. Need new orders.",
                "Target going under. Need new strike coordinates.",
                "Enemy ship destroyed. Well done everyone",
                "Enemy ship just blew up. Give us a new target.",
                "Target ship annihilated. Only life boats remaining.",
                "Great work fleet. We have a kill.",
                "Target destroyed. Send new orders.",
                "Threat eliminated. Nothing but debris.",
                "Enemy ship dispatched. Nothing but a smoldering wreck on our scopes."
            };

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AlliedShipDamaged(string name)
        {
            var character = new List<string>
            {
                "Damage Control",
                "Lead Technician",
                "Captain"
            };

            var speech = new List<string>
            {
                "We're hit. Damage report.",
                "Taking damage fleet.",
                "We're under attack",
                "We're under fire.",
                "Hold your positions, we're under attack.",
                "Incoming barrage.",
                "Incoming Torpedoes! Starboard!",
                "Alert! Incoming Torpedoes! Portside!",
                "We've taken damage fleet but the armor belt is holding.",
                "Get a repair crew down to the lower decks.",
                "Taking enemy fire.",
                "Someone put that fire out!",
                "Damage assessment in. Moderate impairment to ship capabilities.",
                "Sustaining damage fleet.",
                "We're taking enemy fire! Repair team one, you're up!",
                "Under attack. Repair team two to station.",
                "Under enemy attack. She's holding though.",
                "Damage control to station! I don't want any delays!",
                "Position compromised! All hands!",
            };

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AlliedShipDamagedCritical(string name)
        {
            var character = new List<string>
            {
                "Damage Control",
                "Repair Team",
                "Lead Technician"
            };

            var speech = new List<string>
            {
                "We're taking massive damage fleet.",
                "Gah! We can't take another hit like that!",
                "Reactor going critical. Prepare to abandon ship.",
                "We're taking on water! All available personnel seal lower deck hatches! Immediately!",
                "We're under a massive attack! We have men overboard!",
                "Prepare the life rafts. Ship destruction imminent!",
                "Sustaining substantial damage. Another hit and we're gone.",
                "Evacuate all non essential personnel! Now! Go! Go! Go!",
                "We're lost. Get all non mandatory sailsmen off the ship.",
                "Code red. I repeat code red.",
                "Hit! Hit! Damage Report!",
                "We require immediate assistance! I repeat, we bloody need help here!",
                "Primary systems compromised! We're losing guidance fleet!",
                "Primary weapons down. Our generators have been knocked out. Back up systems not responding.",
                "I need every repair team to focus on putting out that damn fire!",
                "The lower decks are flooding rapidly. All able men, seal the damn hatches!"
            };

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AlliedShipDestroyed(string name)
        {
            var character = new List<string>
            {
                "Damage Control",
                "Repair Team",
                "Lead Technician",
                "Captain"
            };

            var speech = new List<string>
            {
                "Catastrophic reactor meltdown. We cannot maintain! Code red, I repeat, Code r... zzsschkk",
                "We're going down. I repeat, we're go - zzsschkk",
                "Our battleship... She's being ... Overwhelmed.. zzsschkk",
                "It's been an honor serving with you all gentlemen... zzsschkk",
                "There's too much damage! Losing control! I repeat, we - zzsschhkk",
                "I need repair teams to seal hatches on decks A to D! Fire team Zulu, stop that blazing inferno from reaching ammo compartment! And someone get me a direct line with the fle - zzzsschhk",
                "Lifeboats away. Majority of the crew is... safe. But ... it is too late for me, I'll be going down with the ship.. zzschhk",
                "Fire control is knocked out! Primary systems not responding! We need immediate assis - zzsschhk",
                "Go! Go! Get to the life boats! She's getting ripped apart! Get the hell out of h - zzzsschhk"
            };

            var i = _random.Next(0, character.Count - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(name + " | " + character[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            i = _random.Next(0, speech.Count - 1);
            Print(speech[i] + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Admiralty(string name, string annoucement)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write( name + " | Admiralty");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Print(annoucement);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Tension()
        {
            Print(". . . . .\n");
            Thread.Sleep(700);
            Print(". . . . .\n");
            Thread.Sleep(700);
            Print(". . . . .\n");
        }
    }
}
