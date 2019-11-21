using System.Collections;

namespace BowlingKata
{
    public class OpenFrame : IFrame
    {
        private ArrayList _throws;
        private int _startingThrow;
        private int score;

        public OpenFrame(ArrayList throws, int firstThrow, int secondThrow)
        {
            _throws = throws;
            _startingThrow = throws.Count;
            _throws.Add(firstThrow);
            _throws.Add(secondThrow);

            score = firstThrow + secondThrow;
        }

        public int Score()
        {
            return (int)_throws[_startingThrow] + (int)_throws[_startingThrow + 1];
        }
    }
}
