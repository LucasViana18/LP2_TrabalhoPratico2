using System;
using System.Threading;

namespace SnakeGame
{
    public class MainControl
    {
        // Instance variables
        private Render render;
        private Snake snake;
        private HighScoreControl hsc;
        private int[] xMove;
        private int[] yMove;
        private float speed;
        public int Score { get { return applesEaten * 10; } }

        //Apple variables
        private int xApplePos;
        private int yApplePos;
        private int applesEaten;
        private bool isAppleEaten;
        private Random random;

        //private const double MS_PER_UPDATE = 5;

        // Constructor
        public MainControl()
        {
            render = new Render();
            snake = new Snake();
            random = new Random();
            hsc = new HighScoreControl();
            speed = 250;
            xMove = new int[50];
            yMove = new int[50];
            xMove[0] = 20;
            yMove[0] = 20;
            xApplePos = 10;
            yApplePos = 10;
            applesEaten = 0;
            isAppleEaten = false;
        }

        public void MainMenuControl()
        {
            bool programEnded = false;

            hsc.CreateHighScores();
            
            do
            {
                ResetGame();
                render.MainMenu();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        GameLoop();
                        break;

                    case "2":
                        render.HighScores();
                        break;

                    case "3":
                        programEnded = true;
                        break;     
                }
            } while (!programEnded);
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
            render.GameBorder(this);
            render.RenderSnake(applesEaten, xMove,yMove, out xMove, out yMove);

            // First key press to start
            ConsoleKey input = Console.ReadKey(true).Key;

            SetApplePosition(random, out xApplePos, out yApplePos);
            render.RenderApple(xApplePos, yApplePos);

            // Loop
            do
            {
                // Method to define direction for the snake
                snake.InputMove(input, xMove[0], yMove[0], out xMove[0], out yMove[0]);

                // Check if snake hit the wall
                hitwall = snake.CollideWithWall(xMove[0], yMove[0]);
                if (hitwall) gameEnded = true;

                // Update the drawing of the snake
                render.RenderSnake(applesEaten, xMove, yMove, out xMove, out yMove);

                isAppleEaten = snake.AppleCheck(xMove[0], yMove[0], xApplePos, yApplePos);

                if (isAppleEaten)
                {
                    SetApplePosition(random, out xApplePos, out yApplePos);
                    render.RenderApple(xApplePos, yApplePos);
                    applesEaten++;
                    speed *= 0.95f;
                }

                // Recognize input
                if (Console.KeyAvailable) input = Console.ReadKey(true).Key;
                // Slow the update game
                Thread.Sleep(Convert.ToInt32(speed));

            } while (!gameEnded);
            
            hsc.HighScoreController(this);
        }

        private void SetApplePosition(Random rand, out int x, out int y)
        {
            x = rand.Next(2, 60);
            y = rand.Next(2, 40);
        }

        private void ResetGame()
        {
            applesEaten = 0;
            speed = 250;
            xMove = new int[50];
            yMove = new int[50];
            xMove[0] = 20;
            yMove[0] = 20;
            xApplePos = 10;
            yApplePos = 10;
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
