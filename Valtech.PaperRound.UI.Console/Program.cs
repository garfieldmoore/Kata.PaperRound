using Valtech.PaperRound.Tests;

namespace Valtech.PaperRound.UI.Console
{
    class Program
    {
        private static TownPlanner _townplanner;

        static void Main(string[] args)
        {
            DisplayTitle();

            if (args.Length != 1)
            {
                DisplayUsage();
                WaitForKeyPress();
                return;
            }

            IStreetSpecificationReader fileReader = new StreetSpecificationFileReader(args[0]);

            _townplanner = TownPlanner.Create(fileReader);
            var routeplanner = new RoutePlanner(_townplanner);

            DisplayTownPlanningReport(_townplanner);

            DisplayApproachOneReport(routeplanner);
            DisplayApproachTwoReport(routeplanner);

            WaitForKeyPress();

        }

        private static void DisplayUsage()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Usage: supply name of street file specification residing in the application directory");
            System.Console.WriteLine();
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
            System.Console.WriteLine("Newspaper delivery report (Story 2)");
            System.Console.WriteLine("-----------------------------------");
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
            System.Console.WriteLine("{0} Version {1}", AssemblyInfoHelper.Product, AssemblyInfoHelper.Version);
            System.Console.WriteLine(AssemblyInfoHelper.Description);
            System.Console.WriteLine(AssemblyInfoHelper.Copyright);

            System.Console.WriteLine();
        }
    }


}

