using System;
using System.Threading;

namespace SnakeGame
{
    public class MainControl
    {
        // Instance variables
        private Render render;
        private Snake snake;
        private int xMove;
        private int yMove;
        private int speed;

        //private const double MS_PER_UPDATE = 5;

        // Constructor
        public MainControl()
        {
            render = new Render();
            snake = new Snake();
            speed = 250;
            xMove = 20;
            yMove = 20;
        }

        // The Game loop method
        public void GameLoop()
        {
            // Turn cursor invisible
            Console.CursorVisible = false;

            // Local Variables
            bool gameEnded = false;
            bool hitwall;

            //double previous = DateTime.Now.Ticks;
            //double lag = 0;

            // Render first the border and the snake
            render.GameBorder();
            render.DrawSnek(xMove, yMove);

            // First key press to start
            ConsoleKey input = Console.ReadKey().Key;

            // Loop
            do 
            {
                // Method to define direction for the snake
                snake.InputMove(input, xMove, yMove, out xMove, out yMove);

                // Check if snake hit the wall
                hitwall = snake.CollideWithWall(xMove, yMove);
                if (hitwall) gameEnded = true;
                
                // Update the drawing of the snake
                render.DrawSnek(xMove, yMove);
                
                // Recognize input
                if (Console.KeyAvailable) input = Console.ReadKey().Key;
                // Slow the update game
                Thread.Sleep(speed);

            } while (!gameEnded);

            
        }
        private void Update()
        {
                //double current = DateTime.Now.Ticks;
                //double elapsed = current - previous;
                //previous = current;
                //lag += elapsed;
                //while (lag >= MS_PER_UPDATE)
                //{
                //    //Update();
                //    lag -= MS_PER_UPDATE;
                //}

                //render.Apple();
        }
    }
}
