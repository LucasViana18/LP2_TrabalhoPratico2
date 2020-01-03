using System;
using System.Threading;

namespace SnakeGame
{
    /// <summary>
    /// This class controls every action of the game
    /// </summary>
    public class MainControl
    {
        // Instance variables
        private Render render;
        private Snake snake;
        private HighScoreControl hsc;
        private int[] xMove;
        private int[] yMove;
        private float speed;
        private bool gameEnded;
        private ConsoleKey input;
        private Random random;
            //Apple variables
        private int xApplePos;
        private int yApplePos;
        private int applesEaten;
        private bool isAppleEaten;

        // Properties
        public int Score { get { return applesEaten * 10; } }

        /// <summary>
        /// Constructor
        /// </summary>
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
            gameEnded = false;
        }

        /// <summary>
        /// Manages/Control the main menu of the game
        /// </summary>
        public void MainMenuControl()
        {
            // Local variables
            bool programEnded = false;

            // Creation of the file for HighScore
            hsc.CreateHighScores();
            
            // Menu loop
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
                        render.RenderControls();
                        break;
                    case "4":
                        programEnded = true;
                        break;     
                }
            } while (!programEnded);
        }

        /// <summary>
        /// This method manages the game loop 
        /// </summary>
        public void GameLoop()
        {
            // Turn cursor invisible
            Console.CursorVisible = false;

            // Render first the border and the snake
            render.GameBorder();
            render.RenderSnake(applesEaten, xMove,yMove, out xMove, out yMove);

            // First key press to start
            input = Console.ReadKey(true).Key;

            // Sets apple position then draw it
            SetApplePosition(random, out xApplePos, out yApplePos);
            render.RenderApple(xApplePos, yApplePos);

            // Game Loop
            do
            {
                // Detects user input
                InputManager();

                // Update the game every frame
                Update();

                // Draw the game for the user
                RenderGame();
                
                // Slow down the game every "speed" miliseconds
                Thread.Sleep(Convert.ToInt32(speed));

            } while (!gameEnded);

            // Records the new score of the current user after losing the game
            hsc.HighScoreController(this);
        }
        
        /// <summary>
        /// Sets the apple a random position
        /// </summary>
        /// <param name="rand">Random variable</param>
        /// <param name="x">Position x</param>
        /// <param name="y">Position y</param>
        private void SetApplePosition(Random rand, out int x, out int y)
        {
            x = rand.Next(2, 60);
            y = rand.Next(2, 40);
        }

        /// <summary>
        /// Resets the game by putting every main variable to its default value
        /// </summary>
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

            gameEnded = false;
        }

        /// <summary>
        /// Manages the user input inside the game loop
        /// </summary>
        private void InputManager()
        {
            // Local variable
            ConsoleKey tempKey;

            // if a key is detected
            if (Console.KeyAvailable)
            {
                // Store in the variable the certain key
                tempKey = Console.ReadKey(true).Key;
                // This clears the input buffer
                while (Console.KeyAvailable) { Console.ReadKey(true); }
                // Checks if the certain key corresponds to the valid keys
                snake.ValidKeys(tempKey);
            }
            // Calls the movement required corresponding the input
            snake.InputMove(xMove[0], yMove[0], out xMove[0], out yMove[0]);
        }

        /// <summary>
        /// Updates the game every time inside the game loop
        /// </summary>
        private void Update()
        {
            // Local variable
            bool hitwall;
            bool hitItselft;

            // Checks if snake hit the wall or itself
            hitwall = snake.CollideWithWall(xMove[0], yMove[0]);
            hitItselft = snake.HitBodyCheck(xMove, yMove, applesEaten);
            if (hitwall || hitItselft) gameEnded = true;

            // Checks if apple was eaten
            isAppleEaten = snake.AppleCheck
                (xMove[0], yMove[0], xApplePos, yApplePos);

            // If its eaten spawns a new one, increment the number apples eaten
            //and speed
            if (isAppleEaten)
            {
                SetApplePosition(random, out xApplePos, out yApplePos);
                render.RenderApple(xApplePos, yApplePos);
                applesEaten++;
                speed *= 0.95f;
                render.RenderScore(this);
            }
        }

        /// <summary>
        /// Draws the game inside the game loop
        /// </summary>
        private void RenderGame()
        {
            render.RenderSnake
                (applesEaten, xMove, yMove, out xMove, out yMove);
        }
    }
}
