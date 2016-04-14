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
        public int live { get; set; }
        public int dead { get; set; }
        public int iterations { get; set; }
        public int dimensions { get; set; }

        public World(int size)
        {
            gameGrid = new int[size, size];
            limbo = new int[size, size];
            live = 0;
            dead = 0;
            iterations = size - 1;
            dimensions = size;
        }   
          
    }
}