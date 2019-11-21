using System.Collections;

namespace BowlingKata
{
    public class SpareFrame : IFrame
    {
        private ArrayList _throws;
        private int _startingThrow;

        public SpareFrame(ArrayList throws, int firstBall, int secondBall)
        {
            _throws = throws;
            _startingThrow = throws.Count;
            _throws.Add(firstBall);
            _throws.Add(secondBall);
        }

        private int NextBall()
        {
            return (int)_throws[_startingThrow + 2];
        }

        public int Score()
        {
            return 10 + NextBall();
        }
    }
}
