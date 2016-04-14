using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameLogic
    {

        public void PrintGameGrid(World Game)
        {
            int col = 0;
            int row = 0;
            for (row = 0; row <= Game.iterations; row++)
            {
                for (col = 0; col <= Game.iterations; col++)
                {
                    if (Game.gameGrid[row, col] == 0)
                        Console.Write("  ");
                    else
                        Console.Write("O ");
                }
                Console.WriteLine();
            }
        }

        public void Cycle(World Game)
        {
            int status = 0;
            for (int row = 0; row <= Game.iterations; row++)
            {
                for (int col = 0; col <= Game.iterations; col++)
                {
                    status = Game.gameGrid[row, col];
                    status = Rules(row, col, status, Game);
                    Game.limbo[row, col] = status;
                }
            }
            PrintGameGrid(Game);
        }

        public void RandomGrid(World Game)
        {
            Random rand = new Random();
            int r = 0;

            for (int x = 0; x <= Game.iterations; x++)
                for (int y = 0; y <= Game.iterations; y++)
                {
                    r = rand.Next(0, 2);
                    if (r == 1)
                        Game.live = Game.live + 1;
                    Game.gameGrid[x, y] = r;
                }
        }

        public void UpdateGrid(World Game)
        {
            for (int x = 0; x <= Game.iterations; x++)
                for (int y = 0; y <= Game.iterations; y++)
                {
                    Game.gameGrid[x, y] = Game.limbo[x, y];
                }
        }

        public void ClearGrid(World Game)
        {
            for (int x = 0; x <= Game.iterations; x++)
                for (int y = 0; y <= Game.iterations; y++)
                {
                    Game.gameGrid[x, y] = 0;
                }
        }

        public int Rules(int row, int col, int status, World Game)
        {
            int Status = status;
            int count = 0;
            count = PerimiterCount(row, col, Game);
            if (Status == 1)
            {
                while (status == 1)
                {
                    // Rule 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
                    if (count < 2)
                    {
                        { status = 0; Game.dead++; }
                        break;
                    }

                    // Rule 2. Any live cell with two or three live neighbours lives on to the next generation.
                    if ((count > 1) && (count < 4))
                        break;

                    // Rule 3. Any live cell with more than three live neighbours dies, as if by overcrowding.
                    if (count > 3)
                    { status = 0; Game.dead++; }
                }
            }
            else
            {
                // Rule 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                if (count == 3)
                { status = 1; Game.live++; }
            }
            return status;
        }

        public int PerimiterCount(int row, int col, World Game) // Returns a count of all live cells int the perimiter of the indexed cell
        {
            bool top = false;
            bool right = false;
            bool bottom = false;
            bool left = false;
            if (row == 0) { top = true; }
            if (col == Game.iterations) { right = true; }
            if (row == Game.iterations) { bottom = true; }
            if (col == 0) { left = true; }

            int count = 0;
            if (!top)
            {
                if (Game.gameGrid[row - 1, col] == 1) // Top Center
                    count++;
            }
            if (!(top || right))
            {
                if (Game.gameGrid[row - 1, col + 1] == 1) // Top Right
                    count++;
            }
            if (!right)
            {
                if (Game.gameGrid[row, col + 1] == 1) // Center Right
                    count++;
            }
            if (!(right || bottom))
            {
                if (Game.gameGrid[row + 1, col + 1] == 1) // Bottom Right
                    count++;
            }
            if (!bottom)
            {
                if (Game.gameGrid[row + 1, col] == 1) // Bottom Center
                    count++;
            }
            if (!(bottom || left))
            {
                if (Game.gameGrid[row + 1, col - 1] == 1) // Bottom Left
                    count++;
            }
            if (!left)
            {
                if (Game.gameGrid[row, col - 1] == 1) // Center Left
                    count++;
            }
            if (!(top || left))
            {
                if (Game.gameGrid[row - 1, col - 1] == 1) // Top Left
                    count++;
            }
            return count;
        }

    }
}
