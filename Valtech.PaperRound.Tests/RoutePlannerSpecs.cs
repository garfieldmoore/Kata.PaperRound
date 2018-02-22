using NSubstitute;
using NUnit.Framework;
using Shouldly;
using Valtech.PaperRound.UI.Console;

namespace Valtech.PaperRound.Tests
{
    [TestFixture]
    public class RoutePlannerSpecs
    {
        private RoutePlanner _routeplanner;
        private IStreetSpecificationReader _streetSpecificationReader;

        [Test]
        public void ensure_west_to_east_meets_provided_order()
        {
            var expected = new[] { 1, 3, 5, 7, 9, 10, 8, 6, 4, 2 };
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();

            _streetSpecificationReader.LoadFile().Returns(new[]{
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            });

            GivenARoutePlanner();

            var actual = _routeplanner.GetDeliveryByNorthSideThenSouthSide();

            _routeplanner.TotalRoadCrossing().ShouldBe(1);
            actual.ShouldBe(expected);

        }

        private void GivenARoutePlanner()
        {
            var townPlanner = TownPlanner.Create(_streetSpecificationReader);
            townPlanner.LoadStreetSpecification();
            _routeplanner = RoutePlanner.Create(townPlanner);
        }

        [Test]
        public void ensure_delivery_to_each_house_in_turn_from_west_to_east_meets_provided_order()
        {
            var expected = new[] { 1, 2, 4, 3, 5, 6, 7, 8, 9, 10 };
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();

            _streetSpecificationReader.LoadFile().Returns(new[]{
                1, 2, 4, 3, 5, 6, 7, 8, 9, 10
            });

            GivenARoutePlanner();

            var actual = _routeplanner.GetDeliveryByEachhouseInTurnWestToEast();

            _routeplanner.TotalRoadCrossing().ShouldBe(7);
            actual.ShouldBe(expected);
        }

        [Test]
        public void ensure_reset_crossings_between_calls()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();

            _streetSpecificationReader.LoadFile().Returns(new[]{
                1, 2, 4, 3, 5, 6, 7, 8, 9, 10
            });

            GivenARoutePlanner();

            _routeplanner.GetDeliveryByNorthSideThenSouthSide();
            _routeplanner.GetDeliveryByEachhouseInTurnWestToEast();

            _routeplanner.TotalRoadCrossing().ShouldBe(7);
        }
    }
}