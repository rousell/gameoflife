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
            //Arrage
            World Game = new World();
            //Act

            //Assert
            Assert.IsNotNull(Game);
        }
    }
}
