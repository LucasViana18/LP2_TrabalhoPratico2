using System;

namespace SnakeGame
{
    class Render
    {
        // Visual construction of the game borders
        public void GameBorder()
        {

            //Borders

            // Left vertical border
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
            }

            // Right vertical border
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(61, i);
                Console.Write("#");
            }

            // Top horizontal border
            for (int i = 1; i < 61; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
            }

            // Bottom horizontal border
            for (int i = 1; i < 62; i++)
            {

                Console.SetCursorPosition(i, 41);
                Console.Write("#");
            }
        }

        //Snake
        //public void StartSnek()
        //{
        //    Random rnd = new Random();
        //    int positionx = rnd.Next(2,60);
        //    int positiony = rnd.Next(2, 40);

        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.SetCursorPosition(positionx, positiony);
        //    Console.WriteLine("c:");
        //}

        public void RenderSnake(int applesEaten, int[] xPosIn, int[] yPosIn,
            out int[] xPosOut, out int[] yPosOut)
        {

            //Render Head
            Console.SetCursorPosition(xPosIn[0], yPosIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("O");

            //Render Body
            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPosIn[i], yPosIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }

            //Erase snake last part
            Console.SetCursorPosition(xPosIn[applesEaten + 1], yPosIn[applesEaten + 1]);
            Console.WriteLine(" ");

            //Record position of each body part
            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPosIn[i] = xPosIn[i - 1];
                yPosIn[i] = yPosIn[i - 1];
            }

            //Return new arrey
            xPosOut = xPosIn;
            yPosOut = yPosIn;
        }
    }
}

