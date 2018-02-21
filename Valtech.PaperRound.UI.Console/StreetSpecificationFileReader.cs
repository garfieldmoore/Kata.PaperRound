using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Valtech.PaperRound.UI.Console
{
    public class StreetSpecificationFileReader : IStreetSpecificationReader
    {
        private readonly string _filename;

        public StreetSpecificationFileReader(string filename)
        {
            this._filename = filename;
            
        }

        public IEnumerable<int> LoadFile()
        {
            IEnumerable<int> houses = new List<int>();
            var numbers = string.Empty;

            using (var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _filename)))
            {
                numbers = reader.ReadToEnd();
            }

            houses = numbers.Split().Where(x => !string.IsNullOrEmpty(x)).Select(x=>int.Parse(x));
            return houses;
        }
    }
}