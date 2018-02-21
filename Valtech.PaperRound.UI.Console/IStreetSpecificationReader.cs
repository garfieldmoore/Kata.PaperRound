using System.Collections.Generic;

namespace Valtech.PaperRound.UI.Console
{
    public interface IStreetSpecificationReader
    {
        IEnumerable<int> LoadFile();
    }
}