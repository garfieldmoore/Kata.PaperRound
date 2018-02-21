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
        [Test]
        public void ensure_file_is_valid()
        {
            var townplanner =
                TownPlanner.Create(new StreetSpecificationFileReader("street1.txt"));

            townplanner.IsValid().ShouldBeTrue();
        }
    }
}
