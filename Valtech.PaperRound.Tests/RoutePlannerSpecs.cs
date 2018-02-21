using NSubstitute;
using NUnit.Framework;
using Shouldly;
using Valtech.PaperRound.UI.Console;

namespace Valtech.PaperRound.Tests
{
    [TestFixture]
    public class RoutePlannerSpecs
    {
        [Test]
        public void ensure_west_to_east_meets_provided_order()
        {
            var expected = new[] { 1, 3, 5, 7, 9, 10, 8, 6, 4, 2 };
            var mock = Substitute.For<IStreetSpecificationReader>();

            mock.LoadFile().Returns(new[]{
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            });

            var routeplanner = RoutePlanner.Create(TownPlanner.Create(mock));

            var actual = routeplanner.GetDeliveryByNorthSideThenSouthSide();

            routeplanner.TotalRoadCrossing().ShouldBe(1);
            actual.ShouldBe(expected);

        }

        [Test]
        public void ensure_delivery_to_each_house_in_turn_from_west_to_east_meets_provided_order()
        {
            var expected = new[] { 1, 2, 4, 3, 5, 6, 7, 8, 9, 10 };
            var mock = Substitute.For<IStreetSpecificationReader>();

            mock.LoadFile().Returns(new[]{
                1, 2, 4, 3, 5, 6, 7, 8, 9, 10
            });

            var routeplanner = RoutePlanner.Create(TownPlanner.Create(mock));

            var actual = routeplanner.GetDeliveryByEachhouseInTurnWestToEast();

            routeplanner.TotalRoadCrossing().ShouldBe(7);
            actual.ShouldBe(expected);
        }

        [Test]
        public void ensure_reset_crossings_between_calls()
        {
            var mock = Substitute.For<IStreetSpecificationReader>();

            mock.LoadFile().Returns(new[]{
                1, 2, 4, 3, 5, 6, 7, 8, 9, 10
            });

            var routeplanner = RoutePlanner.Create(TownPlanner.Create(mock));

            routeplanner.GetDeliveryByNorthSideThenSouthSide();
            routeplanner.GetDeliveryByEachhouseInTurnWestToEast();

            routeplanner.TotalRoadCrossing().ShouldBe(7);
        }
    }
}