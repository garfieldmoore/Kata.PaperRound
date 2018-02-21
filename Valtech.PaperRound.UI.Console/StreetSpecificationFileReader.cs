using System.Collections.Generic;
using System.IO;
using System.Linq;
using Valtech.PaperRound.Tests;

namespace Valtech.PaperRound.UI.Console
{
    public class StreetSpecificationFileReader : IStreetSpecificationReader
    {
        private string _fileStream;

        public StreetSpecificationFileReader(string fileStream)
        {
            this._fileStream = fileStream;
            
        }

        public IEnumerable<int> LoadFile()
        {
            IEnumerable<int> houses = new List<int>();
            var numbers = string.Empty;

            using (var reader = new StreamReader(_fileStream))
            {
                numbers = reader.ReadToEnd();
            }

            houses = numbers.Split().Where(x => !string.IsNullOrEmpty(x)).Select(x=>int.Parse(x));
            return houses;
        }
    }
}