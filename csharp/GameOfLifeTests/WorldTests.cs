using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void WorldClassIsNotNull()
        {
            World Game = new World(45);
            Assert.IsNotNull(Game);
        }
        [TestMethod]
        public void GameGridBoundTest()
        {
            World Game = new World(45);
            GameLogic Logic = new GameLogic();
            Logic.PrintGameGrid(Game);

            Assert.AreEqual(0, Game.gameGrid[44, 44]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GameGridIndexOutOfRange()
        {
            World Game = new World(45);
            GameLogic Logic = new GameLogic();
            Logic.PrintGameGrid(Game);

            Assert.AreNotEqual(0, Game.gameGrid[49, 44]);
        }
        [TestMethod]
        public void GameGridSeededBlock()
        {
            World Game = new World(45);
            GameLogic Logic = new GameLogic();
            Seed Seeded = new Seed();
            World BlockGame = Seeded.Block(Game);
            Logic.PrintGameGrid(BlockGame);

            Assert.AreEqual(1, BlockGame.gameGrid[10, 10]);
        }
        [TestMethod]
        public void GameGridSeededGlider()
        {
            World Game = new World(45);
            GameLogic Logic = new GameLogic();
            Seed Seeded = new Seed();
            World GliderGame = Seeded.Glider(Game);
            Logic.PrintGameGrid(GliderGame);

            Assert.AreEqual(1, GliderGame.gameGrid[11, 11]);
        }
        [TestMethod]
        public void SecondIterationBlock()
        {
            World Game = new World(45);
            GameLogic Logic = new GameLogic();
            Seed Seeded = new Seed();
            World BlockGame = Seeded.Block(Game);
            Logic.PrintGameGrid(BlockGame);
            Logic.Cycle(BlockGame);
            Logic.UpdateGrid(BlockGame);
            Logic.PrintGameGrid(BlockGame);

            Assert.AreEqual(1, BlockGame.gameGrid[10, 10]);
        }
        [TestMethod]
        public void SecondIterationBlinker()
        {
            World Game = new World(45);
            GameLogic Logic = new GameLogic();
            Seed Seeded = new Seed();
            World BlinkerGame = Seeded.Blinker(Game);
            Logic.PrintGameGrid(BlinkerGame);
            Logic.Cycle(BlinkerGame);
            Logic.UpdateGrid(BlinkerGame);
            Logic.PrintGameGrid(BlinkerGame);

            Assert.AreEqual(1, Game.gameGrid[10, 10]);
        }
    }
}
