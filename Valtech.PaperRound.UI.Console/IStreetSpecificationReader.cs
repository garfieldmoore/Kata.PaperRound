using System.Collections.Generic;

namespace Valtech.PaperRound.Tests
{
    public interface IStreetSpecificationReader
    {
        IEnumerable<int> LoadFile();
    }
}