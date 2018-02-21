using NSubstitute;
using NUnit.Framework;
using Shouldly;
using Valtech.PaperRound.UI.Console;

namespace Valtech.PaperRound.Tests
{
    [TestFixture]
    public class TownPlannerSpecs
    {
        private static TownPlanner _townPlanner;
        private static IStreetSpecificationReader _streetSpecificationReader;

        [Test]
        public void ensure_file_is_valid()
        {
            GivenAValidStreetSpecification();
            GivenATownPlanner();

            _townPlanner.IsValid().ShouldBeTrue();
        }

        private static void GivenAValidStreetSpecification()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();
            _streetSpecificationReader.LoadFile().Returns(new[] {1, 2, 3});
        }

        private static void GivenATownPlanner()
        {
            _townPlanner = TownPlanner.Create(_streetSpecificationReader);
        }

        [Test]
        public void ensure_file_is_invalid()
        {
            GivenAInvalidFile();

            GivenATownPlanner();

            _townPlanner.IsValid().ShouldBeFalse();

        }

        [Test]
        public void ensure_number_of_houses_is_0()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();
            _streetSpecificationReader.LoadFile().Returns(new int[0]);

            GivenATownPlanner();

            _townPlanner.NumberOfHousesInStreet().ShouldBe(0);
        }

        [Test]
        public void ensure_number_of_houses_is_3()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();
            _streetSpecificationReader.LoadFile().Returns(new [] {1,2,3});

            GivenATownPlanner();

            _townPlanner.NumberOfHousesInStreet().ShouldBe(3);
        }

        [Test]
        public void ensure_houses_on_north_side_is_2()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();
            _streetSpecificationReader.LoadFile().Returns(new[] { 1, 2, 3 });

            GivenATownPlanner();

            _townPlanner.NumberOfHousesOnNorthSide().ShouldBe(2);
        }

        [Test]
        public void ensure_houses_on_north_side_is_3()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();
            _streetSpecificationReader.LoadFile().Returns(new[] { 1, 2, 3,5 });

            GivenATownPlanner();

            _townPlanner.NumberOfHousesOnNorthSide().ShouldBe(3);
        }

        [Test]
        public void ensure_houses_on_south_side_is_1()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();
            _streetSpecificationReader.LoadFile().Returns(new[] { 1, 2, 3, 5 });

            GivenATownPlanner();

            _townPlanner.NumberOfHousesOnSouthSide().ShouldBe(1);

        }

        [Test]
        public void ensure_houses_on_south_side_is_2()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();
            _streetSpecificationReader.LoadFile().Returns(new[] { 1, 2, 3,4, 5 });

            GivenATownPlanner();

            _townPlanner.NumberOfHousesOnSouthSide().ShouldBe(2);

        }
        private static void GivenAInvalidFile()
        {
            _streetSpecificationReader = Substitute.For<IStreetSpecificationReader>();
            _streetSpecificationReader.LoadFile().Returns(new[] {2});
        }
    }
}
