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
                Console.Write("&");
            }

            // Right vertical border
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(61, i);
                Console.Write("&");
            }

            // Top horizontal border
            for (int i = 1; i < 61; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 1);
                Console.Write("&");
            }

            // Bottom horizontal border
            for (int i = 1; i < 62; i++)
            {
                
                Console.SetCursorPosition(i, 41);
                Console.Write("&");
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

        public void DrawSnek(int xPosIn, int yPosIn)
        {
            Console.SetCursorPosition(xPosIn, yPosIn);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$");

            //xPosOut = xPosIn;
            //yPosOut = yPosIn;
        }

        public void Apple()
        {
            Random rnd = new Random();
            int positionx = rnd.Next(2, 60);
            int positiony = rnd.Next(2, 40);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(positionx, positiony);
            Console.WriteLine("Apple");
        }
    }
}

