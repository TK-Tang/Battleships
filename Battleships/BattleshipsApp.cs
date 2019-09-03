using System;
using Battleships.Services;

namespace Battleships
{
    public class BattleshipsApp
    {
        private static GameMaster _gameMaster;
            
        public static void Main(string[] args)
        {
            try
            {
                _gameMaster = new GameMaster();

                _gameMaster.Introductions();
                _gameMaster.FleetSettingsQuestion();
                _gameMaster.ShipSettingsQuestion();
                _gameMaster.FleetPlacementQuestion();

                _gameMaster.BeginGame();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
