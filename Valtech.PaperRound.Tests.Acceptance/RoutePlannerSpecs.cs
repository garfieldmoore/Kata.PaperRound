using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Valtech.PaperRound.UI.Console;

namespace Valtech.PaperRound.Tests.Acceptance
{
    [TestFixture]
    public class RoutePlannerSpecs
    {
        private RoutePlanner _routePlanner;

        [Test]
        public void Given_a_valid_file_when_delivering_on_north_side_and_delivering_on_south_side_then_delivery_order_should_match_order_provided()
        {
            GivenADefaultTownPlanner(); 

            var expectedNorthSideHouses = new List<int> { 1, 3, 5, 4, 2 };

            var deliveryOrder = _routePlanner.GetDeliveryByNorthSideThenSouthSide();

            deliveryOrder.ShouldBe(expectedNorthSideHouses);
            _routePlanner.TotalRoadCrossing().ShouldBe(1);
        }

        [Test]
        public void Given_a_valid_specification_when_deliver_in_order_then_delivery_order_should_match_order_provided()
        {
            GivenADefaultTownPlanner();

            var expectedNorthSideHouses = new List<int> { 1, 2, 4, 3,5 };

            var deliveryOrder = _routePlanner.GetDeliveryByEachhouseInTurnWestToEast();

            deliveryOrder.ShouldBe(expectedNorthSideHouses);
            _routePlanner.TotalRoadCrossing().ShouldBe(2);

        }

        private void GivenADefaultTownPlanner()
        {
            var townPlanner = TownPlanner.Create(new StreetSpecificationFileReader("street1.txt"));
            _routePlanner = RoutePlanner.Create(townPlanner);
        }
    }
}