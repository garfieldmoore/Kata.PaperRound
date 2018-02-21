using System.Collections.Generic;
using System.Linq;

namespace Valtech.PaperRound.UI.Console
{
    public class TownPlanner : ITownPlanner
    {
        private readonly IStreetSpecificationReader _reader;
        private bool _isloaded;
        private IEnumerable<int> _houses;

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
            LoadFile();

            if (_houses.First() == 1)
            {
                return true;
            }

            return false;
        }

        private void LoadFile()
        {
            if (IsLoaded())
            {
                return;
            }

            _houses = _reader.LoadFile();
            _isloaded = true;
        }

        private bool IsLoaded()
        {
            return _isloaded;
        }

        public int NumberOfHousesInStreet()
        {
            LoadFile();

            return _houses.Count();
        }

        public int NumberOfHousesOnNorthSide()
        {
            LoadFile();

            return _houses.Count(IsNorthSide);
        }

        public int NumberOfHousesOnSouthSide()
        {
            LoadFile();

            return _houses.Count(x => !IsNorthSide(x));
        }

        public IEnumerable<int> NorthSideHouses()
        {
            LoadFile();
            return _houses.Where(IsNorthSide).Select(x => x);
        }

        public IEnumerable<int> SouthSideHouses()
        {
            return _houses.Where(x => !IsNorthSide(x)).Select(x => x);

        }

        public Queue<House> GetHousesWestToEast()
        {
            LoadFile();
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

        private bool IsNorthSide(int x)
        {
            return x % 2 != 0;
        }
    }

    public class House
    {
        public int Number;
        public StreetSide SideOfStreet;
    }

    public enum StreetSide
    {
        North, South
    }
}