using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valtech.PaperRound.Tests;

namespace Valtech.PaperRound.UI.Console
{
    class Program
    {
        private static TownPlanner _townplanner;

        static void Main(string[] args)
        {
            IStreetSpecificationReader fileReader = new StreetSpecificationFileReader("street1.txt");

            _townplanner = TownPlanner.Create(fileReader);
            var routeplanner = new RoutePlanner(_townplanner);

            DisplayTitle();
            DisplayTownPlanningReport(_townplanner);

            DisplayApproachOneReport(routeplanner);
            DisplayApproachTwoReport(routeplanner);

            WaitForKeyPress();

        }

        private static void WaitForKeyPress()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
        }

        private static void DisplayApproachTwoReport(RoutePlanner routeplanner)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Appraoch two delivery order: {0}", string.Join(", ", routeplanner.GetDeliveryByEachhouseInTurnWestToEast()));
            System.Console.WriteLine("Appraoch two total road crossings: {0}", routeplanner.TotalRoadCrossing());

        }

        private static void DisplayApproachOneReport(RoutePlanner routeplanner)
        {
               
            System.Console.WriteLine();   
            System.Console.WriteLine("Story 2");
            System.Console.WriteLine();

            System.Console.WriteLine("Appraoch one delivery order: {0}", string.Join(", ", routeplanner.GetDeliveryByNorthSideThenSouthSide()));
            System.Console.WriteLine("Appraoch one total road crossings: {0}", routeplanner.TotalRoadCrossing());
        }

        private static void DisplayTownPlanningReport(TownPlanner townplanner)
        {

            System.Console.WriteLine("Town Planning report (Story 1)");
            System.Console.WriteLine("-------------------------------");
            if (townplanner.IsValid())
            {
                System.Console.WriteLine("Report is valid");
            }
            else
            {
                System.Console.WriteLine("The report is invalid");
            }

            System.Console.WriteLine("Number of houses in street: {0}", _townplanner.NumberOfHousesInStreet());

            System.Console.WriteLine("Number of houses on North side: {0}", _townplanner.NumberOfHousesOnNorthSide());
            System.Console.WriteLine("Number of houses on South side: {0}", _townplanner.NumberOfHousesOnSouthSide());

        }

        private static void DisplayTitle()
        {
            System.Console.WriteLine("PaperRound V2");
            System.Console.WriteLine();

        }
    }
}
