using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameOfLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        begin:
            Stopwatch timer = new Stopwatch();
            World Game = new World(45);
            GameLogic Logic = new GameLogic();
            Game.live = 0;
            Game.dead = 0;
            //Logic.ClearGrid(Game);
            Console.WriteLine(" Welcome to Conway's Game of Life. Please key one of the following to begin: ");
            Console.WriteLine();
            Console.WriteLine("     b = Block");
            Console.WriteLine();
            Console.WriteLine("     l = Blinker");
            Console.WriteLine();
            Console.WriteLine("     G = Glider");
            Console.WriteLine();
            Console.WriteLine("     s = Lightweight Spaceship");
            Console.WriteLine();
            Console.WriteLine("     r = Random Fill");
            Console.WriteLine();
            ConsoleKeyInfo seed = Console.ReadKey(true);
            string key = seed.Key.ToString();
            Seed seeded = new Seed();
            Console.Clear();
            switch (key)  
            {
                // Still Lifes
                case "B":  // Block
                    {
                        World BlockGame = seeded.Block(Game);
                        Logic.Cycle(BlockGame);
                        Console.ReadKey();
                        Logic.UpdateGrid(BlockGame);
                        Logic.PrintGameGrid(BlockGame);
                        break;
                    }
                // Oscilators
                case "L": // Blinker
                    {
                        World BlinkerGame = seeded.Blinker(Game);
                        Logic.Cycle(BlinkerGame);
                        Console.ReadKey();
                        Logic.UpdateGrid(BlinkerGame);
                        Logic.PrintGameGrid(BlinkerGame);
                        Console.ReadKey();
                        break;
                    }
                //Spaceships
                case "G": // Glider
                    {
                        World GliderGame = seeded.Glider(Game);
                        Logic.Cycle(GliderGame);
                        Console.ReadKey();
                        break;
                    }
                default: // Lightweight Spaceship
                    {
                        World LightSpaceShipGame = seeded.LightSpaceShip(Game);
                        Logic.Cycle(LightSpaceShipGame);
                        Console.ReadKey();
                        break;
                    }
                /*default:
                    {
                        /*World RandomGame = seeded.Random(Game);
                        Logic.Cycle(RandomGame);
                        Console.ReadKey();
                        break;
                    }*/
            }

            
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("               Thanks for Playing!");
            Console.WriteLine();
            Console.WriteLine("            During this game there were " + Game.live + " Live Cells created.");
            Console.WriteLine();
            Console.WriteLine("                  There were also " + Game.dead + " Cells destroyed.");
            Console.WriteLine();
            Console.WriteLine("         Press any key to play again!    or  'Q'  to Quit the game.");
            ConsoleKeyInfo endGame = Console.ReadKey(true);
            if (endGame.Key.ToString() != "Q")
            { Console.Clear(); goto begin; }
        }

    }
}