using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Seed
    {
        public World Block(World Game)
        {
            Game.gameGrid[09, 09] = 1;
            Game.limbo[09, 09] = 1;
            Game.gameGrid[10, 09] = 1;
            Game.limbo[10, 09] = 1;
            Game.gameGrid[09, 10] = 1;
            Game.limbo[09, 10] = 1;
            Game.gameGrid[10, 10] = 1;
            Game.limbo[10, 10] = 1;
            Game.live = Game.live + 4;

            return Game;
        }

        public World Blinker(World Game)
        {
            Game.gameGrid[09, 09] = 1;
            Game.limbo[09, 09] = 1;
            Game.gameGrid[09, 10] = 1;
            Game.limbo[09, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.limbo[09, 11] = 1;
            Game.live = Game.live + 3;

            return Game;
        }

        public World Glider(World Game)
        {
            Game.gameGrid[10, 09] = 1;
            Game.limbo[10, 09] = 1;
            Game.gameGrid[11, 10] = 1;
            Game.limbo[11, 10] = 1;
            Game.gameGrid[09, 11] = 1;
            Game.limbo[09, 11] = 1;
            Game.gameGrid[10, 11] = 1;
            Game.limbo[10, 11] = 1;
            Game.gameGrid[11, 11] = 1;
            Game.limbo[11, 11] = 1;
            Game.live = Game.live + 5;

            return Game;
        }

        public World LightSpaceShip(World Game)
        {
            Game.gameGrid[10, 10] = 1;
            Game.limbo[10, 10] = 1;
            Game.gameGrid[10, 13] = 1;
            Game.limbo[10, 13] = 1;
            Game.gameGrid[11, 14] = 1;
            Game.limbo[11, 14] = 1;
            Game.gameGrid[12, 10] = 1;
            Game.limbo[12, 10] = 1;
            Game.gameGrid[12, 14] = 1;
            Game.limbo[12, 14] = 1;
            Game.gameGrid[13, 11] = 1;
            Game.limbo[13, 11] = 1;
            Game.gameGrid[13, 12] = 1;
            Game.limbo[13, 12] = 1;
            Game.gameGrid[13, 13] = 1;
            Game.limbo[13, 13] = 1;
            Game.gameGrid[13, 14] = 1;
            Game.limbo[13, 14] = 1;
            Game.live = Game.live + 9;

            return Game;
        }

        /*public World Random(World Game)
        {
            Random rand = new Random();
            int r = 0;

            for (int x = 0; x <= Game.dimensions; x++)
                for (int y = 0; y <= Game.dimensions; y++)
                {
                    r = rand.Next(0, 2);
                    if (r == 1)
                        Game.live = Game.live + 1;
                    Game.gameGrid[x, y] = r;
                }

            return Game;
        } */                   
    }
}
