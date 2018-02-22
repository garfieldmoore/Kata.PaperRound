using System.Collections.Generic;

namespace Valtech.PaperRound.UI.Console
{
    public interface ITownPlanner
    {
        bool IsValid();
        int NumberOfHousesInStreet();
        int NumberOfHousesOnNorthSide();
        int NumberOfHousesOnSouthSide();
        IEnumerable<int> NorthSideHouses();
        IEnumerable<int> SouthSideHouses();
        Queue<House> GetHousesWestToEast();
        void LoadStreetSpecification();
    }
}