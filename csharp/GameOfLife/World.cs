using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {
        public int[,] gameGrid { get; set; }
        public int[,] limbo { get; set; }

        public World(int size)
        {
            gameGrid = new int[size, size];
            limbo = new int[size, size];
        }   
          
    }
}