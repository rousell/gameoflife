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
            World Game = new World();
            Assert.IsNotNull(Game);
        }
        [TestMethod]
        public void GameGridBoundTest()
        {
            World Game = new World();
            Game.PrintGameGrid();

            Assert.AreEqual(0, World.gameGrid[44, 44]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GameGridIndexOutOfRange()
        {
            World Game = new World();
            Game.PrintGameGrid();

            Assert.AreNotEqual(0, World.gameGrid[49, 44]);
        }
        [TestMethod]
        public void GameGridSeededBlock()
        {
            World Game = new World();
            Game.Seed("B");
            Game.PrintGameGrid();

            Assert.AreEqual(1, World.gameGrid[10, 10]);
        }
        [TestMethod]
        public void GameGridSeededGlider()
        {
            World Game = new World();
            Game.Seed("G");
            Game.PrintGameGrid();

            Assert.AreEqual(1, World.gameGrid[11, 11]);
        }
        [TestMethod]
        public void SecondIterationBlinker()
        {
            World Game = new World();
            Game.Seed("L");
            Game.PrintGameGrid();
            Game.Cycle();

            Assert.AreEqual(1, World.gameGrid[10, 10]);
        }
    }
}
