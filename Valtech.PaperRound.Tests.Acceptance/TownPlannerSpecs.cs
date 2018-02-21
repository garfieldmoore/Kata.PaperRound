using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;
using Valtech.PaperRound.UI.Console;

namespace Valtech.PaperRound.Tests.Acceptance
{
    [TestFixture]
    public class TownPlannerSpecs
    {
        private TownPlanner _townplanner;

        [Test]
        public void Given_a_valid_file_when_checking_file_then_it_should_be_valid()
        {
            GivenADefaultTownPlanner();

            _townplanner.IsValid().ShouldBeTrue();
        }

        private void GivenADefaultTownPlanner()
        {
            _townplanner = TownPlanner.Create(new StreetSpecificationFileReader("street1.txt"));
        }

        [Test]
        public void Given_an_invalid_file_not_starting_from_1_when_checking_file_then_it_should_be_valid()
        {
            var townplanner =
                TownPlanner.Create(new StreetSpecificationFileReader("invalid_starts_at_2.txt"));

            townplanner.IsValid().ShouldBeFalse();

        }

        [Test]
        public void Given_a_valid_file_when_counting_houses_then_total_should_be_14()
        {
            GivenADefaultTownPlanner();

            _townplanner.NumberOfHousesInStreet().ShouldBe(5);
        }

        [Test]
        public void Given_a_valid_file_when_counting_north_side_houses_then_total_should_be_8()
        {
            GivenADefaultTownPlanner();

            _townplanner.NumberOfHousesOnNorthSide().ShouldBe(3);
        }

        [Test]
        public void Given_a_valid_file_when_counting_south_side_houses_then_total_should_be_6()
        {
            GivenADefaultTownPlanner();

            _townplanner.NumberOfHousesOnSouthSide().ShouldBe(2);
        }
    }
}
