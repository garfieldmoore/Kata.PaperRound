using System.Collections.Generic;
using System.Linq;

namespace Valtech.PaperRound.Tests
{
    public class RoutePlanner
    {
        private TownPlanner _townplanner;
        private int _crossings;

        public RoutePlanner(TownPlanner townplanner)
        {
            this._townplanner = townplanner;
        }

        public static RoutePlanner Create(TownPlanner create)
        {
            return new RoutePlanner(create);
        }

        public int TotalRoadCrossing()
        {
            return _crossings;
        }

        public IEnumerable<int> GetDeliveryByNorthSideThenSouthSide()
        {
            
            ResetCrossings();

            var northSide = _townplanner.NorthSideHouses();
            UpdateCrossing();

            var southside = _townplanner.SouthSideHouses().Reverse();
            IEnumerable<int> deliveryOrder = northSide.Concat(southside);

            return deliveryOrder;
        }

        private void UpdateCrossing()
        {
            _crossings++;
        }

        public IEnumerable<int> GetDeliveryByEachhouseInTurnWestToEast()
        {
            ResetCrossings();
            var houses = _townplanner.GetHousesWestToEast();
            var deliveryOrder = new List<int>();
            var currentSideOfStreet = StreetSide.North;

            while (houses.Count > 0)
            {
                var house = houses.Dequeue();
                if (house != null)
                {
                    if (currentSideOfStreet != house.SideOfStreet)
                    {
                        UpdateCrossing();
                        currentSideOfStreet = house.SideOfStreet;
                    }

                    deliveryOrder.Add(house.Number);

                }
            }

            return deliveryOrder;
        }

        private void ResetCrossings()
        {
            _crossings = 0;
        }
    }
}