using System.Collections;

namespace BowlingKata
{
    public class OpenFrame : IFrame
    {
        private readonly ArrayList _throws;
        private readonly int _startingThrow;

        public OpenFrame(ArrayList throws, int firstThrow, int secondThrow)
        {
            _throws = throws;
            _startingThrow = throws.Count;
            _throws.Add(firstThrow);
            _throws.Add(secondThrow);
        }

        public int Score()
        {
            return (int)_throws[_startingThrow] + (int)_throws[_startingThrow + 1];
        }
    }
}
