using System.Collections;

namespace BowlingKata
{
    public class BowlingGame
    {
        private readonly ArrayList _frames;
        private readonly ArrayList _throws;

        public BowlingGame()
        {
            _frames = new ArrayList();
            _throws = new ArrayList();
        }

        public void OpenFrame(int firstThrow, int secondThrow)
        {
            _throws.Add(firstThrow);
            _throws.Add(secondThrow);

            _frames.Add(new OpenFrame(_throws, firstThrow, secondThrow));
        }

        public int Score()
        {
            int total = 0;
            foreach (IFrame frame in _frames)
            {
                total += frame.Score();
            }
            return total;
        }

        public void Spare(int firstThrow, int secondThrow)
        {
            _throws.Add(firstThrow);
            _throws.Add(secondThrow);
            _frames.Add(new SpareFrame(_throws, firstThrow, secondThrow));
        }
    }
}
