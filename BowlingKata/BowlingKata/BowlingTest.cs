using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace BowlingKata
{
    public class BowlingTest
    {
        private BowlingGame game;

        public BowlingTest()
        {
            game = new BowlingGame();
        }

        [Fact]
        public void GutterBalls()
        {
            ManyOpenFrames(10, 0, 0);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void Threes()
        {
            ManyOpenFrames(10, 3, 3);
            Assert.Equal(60, game.Score());
        }

        [Fact]
        public void Spare()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);
            Assert.Equal(21, game.Score());
        }

        [Fact]
        public void Spare2()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assert.Equal(23, game.Score());
        }

        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                game.OpenFrame(firstThrow, secondThrow);
        }
    }

    public class BowlingGame
    {
        private ArrayList Frames;
        private ArrayList Throws;

        public BowlingGame()
        {
            Frames = new ArrayList();
            Throws = new ArrayList();
        }

        public void OpenFrame(int firstThrow, int secondThrow)
        {
            Throws.Add(firstThrow);
            Throws.Add(secondThrow);

            Frames.Add(new OpenFrame(Throws, firstThrow, secondThrow));
        }

        public int Score()
        {
            int total = 0;
            foreach (IFrame frame in Frames)
            {
                total += frame.Score();
            }
            return total;
        }

        public void Spare(int firstThrow, int secondThrow)
        {
            Throws.Add(firstThrow);
            Throws.Add(secondThrow);
            Frames.Add(new SpareFrame(Throws, firstThrow, secondThrow));
        }
    }

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

    public interface IFrame
    {
        int Score();
    }
}
