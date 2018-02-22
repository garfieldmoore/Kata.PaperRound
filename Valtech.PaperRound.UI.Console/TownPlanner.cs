using System.Collections.Generic;
using System.Linq;

namespace Valtech.PaperRound.UI.Console
{
    public class TownPlanner : ITownPlanner
    {
        private readonly IStreetSpecificationReader _reader;
        private IEnumerable<int> _houses = new int[0];

        private TownPlanner(IStreetSpecificationReader reader)
        {
            _reader = reader;
        }

        public static TownPlanner Create(IStreetSpecificationReader reader)
        {
            return new TownPlanner(reader);
        }

        public bool IsValid()
        {
            var isvalid = _houses.Any() && _houses.First() == 1 && !HasDuplicates();

            return isvalid;
        }

        private bool HasDuplicates()
        {
            var query = _houses.GroupBy(x => x)
                .Where(g => g.Count() > 1);

            return query.Count() != 0;
        }

        public void LoadStreetSpecification()
        {
            _houses = _reader.LoadFile();

        }

        public int NumberOfHousesInStreet()
        {

            return _houses.Count();
        }

        public int NumberOfHousesOnNorthSide()
        {

            return _houses.Count(IsNorthSide);
        }

        public int NumberOfHousesOnSouthSide()
        {

            return _houses.Count(x => !IsNorthSide(x));
        }

        public IEnumerable<int> NorthSideHouses()
        {

            return _houses.Where(IsNorthSide).Select(x => x);
        }

        public IEnumerable<int> SouthSideHouses()
        {

            return _houses.Where(x => !IsNorthSide(x)).Select(x => x);

        }

        public Queue<House> GetHousesWestToEast()
        {

            return ConvertToHouses();
        }

        private Queue<House> ConvertToHouses()
        {
            var queue = new Queue<House>();
            foreach (var house in _houses)
            {
                queue.Enqueue(new House() { Number = house, SideOfStreet = IsNorthSide(house) ? StreetSide.North : StreetSide.South });
            }

            return queue;
        }

        private static bool IsNorthSide(int x)
        {
            return x % 2 != 0;
        }
    }
}