using System;
using System.Collections.Generic;
using Xunit;

namespace BowlingKata
{
    public class BowlingTest
    {
        private BowlingGame _game;

        public BowlingTest()
        {
            _game = new BowlingGame();
        }

        [Fact]
        public void GutterBalls()
        {
            ManyOpenFrames(10, 0, 0);
            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void Threes()
        {
            ManyOpenFrames(10, 3, 3);
            Assert.Equal(60, _game.Score());
        }

        [Fact]
        public void Spare()
        {
            _game.Spare(4, 6);
            _game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);
            Assert.Equal(21, _game.Score());
        }

        [Fact]
        public void Spare2()
        {
            _game.Spare(4, 6);
            _game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assert.Equal(23, _game.Score());
        }

        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                _game.OpenFrame(firstThrow, secondThrow);
        }
    }
}
