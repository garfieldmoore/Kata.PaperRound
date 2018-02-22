using System.Collections.Generic;

namespace Valtech.PaperRound.UI.Console
{
    public interface ITownPlanner: IHaveASpecification , ILoadData
    {
        int NumberOfHousesInStreet();
        int NumberOfHousesOnNorthSide();
        int NumberOfHousesOnSouthSide();
        IEnumerable<int> NorthSideHouses();
        IEnumerable<int> SouthSideHouses();
        Queue<House> GetHousesWestToEast();
    }

    public interface IHaveASpecification
    {
        bool IsValid();

    }

    public interface ILoadData
    {
        void LoadStreetSpecification();

    }
}